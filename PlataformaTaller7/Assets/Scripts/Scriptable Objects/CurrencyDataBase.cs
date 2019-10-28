using UnityEngine;

[CreateAssetMenu(fileName = "Currency Database", menuName = "Currency Database")]
public class CurrencyDatabase : ScriptableObject
{
    public Delegates.Action OnSeedsUpdated = null;

    public int seeds = 0;
}

