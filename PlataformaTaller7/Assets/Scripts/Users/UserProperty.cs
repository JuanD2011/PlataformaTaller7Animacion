using UnityEngine;

[System.Serializable]
public class UserProperty
{
    public bool male = true;
    public Color skinColor = Color.white, hairColor = Color.white;

    public Sprite[] hairstyle = null, accessory = null;
    public Sprite outfit = null;

    public static event Delegates.Action OnCharacterUpdate = null;

    /// <summary>
    /// Changing between male and female
    /// </summary>
    public void ChangeGenre() => male = male ? male = false : male = true;

    public void SetSkinColor(Color _color)
    {
        skinColor = _color;
    }

    public void SetHairColor(Color _color)
    {
        hairColor = _color;
    }

    public void SetHairstyle(int _hairstyleId)
    {
        hairstyle = CharacterStyleDatabase.database.GetHairstyle(male, _hairstyleId);
    }

    public void SetOutfit(int _outfitId)
    {
        outfit = CharacterStyleDatabase.database.GetOutfit(male, _outfitId);
    }
    public void SetAccessory(int _accessoryId)
    {
        accessory = CharacterStyleDatabase.database.GetAccessory(_accessoryId);
    }
}