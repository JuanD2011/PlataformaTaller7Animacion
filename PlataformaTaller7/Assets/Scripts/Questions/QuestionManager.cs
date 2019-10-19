using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    private QuestionsDataBase questionsDataBase = null;

    private int randomQuestion = 0;

    private Question question = null;

    #region Association Attributes
    private bool optionSet = false, answerSet = false;
    private int firstId = 0;
    private int secondId = 0;
    #endregion

    public static event Delegates.Action<Question> OnQuestionAssigned = null;
    public static event Delegates.Action<QuestionAnsweredType> OnQuestionAnswered = null;

    private void Awake()
    {
        OnQuestionAssigned = null; OnQuestionAnswered = null;

        questionsDataBase = Resources.Load<QuestionsDataBase>("Scriptable Objects/Questions Data Base");

        questionsDataBase.CreateQuestions();
    }

    void Start()
    {
        LadderManager.Manager.Character.OnReachDestination += PickAQuestion;

        UIAssociationOption.OnAssociationOptionClicked += CheckCoupleAssociation;
    }

    private void CheckCoupleAssociation(AssociationOptionType _AssociationOptionType, int _Id)
    {
        if (_AssociationOptionType == AssociationOptionType.Option)
        {
            firstId = _Id;
            optionSet = true;
        }
        else if (_AssociationOptionType == AssociationOptionType.Answer)
        {
            secondId = _Id;
            answerSet = true;
        }

        if (optionSet && answerSet)
        {
            if (firstId == secondId)
            {
                Debug.Log("Correct Match");
            }
            else
            {
                Debug.Log("Wrong Match");
            }

            optionSet = false;
            answerSet = false;
        }
    }

    private void PickAQuestion(BoxType _boxType)
    {
        do
        {
            randomQuestion = Random.Range(0, questionsDataBase.Questions.Count);
            question = questionsDataBase.Questions[randomQuestion];
        }
        while (question == questionsDataBase.LastQuestion);

        questionsDataBase.SetLastQuestion(question);

        OnQuestionAssigned(question);
    }

    /// <summary>
    /// Answer for multiple choice
    /// </summary>
    /// <param name="_AnswerValue"></param>
    public void VerifyMultipleChoiceAnswer(int _AnswerValue)
    {
        MultipleChoice multipleChoice = question as MultipleChoice;

        if (_AnswerValue == multipleChoice.correctAnswer)
        {
            OnQuestionAnswered(QuestionAnsweredType.Correct);
        }
        else
        {
            OnQuestionAnswered(QuestionAnsweredType.Wrong);
        }
    }

    /// <summary>
    /// Verify if the button pressed was the correct answer
    /// </summary>
    /// <param name="_AnswerValue"></param>
    public void VerifyTrueOrFalse(bool _AnswerValue)
    {
        TrueOrFalse trueOrFalse = question as TrueOrFalse;

        if (_AnswerValue == trueOrFalse.answer)
        {
            OnQuestionAnswered(QuestionAnsweredType.Correct);
        }
        else
        {
            OnQuestionAnswered(QuestionAnsweredType.Wrong);
        }
    }

    /// <summary>
    /// If it is the first time, save the id and compare it with the second touch
    /// </summary>
    public void VerifyAssociationCouple()
    {
        //TODO
    }
}
