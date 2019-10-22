using UnityEngine;
using TMPro;

public class UIMultipleChoice : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] options = new TextMeshProUGUI[3];

    void Start()
    {
        QuestionManager.OnQuestionAssigned += SetOptions;       
    }

    private void SetOptions(Question _Question)
    {
        if (_Question.questionType != QuestionType.MultipleChoice) return;

        MultipleChoice multipleChoice = _Question as MultipleChoice;

        for (int i = 0; i < options.Length; i++)
        {
            options[i].text = multipleChoice.options[i];
        }
    }
}
