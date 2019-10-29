using UnityEngine;

public class UIHairColorButton : MonoBehaviour
{
    [SerializeField]
    private Color hairColor = Color.black;

    public void OnButtonClicked()
    {
        UsersDatabase.CurrentUser.properties.SetHairColor(hairColor);
    }
}
