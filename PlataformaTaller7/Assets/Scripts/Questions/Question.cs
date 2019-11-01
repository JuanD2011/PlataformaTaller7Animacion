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
    private byte id = 0;

    private string firstKey = "", secondKey = "", thirdKey = "";

    public string leftColumn = "", rightColumn = "";

    public System.Collections.Generic.Dictionary<int, string> idToKey = new System.Collections.Generic.Dictionary<int, string>();
    public System.Collections.Generic.Dictionary<string, string> keyToAnswer = new System.Collections.Generic.Dictionary<string, string>();

    public Association(string _LeftColumn, string _RightColumn, byte _Id) : base(string.Empty)
    {
        questionType = QuestionType.Association;

        id = _Id;

        leftColumn = _LeftColumn;
        rightColumn = _RightColumn;

        GenerateDictionary();
    }

    private void GenerateDictionary()
    {
        idToKey.Clear();
        keyToAnswer.Clear();

        switch (id)
        {
            case 0:
                firstKey = "Mutualismo"; secondKey = "Competencia"; thirdKey = "Ciclo biogeoquímico";

                idToKey.Add(0, firstKey);
                idToKey.Add(1, secondKey);
                idToKey.Add(2, thirdKey);

                keyToAnswer.Add(firstKey, "Las abejas y las flores");
                keyToAnswer.Add(secondKey, "Anémonas marinas compitiendo por territorio");
                keyToAnswer.Add(thirdKey, "Ciclo del agua");
                break;
            case 1:
                firstKey = "Selva"; secondKey = "Tundra"; thirdKey = "Montaña";

                idToKey.Add(0, firstKey);
                idToKey.Add(1, secondKey);
                idToKey.Add(2, thirdKey);

                keyToAnswer.Add(firstKey, "Jaguar, tigre");
                keyToAnswer.Add(secondKey, "Zorro polar, Oso gris, Oso polar");
                keyToAnswer.Add(thirdKey, "Cabra, Venado, Águila real");
                break;
            case 2:
                firstKey = "Aéreo"; secondKey = "Terrestre"; thirdKey = "Acuático.";

                idToKey.Add(0, firstKey);
                idToKey.Add(1, secondKey);
                idToKey.Add(2, thirdKey);

                keyToAnswer.Add(firstKey, "Ecosistema de transición");
                keyToAnswer.Add(secondKey, "Ecosistema formado por toda porción de tierra en el continente o en el subsuelo");
                keyToAnswer.Add(thirdKey, "Ecosistema que se desarrolla en un lugar con agua");
                break;
            case 3:
                firstKey = "Anaconda"; secondKey = "Pez martillo"; thirdKey = "Oso";

                idToKey.Add(0, firstKey);
                idToKey.Add(1, secondKey);
                idToKey.Add(2, thirdKey);

                keyToAnswer.Add(firstKey, "Selva");
                keyToAnswer.Add(secondKey, "Océano");
                keyToAnswer.Add(thirdKey, "Montaña");
                break;
            case 4:
                firstKey = "Puma"; secondKey = "Pato"; thirdKey = "Cerdo";

                idToKey.Add(0, firstKey);
                idToKey.Add(1, secondKey);
                idToKey.Add(2, thirdKey);

                keyToAnswer.Add(firstKey, "Carnívoro");
                keyToAnswer.Add(secondKey, "Herbívoro");
                keyToAnswer.Add(thirdKey, "Omnívoro");
                break;
            case 5:
                firstKey = "Azul"; secondKey = "Verde"; thirdKey = "Gris";

                idToKey.Add(0, firstKey);
                idToKey.Add(1, secondKey);
                idToKey.Add(2, thirdKey);

                keyToAnswer.Add(firstKey, "Papel y cartón");
                keyToAnswer.Add(secondKey, "Vidrio");
                keyToAnswer.Add(thirdKey, "Desechos orgánicos");
                break;
            case 6:
                firstKey = "Deforestación"; secondKey = "Trata de animales"; thirdKey = "Contaminación";

                idToKey.Add(0, firstKey);
                idToKey.Add(1, secondKey);
                idToKey.Add(2, thirdKey);

                keyToAnswer.Add(firstKey, "Eliminación del bosque");
                keyToAnswer.Add(secondKey, "Sacar a un animal de su hábitat natural");
                keyToAnswer.Add(thirdKey, "Introducir agentes contaminantes que alteran el entorno");
                break;
            case 7:
                firstKey = "Fines humanos"; secondKey = "Fin industrial"; thirdKey = "Por minería";

                idToKey.Add(0, firstKey);
                idToKey.Add(1, secondKey);
                idToKey.Add(2, thirdKey);

                keyToAnswer.Add(firstKey, "Realizada por actividades como la agricultura para obtener beneficios económicos");
                keyToAnswer.Add(secondKey, "Realizada por industrias madereras y fábricas");
                keyToAnswer.Add(thirdKey, "Afecta a la degradación de los suelos y a las poblaciones de la zona");
                break;
            case 8:
                //TODO change the third option
                firstKey = "Natural"; secondKey = "Causada por el hombre"; thirdKey = "Changeeee Meee";

                idToKey.Add(0, firstKey);
                idToKey.Add(1, secondKey);
                idToKey.Add(2, thirdKey);

                keyToAnswer.Add(firstKey, "Causada por tornados, fenómenos naturales, incendios");
                keyToAnswer.Add(secondKey, "Para fines como la elaboración de madera, papel, construcciones, etc");
                keyToAnswer.Add(thirdKey, "Changeeee Meee");
                break;
            case 9:
                firstKey = "Pérdida de biodiversidad"; secondKey = "Degradación del hábitat"; thirdKey = "Alteración del clima global.";

                idToKey.Add(0, firstKey);
                idToKey.Add(1, secondKey);
                idToKey.Add(2, thirdKey);

                keyToAnswer.Add(firstKey, "Reducción de las especies por la pérdida de su hábitat");
                keyToAnswer.Add(secondKey, "Daño causado por la fragmentación del bosque");
                keyToAnswer.Add(thirdKey, "Causada por la reducción de la capacidad de absorción del CO2");
                break;
            default:
                break;
        }
    }
}
