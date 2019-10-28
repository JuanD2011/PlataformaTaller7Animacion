using UnityEngine;

public class UISkinColorButton : MonoBehaviour
{
    [SerializeField]
    private Color skinColor = Color.white;

    public void OnButtonClicked()
    {
        UsersDatabase.CurrentUser.properties.SetSkinColor(skinColor);
    }
}
