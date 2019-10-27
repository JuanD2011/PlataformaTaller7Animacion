using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] buttons = new GameObject[1];

    [SerializeField]
    private int currentbuttonIndex = 0;

    protected Animator[] buttonsAnimator = new Animator[0];

    [SerializeField]
    private string buttonFadeIn = "B Fade-in";

    [SerializeField]
    private string buttonFadeOut = "B Fade-out";

    [SerializeField]
    private bool initFirstButton = true;

    private void Awake()
    {
        buttonsAnimator = new Animator[buttons.Length];
        for (int i = 0; i < buttonsAnimator.Length; i++) buttonsAnimator[i] = buttons[i].GetComponent<Animator>();
    }

    protected virtual void Start()
    {
        if (initFirstButton)
        {
            InitializeFirstButton(currentbuttonIndex); 
        }
    }

    public void InitializeFirstButton(int _Index)
    {
        currentbuttonIndex = _Index;
        buttonsAnimator[currentbuttonIndex].Play(buttonFadeIn);
    }

    /// <summary>
    /// Animate buttons
    /// </summary>
    /// <param name="_NewButtonIndex"></param>
    public void ButtonAnim(int _NewButtonIndex)
    {
        if (_NewButtonIndex != currentbuttonIndex)
        {
            buttonsAnimator[currentbuttonIndex].Play(buttonFadeOut);
            currentbuttonIndex = _NewButtonIndex;
            buttonsAnimator[currentbuttonIndex].Play(buttonFadeIn);
        }
    }
}
