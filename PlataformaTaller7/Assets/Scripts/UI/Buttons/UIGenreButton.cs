using UnityEngine;

public class UIGenreButton : MonoBehaviour
{
    public void OnButtonClicked()
    {
        UsersDatabase.CurrentUser.properties.ChangeGenre();
    }
}
