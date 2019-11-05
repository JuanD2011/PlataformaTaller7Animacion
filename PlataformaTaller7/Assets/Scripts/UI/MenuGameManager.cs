using UnityEngine;

public class MenuGameManager : MonoBehaviour
{
    private SettingsTabManager settingsTabManager = null;

    [SerializeField]
    private Animator chestAnimator = null;

    [SerializeField]
    private Animator victoryAnimation = null;

    private bool showVictoryPanel = false;

    private void Awake()
    {
        settingsTabManager = GetComponent<SettingsTabManager>();
    }

    private void Start()
    {
        LadderManager.Manager.Character.OnReachDestination += ActiveQuestionPanel;
        LadderManager.Manager.OnGameOver += () => showVictoryPanel = true;
    }

    /// <summary>
    /// Show victory panel
    /// </summary>
    public void VerifyVictory()
    {
        if (!showVictoryPanel) return;

        AudioManager.instance.StopByClip(AudioManager.instance.audioClips.minigame);
        AudioManager.instance.PlaySFx(AudioManager.instance.audioClips.victory, 0.7f, false);
        settingsTabManager.ModalAnim(true);
        victoryAnimation.Play("Popup Window In");
    }

    private void ActiveQuestionPanel(BoxType _boxType)
    {
        settingsTabManager.ModalAnim(true);
        chestAnimator.Play("Popup Window In");
    }
}
