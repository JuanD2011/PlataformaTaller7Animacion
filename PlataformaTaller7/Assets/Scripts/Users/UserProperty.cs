using UnityEngine;

[System.Serializable]
public class UserProperty
{
    public bool male = true;
    public Color skinColor = new Color(0.8f, 0.58f, 0.5f), hairColor = new Color(0.0627f, 0.0627f, 0.0627f);


    public int hairstyle = 0, outfit = 0, accessory = 0;

    public static Delegates.Action OnCharacterUpdate = null;

    /// <summary>
    /// Changing between male and female
    /// </summary>
    public void ChangeGenre()
    {
        male = male ? male = false : male = true;
        OnCharacterUpdate();
    }

    public void SetSkinColor(Color _color)
    {
        skinColor = _color;
        OnCharacterUpdate();
    }

    public void SetHairColor(Color _color)
    {
        hairColor = _color;
        OnCharacterUpdate();
    }

    public void SetHairstyle(int _hairstyleId)
    {
        hairstyle = _hairstyleId;
        OnCharacterUpdate();
    }

    public void SetOutfit(int _outfitId)
    {
        outfit = _outfitId;
        OnCharacterUpdate();
    }
    public void SetAccessory(int _accessoryId)
    {
        accessory = _accessoryId;
        OnCharacterUpdate();
    }
    internal void Restore()
    {
        skinColor = new Color(0.8f, 0.58f, 0.5f);
        hairColor = new Color(0.0627f, 0.0627f, 0.0627f);
        hairstyle = 0;
        outfit = 0;
        accessory = 0;
        OnCharacterUpdate();
    }
}