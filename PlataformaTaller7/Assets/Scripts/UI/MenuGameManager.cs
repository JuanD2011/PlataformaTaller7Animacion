using UnityEngine;

public class MenuGameManager : MonoBehaviour
{
    private SettingsTabManager settingsTabManager = null;

    [SerializeField]
    private Animator chestAnimator = null;

    private void Awake()
    {
        settingsTabManager = GetComponent<SettingsTabManager>();
    }

    private void Start()
    {
        LadderManager.Manager.Character.OnReachDestination += ActiveQuestionPanel;
    }

    private void ActiveQuestionPanel(BoxType _boxType)
    {
        settingsTabManager.ModalAnim(true);
        chestAnimator.Play("Popup Window In");
    }
}
