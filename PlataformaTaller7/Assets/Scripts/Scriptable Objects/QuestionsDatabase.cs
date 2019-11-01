using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Questions Database", menuName = "Questions Database")]
public class QuestionsDatabase : ScriptableObject
{
    public List<Question> Questions { get; private set; } = null;

    public Queue<Question> LastQuestions { get; private set; } = new Queue<Question>();

    /// <summary>
    /// Initialize all the questions
    /// </summary>
    public void CreateQuestions()
    {
        if (Questions == null) Questions = new List<Question>();

        Questions.Clear();

        #region Multiple Choice
        //1
        Questions.Add(new MultipleChoice("Selecciona cuál de estos animales no pertenece a un ecosistema terrestre", new string[3] { "Ballena jorobada", "Oso perezoso", "Águila" }, 2));

        //2
        Questions.Add(new MultipleChoice("Cuál de los siguientes es un ecosistema donde no llueve mucho, la fauna y la flora son bastante escasos en la mayoría de sus partes", new string[3] { "Praderas", "Selva Tropical", "Desierto" }, 2));

        //3
        Questions.Add(new MultipleChoice("Uno de estos tipos de ecosistema ocupa el 75% de nuestro planeta", new string[3] { "Aéreo", "Acuático", "Terrestre" }, 1));

        //4
        Questions.Add(new MultipleChoice("Una de estas acciones no es una forma de conservar los ecosistemas", new string[3] { "Usar moderadamente el agua al bañarse", "Sacar a un animal de su hábitat natural", "Usar paneles solares para alumbrar un hogar mediante la luz del sol" }, 1));

        //5
        Questions.Add(new MultipleChoice("¿Cuál es el hábitat de un pez salmón?", new string[3] { "Los bosques", "Los lagos", "Las montañas" }, 1));

        //6
        Questions.Add(new MultipleChoice("Uno de estos animales son seres vivos que flotan en el agua, no tienen movilidad alguna y conforman un ecosistema", new string[3] { "Los tiburones", "Los peces", "El plancton" }, 2));

        //7
        Questions.Add(new MultipleChoice("El cangrejo araña lleva unas algas en la espalda para camuflarse de los depredadores, a su vez, esas algas tienen un lugar donde vivir en el cangrejo. Esta es una interrelación de:", new string[3] { "Competencia", "Mutualismo", "Comensalismo" }, 1));

        //8
        Questions.Add(new MultipleChoice("No es una consecuencia de la deforestación", new string[3] { "La pérdida del hábitat de los animales", "La alteración del clima", "La conservación de las especies" }, 2));

        //9
        Questions.Add(new MultipleChoice("¿Cuál es el hábitat de un tiburón?", new string[3] { "Los océanos", "Los lagos", "Los ríos" }, 0));

        //10
        Questions.Add(new MultipleChoice("¿Cuál es el nicho ecológico de un jaguar?", new string[3] { "Herbívoro", "Omnívoro", "Carnívoro" }, 2));
        #endregion

        #region True or False
        //1
        Questions.Add(new TrueOrFalse("El bosque tropical es un ecosistema artificial", false));

        //2
        Questions.Add(new TrueOrFalse("Un jardín es un ecosistema natural", false));

        //3
        Questions.Add(new TrueOrFalse("En las montañas no se encuentra ningún árbol, sólo hierbas altas, medias y largas", false));

        //4
        Questions.Add(new TrueOrFalse("La deforestación ocasiona la pérdida de biodiversidad", true));

        //5
        Questions.Add(new TrueOrFalse("Cuando dos seres interactúan a través del mutualismo ambos se benefician del otro", true));

        //6
        Questions.Add(new TrueOrFalse("La tala de árboles para extraer madera es una deforestación natural", false));

        //7
        Questions.Add(new TrueOrFalse("Dentro del nicho ecológico de un león se conoce que es un animal carnívoro", true));

        //8
        Questions.Add(new TrueOrFalse("La palma de cera es un ser abiótico", false));

        //9
        Questions.Add(new TrueOrFalse("Usar adecuadamente los combustibles ayuda a conservar los ecosistemas", true));

        //10
        Questions.Add(new TrueOrFalse("El colibrí tiene una relación de mutualismo con las flores", true));
        #endregion

        #region Association
        //1
        Questions.Add(new Association("", "", 0));

        //2
        Questions.Add(new Association("", "", 1));

        //3
        Questions.Add(new Association("", "", 2));

        //4
        Questions.Add(new Association("", "", 3));

        //5
        Questions.Add(new Association("", "", 4));

        //6
        Questions.Add(new Association("", "", 5));

        //7
        Questions.Add(new Association("", "", 6));

        //8
        Questions.Add(new Association("", "", 7));

        //9
        Questions.Add(new Association("", "", 8));

        //10
        Questions.Add(new Association("", "", 9));
        #endregion
    }

    /// <summary>
    /// Set last question asked
    /// </summary>
    /// <param name="_Question"></param>
    public void SetLastQuestion(Question _Question)
    {
        if (LastQuestions.Count < 3)
        {
            LastQuestions.Enqueue(_Question);
        }
        else
        {
            LastQuestions.Dequeue();
            LastQuestions.Enqueue(_Question);
        }
    }
}
