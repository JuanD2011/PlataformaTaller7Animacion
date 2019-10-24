using UnityEngine;

public class SideAttributesManager : MonoBehaviour
{
    [SerializeField]
    private byte manHairstyle = 0, womanHairstyle = 0, manUniform = 0, womanUniform = 0, manAccessories = 0, womanAccessories = 0;

    private SettingsTabManager settingsTabManager = null;

    private byte panelIndex = 0;

    private Animator m_Animator = null;

    private readonly string slideOut = "Slide Out";
    private readonly string slideIn = "Slide In";

    private bool isIn = false;
    private int slideIndex = -1;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        settingsTabManager = GetComponent<SettingsTabManager>();
    }

    public void SlideAnim(int _Index)
    {
        if (slideIndex == _Index)
        {
            if (isIn)
            {
                m_Animator.Play(slideOut);
                isIn = false;
            }
            else
            {
                m_Animator.Play(slideIn);
                isIn = true;
            }
        }
        else
        {
            slideIndex = _Index;
            m_Animator.Play(slideIn);
            isIn = true;
        }
    }

    public void SlideOut()
    {
        m_Animator.Play(slideOut);
        isIn = false;
    }

    /// <summary>
    /// Update current panel when the genre has changed
    /// </summary>
    public void UpdatePanelOnGenreChanged()
    {
        switch (slideIndex)
        {
            case 0:
                if (isIn)
                {
                    HairstylePanelAnim(); 
                }
                break;
            case 1:
                if (isIn)
                {
                    UniformPanelAnim(); 
                }
                break;
            case 2:
                if (isIn)
                {
                    AccessoriesPanelAnim(); 
                }
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Active hairstyle panel depending on users genre
    /// </summary>
    public void HairstylePanelAnim()
    {
        if (UsersDatabase.CurrentUser.properties.male)
        {
            settingsTabManager.PanelAnim(manHairstyle); 
            panelIndex = manHairstyle;
        }
        else
        {
            settingsTabManager.PanelAnim(womanHairstyle);
            panelIndex = womanHairstyle;
        }
    }

    /// <summary>
    /// Active uniform panel depending on users genre
    /// </summary>
    public void UniformPanelAnim()
    {
        if (UsersDatabase.CurrentUser.properties.male)
        {
            settingsTabManager.PanelAnim(manUniform);
            panelIndex = manUniform;
        }
        else
        {
            settingsTabManager.PanelAnim(womanUniform);
            panelIndex = womanUniform;
        }
    }

    /// <summary>
    /// Active accessories panel depending on users genre
    /// </summary>
    public void AccessoriesPanelAnim()
    {
        if (UsersDatabase.CurrentUser.properties.male)
        {
            settingsTabManager.PanelAnim(manAccessories);
            panelIndex = manAccessories;
        }
        else
        {
            settingsTabManager.PanelAnim(womanAccessories);
            panelIndex = womanAccessories;
        }
    }
}
