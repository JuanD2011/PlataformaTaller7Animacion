using UnityEngine;

public class CharacterVisualizationManager : MonoBehaviour
{
    [SerializeField]
    private CharacterVisualization male = null, female = null;

    private void Awake()
    {
        UserProperty.OnCharacterUpdate = null;
    }

    private void Start()
    {
        LogInManager.OnLoggedIn += OnLoggedIn;
        UserProperty.OnCharacterUpdate += UpdateCharacter;
    }

    private void OnLoggedIn(bool _value)
    {
        if (!_value) return;

        UpdateCharacter();
    }

    private void UpdateCharacter()
    {
        if (UsersDatabase.CurrentUser.properties.male)
        {
            male.UpdateCharacter();
            female.gameObject.SetActive(false);
            male.gameObject.SetActive(true);
        }
        else
        {
            female.UpdateCharacter();
            male.gameObject.SetActive(false);
            female.gameObject.SetActive(true);
        }
    }
}
