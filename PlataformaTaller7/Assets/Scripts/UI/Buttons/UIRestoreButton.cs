using UnityEngine;

public class UIRestoreButton : MonoBehaviour
{
    public void OnButtonClicked()
    {
        UsersDatabase.CurrentUser.properties.Restore();
    }
}
