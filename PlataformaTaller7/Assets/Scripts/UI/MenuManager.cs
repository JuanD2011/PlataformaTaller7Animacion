using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Settings settings = null;

    [SerializeField]
    private UsersDatabase usersDatabase = null;

    private void Awake()
    {
        Memento.LoadData(settings);
        Memento.LoadData(usersDatabase);
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

    private void OnApplicationQuit()
    {
        if (settings != null) SaveSettings();

        if (usersDatabase != null) SaveUsersDatabase();
    }
}
