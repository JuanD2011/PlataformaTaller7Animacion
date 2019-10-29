using UnityEngine;
using UnityEngine.UI;

public class CharacterVisualization : MonoBehaviour
{
    [SerializeField]
    private GameObject frontHair = null, backHair = null, outfit = null, frontAccessory = null, backAccessory = null;

    [SerializeField]
    private Image body = null, hands = null; 

    public void UpdateCharacter()
    {
        body.color = UsersDatabase.CurrentUser.properties.skinColor;
        hands.color = UsersDatabase.CurrentUser.properties.skinColor;

        frontHair.transform.GetChild(UsersDatabase.CurrentUser.properties.hairstyle).GetComponent<Image>().color = UsersDatabase.CurrentUser.properties.hairColor;
        if (backHair.transform.GetChild(UsersDatabase.CurrentUser.properties.hairstyle).GetComponent<Image>().sprite != null)
        {
            backHair.transform.GetChild(UsersDatabase.CurrentUser.properties.hairstyle).GetComponent<Image>().color = UsersDatabase.CurrentUser.properties.hairColor;
        }
        else backHair.transform.GetChild(UsersDatabase.CurrentUser.properties.hairstyle).GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);

        for (int i = 0; i < frontHair.transform.childCount; i++)
        {
            if (i != UsersDatabase.CurrentUser.properties.hairstyle)
            {
                frontHair.transform.GetChild(i).gameObject.SetActive(false);
                backHair.transform.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                frontHair.transform.GetChild(i).gameObject.SetActive(true);
                backHair.transform.GetChild(i).gameObject.SetActive(true);
            }
        }

        for (int i = 0; i < frontAccessory.transform.childCount; i++)
        {
            if (i != UsersDatabase.CurrentUser.properties.accessory)
            {
                frontAccessory.transform.GetChild(i).gameObject.SetActive(false);
                backAccessory.transform.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                frontAccessory.transform.GetChild(i).gameObject.SetActive(true);
                if (backAccessory.transform.GetChild(i).GetComponent<Image>().sprite != null)
                {
                    backAccessory.transform.GetChild(i).gameObject.SetActive(true); 
                }
            }
        }

        for (int i = 0; i < outfit.transform.childCount; i++)
        {
            if (i != UsersDatabase.CurrentUser.properties.outfit) outfit.transform.GetChild(i).gameObject.SetActive(false);
            else outfit.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
