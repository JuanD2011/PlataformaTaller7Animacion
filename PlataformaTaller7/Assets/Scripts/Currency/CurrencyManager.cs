using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField] CurrencyDatabase currencyDataBase = null;

    private BoxType boxType = BoxType.None;

    private void Awake()
    {
        Memento.LoadData(currencyDataBase); 
    }

    void Start()
    {
        QuestionManager.OnQuestionAnswered += ManageAnswer;
        LadderManager.Manager.Character.OnReachDestination += (BoxType _BoxType) => boxType = _BoxType; 
    }

    private void ManageAnswer(QuestionAnsweredType _QuestionAnsweredType)
    {
        if (_QuestionAnsweredType == QuestionAnsweredType.Correct)
        {
            if (boxType != BoxType.Bright)
            {
                currencyDataBase.seeds += 3;
            }
            else
            {
                currencyDataBase.seeds += 5;
            }
            currencyDataBase.OnSeedsUpdated();
            Memento.SaveData(currencyDataBase);
        }
    }
}
