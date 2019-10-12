using UnityEngine;

public class UIQuestion : MonoBehaviour
{
    SettingsTabManager settingsTabManager = null;

    private void Awake()
    {
        settingsTabManager = GetComponent<SettingsTabManager>();
    }

    private void Start()
    {
        LadderManager.Manager.Character.OnReachDestination += PickAQuestion;
    }

    private void PickAQuestion()
    {
        int random = Random.Range(0, 3);

        settingsTabManager.PanelAnim(0);
    }
}
