using UnityEngine;

public class UISkinColorButton : MonoBehaviour
{
    [SerializeField]
    private Color skinColor = new Color(204f, 148f, 128f);

    public void OnButtonClicked()
    {
        UsersDatabase.CurrentUser.properties.SetSkinColor(skinColor);
    }
}
