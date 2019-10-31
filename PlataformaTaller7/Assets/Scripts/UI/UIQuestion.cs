using UnityEngine;
using TMPro;

public class UIQuestion : MonoBehaviour
{
    private SettingsTabManager settingsTabManager = null;

    [SerializeField] private SettingsTabManager headerSettings = null;

    [SerializeField] private TextMeshProUGUI leftColumn = null, rightColumn = null;

    [SerializeField] private TextMeshProUGUI questionDescription = null;
    [SerializeField] private Animator correctAnswer = null, wrongAnswer = null;

    private readonly string popupWindowIn = "Popup Window In";

    private Association association = null;

    private void Awake()
    {
        settingsTabManager = GetComponent<SettingsTabManager>();
    }

    private void Start()
    {
        QuestionManager.OnQuestionAssigned += SetUIQuestion;
        QuestionManager.OnQuestionAnswered += ActivateUIAnswer;

        QuestionManager.OnAssociationComplete += () => GetComponent<Animator>().Play("Popup Window Out");
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

    private void SetUIQuestion(Question _Question)
    {
        questionDescription.text = _Question.description;

        if (_Question.questionType == QuestionType.MultipleChoice)
        {
            headerSettings.PanelAnim(0);
            settingsTabManager.PanelAnim(0);
        }
        else if (_Question.questionType == QuestionType.TrueOrFalse)
        {
            headerSettings.PanelAnim(0);
            settingsTabManager.PanelAnim(1);
        }
        else
        {
            association = _Question as Association;

            leftColumn.text = association.leftColumn;
            rightColumn.text = association.rightColumn;

            headerSettings.PanelAnim(1);
            settingsTabManager.PanelAnim(2);
        }
    }
}
