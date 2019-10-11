using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField]
    private MusicType musicType = MusicType.None;

    private void Start()
    {
        PlayMusic(musicType);
    }

    public void PlayMusic(MusicType _MusicType)
    {
        switch (_MusicType)
        {
            case MusicType.Menu:
                AudioManager.instance.PlayMusic(AudioManager.instance.audioClips.menu, 0.45f, 1f, 1f);
                break;
            case MusicType.Ladder:
                AudioManager.instance.PlayMusic(AudioManager.instance.audioClips.ladder, 0.45f, 1f, 1f);
                break;
            case MusicType.Minigame:
                AudioManager.instance.PlayMusic(AudioManager.instance.audioClips.minigame, 0.45f, 1f, 1f);
                break;
            case MusicType.None:
                break;
            default:
                break;
        }
    }
}
