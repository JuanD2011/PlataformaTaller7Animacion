using System;
using UnityEngine;

public class CharacterStyleDatabase : MonoBehaviour
{
    public static CharacterStyleDatabase database = null;


    [Header("Men front Hairstyles")]
    public Sprite[] menFrontHairstyles = new Sprite[5];
    public Sprite[] menBackHairstyles = new Sprite[5];


    [Header("Women Hairstyles")]
    public Sprite[] womenFrontHairstyles = new Sprite[5];
    public Sprite[] womenBackHairstyles = new Sprite[5];

    [Header("Men Outfits")]
    public Sprite[] menOutfits = new Sprite[5];

    [Header("Women Outfits")]
    public Sprite[] womenOutfits = new Sprite[4];

    [Header("Accessories")]
    public Sprite[] frontAccesories = new Sprite[3];
    public Sprite[] backAccesories = new Sprite[3];

    private Sprite[] currentHairstyle = new Sprite[2], currentAccessory = new Sprite[2];
    private void Awake()
    {
        if (database == null) database = this;
        else Destroy(this);
    }


    public Sprite[] GetHairstyle(bool _male, int _id)
    {
        if (_male && _id <= menFrontHairstyles.Length - 1)
        {
            currentHairstyle[0] = menFrontHairstyles[_id];
            currentHairstyle[0] = menBackHairstyles[_id];
            return currentHairstyle;
        }
        else if (_id <= womenFrontHairstyles.Length - 1)
        {
            currentHairstyle[0] = womenFrontHairstyles[_id];
            currentHairstyle[0] = womenBackHairstyles[_id];
            return currentHairstyle;
        }
        else return null;
    }

    internal Sprite[] GetAccessory(int _accessoryId)
    {
        currentAccessory[0] = frontAccesories[_accessoryId];
        currentAccessory[1] = backAccesories[_accessoryId];
        return currentAccessory;
    }

    public Sprite GetOutfit(bool _male, int _id)
    {
        if (_male && _id <= menOutfits.Length - 1) return menOutfits[_id];
        else if (_id <= womenOutfits.Length - 1) return womenOutfits[_id];
        else return null;
    }
}
