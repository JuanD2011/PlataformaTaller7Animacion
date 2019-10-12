using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Questions Data Base", menuName = "Questions Data Base")]
public class QuestionsDataBase : ScriptableObject
{
    [SerializeField] List<Question> questions = new List<Question>();

    public List<Question> Questions { get => questions; set => questions = value; }

    public void CreateQuestion(QuestionType _QuestionType)
    {
        switch (_QuestionType)
        {
            case QuestionType.TrueOrFalse:
                break;
            case QuestionType.MultipleChoice:
                questions.Add(new MultipleChoice());
                break;
            case QuestionType.Association:
                break;
            case QuestionType.None:
                break;
            default:
                break;
        }
    }
}
