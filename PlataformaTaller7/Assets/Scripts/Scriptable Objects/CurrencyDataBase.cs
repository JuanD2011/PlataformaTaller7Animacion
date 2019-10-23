using UnityEngine;

[CreateAssetMenu(fileName = "Currency Data Base", menuName = "Currency Data Base")]
public class CurrencyDatabase : ScriptableObject
{
    public Delegates.Action OnSeedsUpdated = null;

    public int seeds = 0;
}

