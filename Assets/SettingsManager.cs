using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel; // Reference to the settings panel GameObject

    [SerializeField] private AudioMixer NewAudioMixer;
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    public TMPro.TMP_Dropdown resolutionDropdown;


    Resolution[] resolutions;



    private void Start()
    {
        LoadSettings();
        //resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetMasterVolume(float masterSlider)
    {
        NewAudioMixer.SetFloat("Master", Mathf.Log10(masterSlider) * 20);
        NewAudioMixer.SetFloat("Music", Mathf.Log10(masterSlider) * 20);
        NewAudioMixer.SetFloat("SFX", Mathf.Log10(masterSlider) * 20);
        PlayerPrefs.SetFloat("Master", masterSlider);
        PlayerPrefs.Save();

    }

    public void SetMusicVolume(float musicSlider)
    {
        NewAudioMixer.SetFloat("Music", Mathf.Log10(musicSlider) * 20);
        PlayerPrefs.SetFloat("Music", musicSlider);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float sfxSlider)
    {
        NewAudioMixer.SetFloat("SFX", Mathf.Log10(sfxSlider) * 20);
        PlayerPrefs.SetFloat("SFX", sfxSlider);
        PlayerPrefs.Save();
    }

    public void CloseSettingsPanel()
    {
        // Deactivate the settings panel
        settingsPanel.SetActive(false);
    }

    public void OpenSettingsPanel()
    {
        // Activate the settings panel
        settingsPanel.SetActive(true);
    }

    private void LoadSettings()
    {
        resolutions = Screen.resolutions;

        float masterVolume = PlayerPrefs.GetFloat("Master", 1f);
        masterVolumeSlider.value = masterVolume;
        SetMasterVolume(masterVolume);

        float musicVolume = PlayerPrefs.GetFloat("Music", 1f);
        musicVolumeSlider.value = musicVolume;
        SetMusicVolume(musicVolume);

        float sfxVolume = PlayerPrefs.GetFloat("SFX", 1f);
        sfxVolumeSlider.value = sfxVolume;
        SetSFXVolume(sfxVolume);

        int savedResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", Screen.resolutions.Length - 1);
        SetResolution(savedResolutionIndex);

        bool savedFullscreen = PlayerPrefs.GetInt("Fullscreen", Screen.fullScreen ? 1 : 0) == 1;
        SetFullScreen(savedFullscreen);
    }

    public void SetQuality(string quality)
    {
        switch (quality)
        {
            case "High":
                QualitySettings.SetQualityLevel(2);
                break;
            case "Med":
                QualitySettings.SetQualityLevel(1);
                break;
            case "Low":
                QualitySettings.SetQualityLevel(0);
                break;
            default:
                Debug.LogError("Invalid quality setting.");
                break;
        }

    }

        public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
        PlayerPrefs.Save();
    }
}