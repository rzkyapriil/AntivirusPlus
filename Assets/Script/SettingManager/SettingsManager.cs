using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SettingsManager : MonoBehaviour 
{
    // Video
    public TMP_Dropdown qualityDropdown;
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    Resolution[] resolutions;

    // Music
    public AudioMixer audioMixer;
    const string MIXER_MUSIC = "musicVolume";
    const string MIXER_SOUND = "soundVolume";
    const string MIXER_MASTER = "masterVolume";
    bool mutedMusic;
    bool mutedSound;
    bool mutedMaster;
    float volumeMusic = 1;
    float volumeSound = 1;
    float volumeMaster = 1;

    private void Start()
    {
        // Fullscreen Start
        fullscreenToggle.isOn = Screen.fullScreen;

        // Quality Start
        qualityDropdown.value = QualitySettings.GetQualityLevel();

        // Resolution Start
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " (" + resolutions[i].refreshRate + "Hz)";
            options.Add(option);

            if (resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    private void Update()
    {
        // Debug.Log(Screen.fullScreen);
        //Debug.Log("Music" + volumeMusic);
        //Debug.Log("Sound" + volumeSound);
    }

    // ============================
    //        SETTING IN GAME
    // ============================

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // ============================
    //       SETTING APLIKASI
    // ============================

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    // ============================
    //        SETTING MUSIK
    // ============================
    public void SetMusicVolume(float value)
    {
        if (mutedMusic)
        {
            volumeMusic = value;
            return;
        }
        else
        {
            volumeMusic = value;
            audioMixer.SetFloat(MIXER_MUSIC, Mathf.Log10(volumeMusic) * 20);
        }
    }

    public void SetSoundVolume(float value)
    {
        if (mutedSound)
        {
            volumeSound = value;
            return;
        }
        else
        {
            volumeSound = value;
            audioMixer.SetFloat(MIXER_SOUND, Mathf.Log10(volumeSound) * 20);
        }
    }

    public void SetMasterVolume(float value)
    {
        if (mutedMaster)
        {
            volumeMaster = value;
            return;
        }
        else
        {
            volumeMaster = value;
            audioMixer.SetFloat(MIXER_MASTER, Mathf.Log10(volumeMaster) * 20);
        }
    }

    public void MuteMusicVolume(bool isMuted)
    {
        float localVolume = volumeMusic;

        if (isMuted)
            mutedMusic = isMuted;
        else
            mutedMusic = isMuted;

        localVolume = (isMuted) ? -80 : localVolume;

        audioMixer.SetFloat(MIXER_MUSIC, Mathf.Log10(localVolume) * 20);
    }

    public void MuteSoundVolume(bool isMuted)
    {
        float localVolume = volumeSound;

        if (isMuted)
            mutedSound = isMuted;
        else
            mutedSound = isMuted;

        localVolume = (isMuted) ? -80 : localVolume;

        audioMixer.SetFloat(MIXER_SOUND, Mathf.Log10(localVolume) * 20);
    }

    public void MuteMasterVolume(bool isMuted)
    {
        float localVolume = volumeMaster;

        if (isMuted)
            mutedMaster = isMuted;
        else
            mutedMaster = isMuted;

        localVolume = (isMuted) ? -80 : localVolume;

        audioMixer.SetFloat(MIXER_MASTER, Mathf.Log10(localVolume) * 20);
    }
}
