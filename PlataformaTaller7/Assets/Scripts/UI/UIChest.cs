using UnityEngine;
using UnityEngine.UI;

public class UIChest : MonoBehaviour
{
    [SerializeField] private Animator chestsAnimator = null, questionAnimator = null;

    private Button m_Button = null;

    private readonly string openState = "Chest Open";

    private Animator m_Animator = null; 

    private void Awake()
    {
        m_Button = GetComponent<Button>();
        m_Animator = GetComponent<Animator>();
    }

    private void Start()
    {
        m_Button.onClick.AddListener(() => ChestClicked());
    }

    private void ChestClicked()
    {
        m_Animator.Play(openState);
        AudioManager.instance.PlaySFx(AudioManager.instance.audioClips.chest, 1f, false);
    }

    /// <summary>
    /// Called by animation event
    /// </summary>
    public void AnimationOver()
    {
        chestsAnimator.Play("Popup Window Out");
        questionAnimator.Play("Popup Window In");
    }
}
