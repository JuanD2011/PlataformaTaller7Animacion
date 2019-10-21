using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField] CurrencyDataBase currencyDataBase = null;

    private BoxType boxType = BoxType.None;

    private void Awake()
    {
#if !UNITY_EDITOR
        Memento.LoadData(currencyDataBase); 
#endif
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

    private void OnApplicationQuit()
    {
        Memento.SaveData(currencyDataBase);
    }
}
