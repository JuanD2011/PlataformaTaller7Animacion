using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Settings")]
public class Settings : ScriptableObject
{
    [Header("Configuration Settings")]
    public bool isMasterActive = false;
}
