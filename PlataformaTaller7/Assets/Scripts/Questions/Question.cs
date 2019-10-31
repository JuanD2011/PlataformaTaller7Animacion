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

    private string firstKey = "", secondKey = "", thirdKey = "";

    public System.Collections.Generic.Dictionary<int, string> idToKey = new System.Collections.Generic.Dictionary<int, string>();
    public System.Collections.Generic.Dictionary<string, string> keyToAnswer = new System.Collections.Generic.Dictionary<string, string>();

    public Association(AssociationType _AssociationType) : base(string.Empty)
    {
        questionType = QuestionType.Association;
        associationType = _AssociationType;

        GenerateDictionary();
    }

    private void GenerateDictionary()
    {
        idToKey.Clear();
        keyToAnswer.Clear();

        switch (associationType)
        {
            case AssociationType.CommunityInteractions:
                firstKey = "Mutualismo"; secondKey = "Competencia"; thirdKey = "Ciclo biogeoquímico";

                idToKey.Add(0, firstKey);
                idToKey.Add(1, secondKey);
                idToKey.Add(2, thirdKey);

                keyToAnswer.Add(firstKey, "Ambas partes se benefician de la interacción");
                keyToAnswer.Add(secondKey, "Se afecta la tasa de crecimiento o reproducción del otro");
                keyToAnswer.Add(thirdKey, "Los ecosistemas se ven influenciados por los movimientos de los nutrientes");
                break;
            case AssociationType.Biome:
                firstKey = "Mutualismo"; secondKey = "Competencia"; thirdKey = "Ciclo biogeoquímico";

                idToKey.Add(0, firstKey);
                idToKey.Add(1, secondKey);
                idToKey.Add(2, thirdKey);

                keyToAnswer.Add(firstKey, "Ambas partes se benefician de la interacción");
                keyToAnswer.Add(secondKey, "Se afecta la tasa de crecimiento o reproducción del otro");
                keyToAnswer.Add(thirdKey, "Los ecosistemas se ven influenciados por los movimientos de los nutrientes");
                break;
            case AssociationType.Ecosystem:
                firstKey = "Mutualismo"; secondKey = "Competencia"; thirdKey = "Ciclo biogeoquímico";

                idToKey.Add(0, firstKey);
                idToKey.Add(1, secondKey);
                idToKey.Add(2, thirdKey);

                keyToAnswer.Add(firstKey, "Ambas partes se benefician de la interacción");
                keyToAnswer.Add(secondKey, "Se afecta la tasa de crecimiento o reproducción del otro");
                keyToAnswer.Add(thirdKey, "Los ecosistemas se ven influenciados por los movimientos de los nutrientes");
                break;
            case AssociationType.None:
                break;
            default:
                break;
        }
    }
}
