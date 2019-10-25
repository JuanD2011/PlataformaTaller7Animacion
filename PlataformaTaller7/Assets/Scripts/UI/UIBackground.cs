using UnityEngine;
using UnityEngine.UI;

public class UIBackground : MonoBehaviour
{
    [SerializeField] Sprite[] sprites = new Sprite[2];

    private Image m_Image = null;

    private int currentIndex = 0;

    private void Awake()
    {
        m_Image = GetComponent<Image>();
    }

    /// <summary>
    /// Change sprite of the image by the index given.
    /// </summary>
    /// <param name="_Index"></param>
    public void ChangeImage(int _Index)
    {
        if (currentIndex != _Index)
        {
            currentIndex = _Index;
            m_Image.sprite = sprites[currentIndex];  
        }
    }
}
