using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject newgameMenuUI; // R�f�rence au panneau du menu options
    public GameObject settingsMenuUI; // R�f�rence au panneau du menu new game
    public GameObject[] HUDElements; // Tableau des �l�ments du HUD � cacher

    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    public void OpenNewGame()
    {
        // Affichez le menu choix perso
        newgameMenuUI.SetActive(true);

        // Cachez les �l�ments du HUD
        foreach (GameObject element in HUDElements)
        {
            element.SetActive(false);
        }
    }

    public void OpenSettings()
    {
        // Affichez le menu settings
        settingsMenuUI.SetActive(true);

        // Cachez les �l�ments du HUD
        foreach (GameObject element in HUDElements)
        {
            element.SetActive(false);
        }
    }

    public void CloseSettings()
    {
        // Cachez le menu settings
        settingsMenuUI.SetActive(false);

        // Affichez les �l�ments du HUD
        foreach (GameObject element in HUDElements)
        {
            element.SetActive(true);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMasterVolume();
            SetMusicVolume();
            SetSfxVolume();
        }
    }

    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        myMixer.SetFloat("master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSfxVolume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    private void LoadVolume()
    {
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("sfxVolume");

        SetMasterVolume();
        SetMusicVolume();
        SetSfxVolume();
    }

    public void OpenCredit()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Quit()
    {
        Application.Quit();
    }
}