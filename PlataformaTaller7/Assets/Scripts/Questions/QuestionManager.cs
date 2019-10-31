using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    private QuestionsDatabase questionsDataBase = null;

    private int randomQuestion = 0;

    private Question question = null;

    #region Association Attributes
    private bool optionSet = false, answerSet = false;
    private UIAssociationOption firstUIAssociationOption = null;
    private UIAssociationOption secondUIAssociationOption = null;
    private byte couplesReached = 0;
    #endregion

    public static event Delegates.Action<Question> OnQuestionAssigned = null;
    public static event Delegates.Action<QuestionAnsweredType> OnQuestionAnswered = null;

    public static event Delegates.Action<QuestionAnsweredType, UIAssociationOption, UIAssociationOption> OnAssociationConnected = null;
    public static event Delegates.Action OnAssociationComplete = null;

    private void Awake()
    {
        OnQuestionAssigned = null; OnQuestionAnswered = null; OnAssociationConnected = null; OnAssociationComplete = null;

        questionsDataBase = Resources.Load<QuestionsDatabase>("Scriptable Objects/Questions Database");

        questionsDataBase.CreateQuestions();
    }

    void Start()
    {
        LadderManager.Manager.Character.OnReachDestination += PickAQuestion;

        UIAssociationOption.OnAssociationOptionClicked += CheckCoupleAssociation;
    }

    private void CheckCoupleAssociation(UIAssociationOption _UIAssociationOption)
    {
        if (_UIAssociationOption.AssociationOptionType == AssociationOptionType.Option)
        {
            firstUIAssociationOption = _UIAssociationOption;
            optionSet = true;
        }
        else if (_UIAssociationOption.AssociationOptionType == AssociationOptionType.Answer)
        {
            secondUIAssociationOption = _UIAssociationOption;
            answerSet = true;
        }

        if (optionSet && answerSet)
        {
            if (firstUIAssociationOption.Id == secondUIAssociationOption.Id)
            {
                firstUIAssociationOption.SetInteractability(false);
                secondUIAssociationOption.SetInteractability(false);

                OnAssociationConnected(QuestionAnsweredType.Correct, firstUIAssociationOption, secondUIAssociationOption);
                couplesReached += 1;

                if (couplesReached == 3)
                {
                    OnAssociationComplete();
                    OnQuestionAnswered(QuestionAnsweredType.Correct);
                    couplesReached = 0;
                }
            }
            else
            {
                OnAssociationConnected(QuestionAnsweredType.Wrong, firstUIAssociationOption, secondUIAssociationOption);
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
}
