using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Settings settings = null;

    private void Awake()
    {
        Memento.LoadData(settings);
    }

    /// <summary>
    /// Save settings
    /// </summary>
    public void SaveSettings()
    {
        Memento.SaveData(settings);
    }

    private void OnApplicationQuit()
    {
        if (settings == null) return;

        Memento.SaveData(settings);
    }
}
