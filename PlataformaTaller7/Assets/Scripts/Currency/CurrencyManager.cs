using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField] CurrencyDataBase currencyDataBase = null;

    private void Awake()
    {
        Memento.LoadData(currencyDataBase);
    }

    void Start()
    {
        QuestionManager.OnQuestionAnswered += ManageAnswer;       
    }

    private void ManageAnswer(QuestionAnsweredType _QuestionAnsweredType)
    {
        if (_QuestionAnsweredType == QuestionAnsweredType.Correct)
        {
            //check if the reward is for 5 seeds
            if (true)
            {
                currencyDataBase.seeds += 3;
            }
            else
            {
                currencyDataBase.seeds += 5;
            }
            Memento.SaveData(currencyDataBase);
        }
    }
}
