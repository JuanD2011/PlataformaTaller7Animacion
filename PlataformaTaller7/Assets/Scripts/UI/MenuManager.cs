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
#if !UNITY_EDITOR
        Memento.LoadData(usersDatabase);
#endif
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
