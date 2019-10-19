public class Question
{
    public string name = "";
    public string description = "";
    public QuestionType questionType = QuestionType.None;

    public Question(string _Name, string _Description)
    {
        name = _Name;
        description = _Description;
    }
}

public class MultipleChoice : Question
{
    public string firstOption = "";
    public string secondOption = "";
    public string thirdOption = "";

    public byte correctAnswer = 0;

    public MultipleChoice(string _Name, string _Description, string _FirstOption, string _SecondOption, string _ThirdOption, byte _CorrectAnswer) : base(_Name, _Description)
    {
        firstOption = _FirstOption;
        secondOption = _SecondOption;
        thirdOption = _ThirdOption;
        correctAnswer = _CorrectAnswer;
        questionType = QuestionType.MultipleChoice;
    }
}

public class TrueOrFalse : Question
{
    public bool answer = false;

    public TrueOrFalse(string _Name, string _Description, bool _Answer) : base(_Name, _Description)
    {
        answer = _Answer;
        questionType = QuestionType.TrueOrFalse;
    }
}

public class Association : Question
{
    public AssociationType associationType = AssociationType.None;

    public System.Collections.Generic.Dictionary<int, string> idToWord = new System.Collections.Generic.Dictionary<int, string>();

    public Association(string _Name, string _Description, AssociationType _AssociationType) : base(_Name, _Description)
    {
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
