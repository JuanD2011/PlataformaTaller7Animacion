using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Settings settings = null;

    [SerializeField]
    private UsersDatabase usersDatabase = null;

    [SerializeField]
    private CurrencyDatabase currencyDatabase = null;

    private void Awake()
    {
        Memento.LoadData(settings);
        Memento.LoadData(usersDatabase);
        Memento.LoadData(currencyDatabase);
    }

    /// <summary>
    /// Save settings
    /// </summary>
    public void SaveSettings()
    {
        Memento.SaveData(settings);
    }

    public void SaveUsersDatabase()
    {
        Memento.SaveData(usersDatabase);
    }
}
