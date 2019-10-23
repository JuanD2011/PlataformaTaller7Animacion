using UnityEngine;
using TMPro;

public class UIUsername : MonoBehaviour
{
    private TextMeshProUGUI m_Text = null;

    private void Awake()
    {
        m_Text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        LogInManager.OnLoggedIn += SetUsernameText;
    }

    private void SetUsernameText(bool _LoggedIn)
    {
        if (!_LoggedIn) return;

        m_Text.text = UsersDatabase.CurrentUser.username;
    }
}
