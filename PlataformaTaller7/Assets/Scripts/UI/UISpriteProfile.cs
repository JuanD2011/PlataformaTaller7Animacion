using UnityEngine;
using UnityEngine.UI;

public class UISpriteProfile : MonoBehaviour
{
    private Image m_Image = null;

    private void Awake()
    {
        m_Image = GetComponent<Image>();
    }

    private void Start()
    {
        SpriteManager.OnSpriteUpdated += UpdateImageSprite;

        LogInManager.OnLoggedIn += UpdateImageSprite;
    }

    private void UpdateImageSprite(bool _LoggedIn)
    {
        if (!_LoggedIn) return;

        m_Image.sprite = UsersDatabase.CurrentUser.sprite;
    }

    private void UpdateImageSprite(Sprite _Sprite)
    {
        m_Image.sprite = _Sprite;
    }
}
