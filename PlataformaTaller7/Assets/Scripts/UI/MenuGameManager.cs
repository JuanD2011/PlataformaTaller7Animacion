using UnityEngine;

public class MenuGameManager : MonoBehaviour
{
    private SettingsTabManager settingsTabManager = null;

    [SerializeField]
    private Animator chestAnimator = null;

    [SerializeField]
    private Animator victoryAnimation = null;

    private void Awake()
    {
        settingsTabManager = GetComponent<SettingsTabManager>();
    }

    private void Start()
    {
        LadderManager.Manager.Character.OnReachDestination += ActiveQuestionPanel;
        //Receive win condition
    }

    private void ActiveQuestionPanel(BoxType _boxType)
    {
        settingsTabManager.ModalAnim(true);
        chestAnimator.Play("Popup Window In");
    }

    private void ActiveVictoryPanel()
    {
        settingsTabManager.ModalAnim(true);
        victoryAnimation.Play("Popup Window In");
    }
}
