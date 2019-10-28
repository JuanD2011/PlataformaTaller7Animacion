using UnityEngine;

public class CharacterVisualization : MonoBehaviour
{
    private GameObject male = null, female = null;

    private void Awake()
    {
        UserProperty.OnCharacterUpdate -= UpdateCharacter;
    }

    private void Start()
    {
        UpdateCharacter();
        UserProperty.OnCharacterUpdate += UpdateCharacter;
    }

    private void UpdateCharacter()
    {

    }
}
