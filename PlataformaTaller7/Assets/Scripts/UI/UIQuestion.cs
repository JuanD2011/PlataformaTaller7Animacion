using UnityEngine;
using TMPro;

public class UIQuestion : MonoBehaviour
{
    SettingsTabManager settingsTabManager = null;

    [SerializeField] TextMeshProUGUI questionName = null, questionDescription = null;

    [SerializeField] Animator correctAnswer = null, wrongAnswer = null;

    private readonly string popupWindowIn = "Popup Window In";

    private void Awake()
    {
        settingsTabManager = GetComponent<SettingsTabManager>();
    }

    private void Start()
    {
        QuestionManager.OnQuestionAssigned += ActivateUIQuestion;
        QuestionManager.OnQuestionAnswered += ActivateUIAnswer;
    }

    private void ActivateUIAnswer(QuestionAnsweredType _QuestionAnsweredType)
    {
        if (_QuestionAnsweredType == QuestionAnsweredType.Correct)
        {
            correctAnswer.Play(popupWindowIn);
        }
        else
        {
            wrongAnswer.Play(popupWindowIn);
        }
    }

    private void ActivateUIQuestion(Question _Question)
    {
        questionName.text = _Question.name;
        questionDescription.text = _Question.description;

        if (_Question.questionType == QuestionType.MultipleChoice)
        {
            settingsTabManager.PanelAnim(0);
        }
        else if (_Question.questionType == QuestionType.TrueOrFalse)
        {
            settingsTabManager.PanelAnim(1);
        }
        else
        {
            settingsTabManager.PanelAnim(2);
        }
    }
}
