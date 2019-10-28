using UnityEngine;

public class UIHairstyleButton : MonoBehaviour
{
    public void OnButtonClicked(int _hairstyleId)
    {
        UsersDatabase.CurrentUser.properties.SetHairstyle(_hairstyleId);
    }
}
