using UnityEngine;

[System.Serializable]
public class UserProperty
{
    public bool male = true;
    public Color skinColor = new Color(0.8f, 0.58f, 0.5f), hairColor = Color.black;

    public int hairstyle = 0, outfit = 0, accessory = 0;

    public static event Delegates.Action OnCharacterUpdate = null;

    /// <summary>
    /// Changing between male and female
    /// </summary>
    public void ChangeGenre()
    {
        male = male ? male = false : male = true;
        OnCharacterUpdate?.Invoke();
    }

    public void SetSkinColor(Color _color)
    {
        skinColor = _color;
        OnCharacterUpdate?.Invoke();
    }

    public void SetHairColor(Color _color)
    {
        hairColor = _color;
        OnCharacterUpdate?.Invoke();
    }

    public void SetHairstyle(int _hairstyleId)
    {
        hairstyle = _hairstyleId;
        OnCharacterUpdate?.Invoke();
    }

    public void SetOutfit(int _outfitId)
    {
        outfit = _outfitId;
        OnCharacterUpdate?.Invoke();
    }
    public void SetAccessory(int _accessoryId)
    {
        accessory = _accessoryId;
        OnCharacterUpdate?.Invoke();
    }
}