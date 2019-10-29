using UnityEngine;

public class SettingsTabManager : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] panels = new GameObject[0];

    protected Animator[] panelAnimators = new Animator[0];

    [SerializeField]
    private int currentPanelIndex = 0;

    [SerializeField]
    private bool outIfTheSameIndex = true;

    [SerializeField]
    private bool initFirstPanel = true;

    private readonly string panelFadeIn = "MP Fade-in";
    private readonly string panelFadeOut = "MP Fade-out";
    private readonly string panelFadeInStart = "MP Fade-in Start";

    public readonly string panelModalIn = "MP Modal In";
    public readonly string panelModalOut = "MP Modal Out";

    protected virtual void Awake()
    {
        InitializePanelAnimators();
    }

    protected virtual void Start()
    {
        if (initFirstPanel)
        {
            InitializeFirstPanel(currentPanelIndex); 
        }
    }

    /// <summary>
    /// Initialize first panel animation
    /// </summary>
    /// <param name="_Index"></param>
    public void InitializeFirstPanel(int _Index)
    {
        currentPanelIndex = _Index;
        panelAnimators[currentPanelIndex].Play(panelFadeInStart);
    }

    protected void InitializePanelAnimators()
    {
        panelAnimators = new Animator[panels.Length];
        for (int i = 0; i < panelAnimators.Length; i++) panelAnimators[i] = panels[i].GetComponent<Animator>();
    }

    /// <summary>
    /// Fade out the current panel and fade in the panel provided by _newPanelIndex
    /// </summary>
    /// <param name="_newPanelIndex"></param>
    public void PanelAnim(int _newPanelIndex)
    {
        if (outIfTheSameIndex)
        {
            panelAnimators[currentPanelIndex].Play(panelFadeOut);
            currentPanelIndex = _newPanelIndex;
            panelAnimators[currentPanelIndex].Play(panelFadeIn);
        }
        else
        {
            StartCoroutine(PanelIn(_newPanelIndex));
        }
    }

    System.Collections.IEnumerator PanelIn(int _newPanelIndex)
    {
        panelAnimators[currentPanelIndex].Play(panelFadeOut);
        yield return new WaitUntil(() =>panelAnimators[currentPanelIndex].GetCurrentAnimatorStateInfo(0).IsName(panelFadeOut));
        currentPanelIndex = _newPanelIndex;
        panelAnimators[currentPanelIndex].Play(panelFadeIn);
    }

    /// <summary>
    /// Set current panel animation depending on the bool
    /// </summary>
    /// <param name="_IsOn"></param>
    public void ModalAnim(bool _IsOn)
    {
        if (_IsOn == true)
        {
            panelAnimators[currentPanelIndex].Play(panelModalOut);
        }
        else
        {
            panelAnimators[currentPanelIndex].Play(panelModalIn);
        }
    }

    /// <summary>
    /// Anim current panel out
    /// </summary>
    public void PanelOut()
    {
        panelAnimators[currentPanelIndex].Play(panelFadeOut);
    }
}
