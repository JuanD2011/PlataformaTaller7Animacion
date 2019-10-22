using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Questions Data Base", menuName = "Questions Data Base")]
public class QuestionsDataBase : ScriptableObject
{
    public List<Question> Questions { get; private set; } = null;

    public Question LastQuestion { get; private set; } = null;

    /// <summary>
    /// Initialize all the questions
    /// </summary>
    public void CreateQuestions()
    {
        if (Questions == null) Questions = new List<Question>();

        Questions.Clear();

        Questions.Add(new MultipleChoice("Cuál es el carro más rápido", new string[3] {"Bugatti", "Tesla", "Renault 8" }, 0));
        Questions.Add(new TrueOrFalse("¿Es cierto que Confucio inventó la confusión?", false));
        Questions.Add(new Association("Conecta las imágenes con sus nombres respectivos", AssociationType.Animals));
    }

    /// <summary>
    /// Set last question asked
    /// </summary>
    /// <param name="_Question"></param>
    public void SetLastQuestion(Question _Question)
    {
        LastQuestion = _Question;
    }
}
