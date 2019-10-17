using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    QuestionsDataBase questionsDataBase = null;

    int randomQuestion = 0;

    Question question = null;

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
