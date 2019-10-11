using UnityEngine;

[CreateAssetMenu(fileName = "Questions Data Base", menuName = "Questions Data Base")]
public class QuestionsDataBase : ScriptableObject
{
    [SerializeField] private Question[] questions = new Question[0];
}
