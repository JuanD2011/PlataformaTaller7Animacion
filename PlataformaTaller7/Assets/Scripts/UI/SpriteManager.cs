using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    [SerializeField] ButtonsManager buttonsManager = null;

    private Sprite[] profileSprites = null;

    private readonly string path = "Sprites";

    public static event Delegates.Action<Sprite> OnSpriteUpdated = null;

    private void Awake()
    {
        OnSpriteUpdated = null;

        profileSprites = Resources.LoadAll<Sprite>(path);
    }

    private void Start()
    {
        LogInManager.OnLoggedIn += SetFirstProfileSprite;

        if (UsersDatabase.CurrentUser != null) SetFirstProfileSprite(true);
    }

    private void SetFirstProfileSprite(bool _LoggedIn)
    {
        if (!_LoggedIn) return;

        buttonsManager.InitializeFirstButton(int.Parse(UsersDatabase.CurrentUser.sprite.name));
    }

    /// <summary>
    /// Update sprite 
    /// </summary>
    /// <param name="_Index"></param>
    public void ChangeSprite(int _Index)
    {
        UsersDatabase.CurrentUser.sprite = profileSprites[_Index];
        OnSpriteUpdated(profileSprites[_Index]);
    }
}
