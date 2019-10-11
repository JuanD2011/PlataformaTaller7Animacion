using UnityEngine;

[CreateAssetMenu(fileName = "AudioClips", menuName = "AudioClips")]
public class AudioClips : ScriptableObject
{
    [Header("Music")]
    public AudioClip menu = null;
    public AudioClip ladder = null;
    public AudioClip minigame = null;

    [Header("UI")]
    public AudioClip defaultButton = null;
    public AudioClip acceptButton = null;
    public AudioClip cancelButton = null;
    public AudioClip notificationAlert = null;

    
    [Header("Gameplay")]
    public AudioClip victory = null;
    public AudioClip lose = null;
}