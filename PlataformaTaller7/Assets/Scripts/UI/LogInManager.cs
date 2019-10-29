using UnityEngine;

public class LogInManager : MonoBehaviour
{
    private UsersDatabase usersDatabase = null;

    private SettingsTabManager settingsTabManager = null;

    private string username = "";
    private string password = "";

    private static bool haveLoggedIn = false;

    public static event Delegates.Action<bool> OnLoggedIn = null;

    private void Awake()
    {
        OnLoggedIn = null;

        usersDatabase = Resources.Load<UsersDatabase>("Scriptable Objects/Users Database");
        settingsTabManager = GetComponent<SettingsTabManager>();
    }

    private void Start()
    {
        if (haveLoggedIn) settingsTabManager.InitializeFirstPanel(0);
    }

    /// <summary>
    /// This is called by the username input field
    /// </summary>
    /// <param name="_Username"></param>
    public void SetUsername(string _Username)
    {
        username = _Username;
    }

    /// <summary>
    /// This is called by the password input field
    /// </summary>
    /// <param name="_Password"></param>
    public void SetPassword(string _Password)
    {
        password = _Password;
    }

    /// <summary>
    /// Check if the username and password match
    /// </summary>
    public void VerifyExistingUser()
    {
        for (int i = 0; i < usersDatabase.Users.Length; i++)
        {
            if (usersDatabase.Users[i].username == username && usersDatabase.Users[i].password == password)
            {
                UsersDatabase.CurrentUser = usersDatabase.Users[i];
                settingsTabManager.PanelAnim(0);
                haveLoggedIn = true;
                OnLoggedIn(true);
                return;
            }
        }
        OnLoggedIn(false);
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            UsersDatabase.CurrentUser = usersDatabase.Users[0];
            settingsTabManager.PanelAnim(0);
            haveLoggedIn = true;
            OnLoggedIn(true);
        }
    }
#endif
}
