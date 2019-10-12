[System.Serializable]
public class Question
{
    public string name = "";
    public string description = "";
    public QuestionType questionType = QuestionType.None;
}

[System.Serializable]
public class MultipleChoice : Question
{
    public string firstOption = "";
    public string secondOption = "";
    public string thirdOption = "";

    public byte correctAnswer = 0;

    public MultipleChoice()
    {
        questionType = QuestionType.MultipleChoice;
    }
}