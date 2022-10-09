using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider sliderMusic;

    public Slider sliderEffects;

    public TextMeshProUGUI textMesMusic;

    public TextMeshProUGUI textMesEffects;

    public float music;

    public float effects;

    void Start()
    {
        if (sliderMusic != null)
        {
            sliderMusic.value = 5;
            sliderEffects.value = 5;
            textMesMusic.text = "5";
            textMesEffects.text = "5";
        }
    }

    void Update()
    {
    }

    public void PlayGame()
    {
        if (PlayerPrefs.GetInt("phaseScene") == 0)
        {
            SceneManager
                .LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs
                .SetInt("phaseScene",
                SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("phaseScene"));
        }
    }

    public void GotToSettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void GotToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextPhase()
    {
        PlayerPrefs
            .SetInt("phaseScene", SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PreviousPhase()
    {
        PlayerPrefs
            .SetInt("phaseScene", SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void MusicVolume()
    {
        music = sliderMusic.value;
        textMesMusic.text = sliderMusic.value.ToString();
    }

    public void SoundEffects()
    {
        effects = sliderEffects.value;
        textMesEffects.text = sliderMusic.value.ToString();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
