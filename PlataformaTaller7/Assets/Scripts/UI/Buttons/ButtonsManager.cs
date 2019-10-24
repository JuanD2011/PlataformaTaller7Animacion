using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] buttons = new GameObject[1];

    [SerializeField]
    private int currentbuttonIndex = 0;

    protected Animator[] buttonsAnimator = new Animator[0];

    private readonly string buttonFadeIn = "B Fade-in";
    private readonly string buttonFadeOut = "B Fade-out";

    private void Awake()
    {
        buttonsAnimator = new Animator[buttons.Length];
        for (int i = 0; i < buttonsAnimator.Length; i++) buttonsAnimator[i] = buttons[i].GetComponent<Animator>();
    }

    protected virtual void Start()
    {
        InitializeFirstButton(currentbuttonIndex);
    }

    private void InitializeFirstButton(int _Index)
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
