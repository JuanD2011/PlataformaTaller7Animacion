using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer = null;
    [SerializeField] Settings settings = null;
    [SerializeField] Image m_Image = null;
    [SerializeField] private Color disabledColor = Color.white;

    private readonly float mutedVolume = -80f;

    /// <summary>
    /// Initialize the mixer
    /// </summary>
    public void Init()
    {
         if (!settings.isMasterActive) audioMixer.SetFloat("MasterVol", mutedVolume);
    }

    /// <summary>
    /// Function to mute audio
    /// </summary>
    public void MuteAudio()
    {
        float value = 0f;

        audioMixer.GetFloat("MasterVol", out value);

        if (value > mutedVolume)
        {
            audioMixer.SetFloat("MasterVol", mutedVolume);
            settings.isMasterActive = false;
        }
        else if (value <= mutedVolume)
        {
            settings.isMasterActive = true;
            audioMixer.SetFloat("MasterVol", 0f);
        }
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if (settings.isMasterActive)
        {
            m_Image.color = Color.white;
        }
        else
        {
            m_Image.color = disabledColor;
        }
    }
}