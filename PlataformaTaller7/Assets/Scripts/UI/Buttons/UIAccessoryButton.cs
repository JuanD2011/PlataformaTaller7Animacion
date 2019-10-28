using UnityEngine;

public class UIAccessoryButton : MonoBehaviour
{
    public void OnButtonClicked(int _accessoryId)
    {
        UsersDatabase.CurrentUser.properties.SetAccessory(_accessoryId);
    }
}
