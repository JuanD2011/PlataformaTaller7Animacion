public class Question
{
    public string description = "";
    public QuestionType questionType = QuestionType.None;

    public Question(string _Description)
    {
        description = _Description;
    }
}

public class MultipleChoice : Question
{
    public string[] options = new string[3];

    public byte correctAnswer = 0;

    public MultipleChoice(string _Description, string[] _Options, byte _CorrectAnswer) : base(_Description)
    {
        options = _Options;
        correctAnswer = _CorrectAnswer;
        questionType = QuestionType.MultipleChoice;
    }
}

public class TrueOrFalse : Question
{
    public bool answer = false;

    public TrueOrFalse(string _Description, bool _Answer) : base(_Description)
    {
        answer = _Answer;
        questionType = QuestionType.TrueOrFalse;
    }
}

public class Association : Question
{
    public AssociationType associationType = AssociationType.None;

    public string leftColumn = "", rightColumn = "";

    public System.Collections.Generic.Dictionary<int, string> idToWord = new System.Collections.Generic.Dictionary<int, string>();

    public Association(string _LeftColumn, string _RightColumn, AssociationType _AssociationType) : base("")
    {
        leftColumn = _LeftColumn;
        rightColumn = _RightColumn;

        questionType = QuestionType.Association;
        associationType = _AssociationType;

        GenerateDictionary();
    }

    private void GenerateDictionary()
    {
        idToWord.Clear();

        switch (associationType)
        {
            case AssociationType.Animals:
                idToWord.Add(0, "Jirafa");
                idToWord.Add(1, "Caimán");
                idToWord.Add(2, "Pájaro");
                idToWord.Add(3, "Elefante");
                break;
            case AssociationType.None:
                break;
            default:
                break;
        }
    }
}
