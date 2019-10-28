using UnityEngine;

public class UIOutfitButton : MonoBehaviour
{
    public void OnButtonClicked(int _outfitId)
    {
        UsersDatabase.CurrentUser.properties.SetOutfit(_outfitId);
    }
}
