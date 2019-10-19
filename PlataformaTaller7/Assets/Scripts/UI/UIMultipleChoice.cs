using UnityEngine;
using TMPro;

public class UIMultipleChoice : MonoBehaviour
{
    TextMeshProUGUI[] options = new TextMeshProUGUI[3];

    private void Awake()
    {
        options = GetComponentsInChildren<TextMeshProUGUI>();
    }

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
            switch (i)
            {
                case 0:
                    options[i].text = string.Format("A) {0}", multipleChoice.firstOption);
                    break;
                case 1:
                    options[i].text = string.Format("B) {0}", multipleChoice.secondOption);
                    break;
                case 2:
                    options[i].text = string.Format("C) {0}", multipleChoice.thirdOption);
                    break;
                default:
                    break;
            }
        }
    }
}
