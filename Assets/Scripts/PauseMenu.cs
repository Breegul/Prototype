using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseUI;
    public GameObject settings;
    private GameObject hud;
    public AudioMixer audioMixer;
    private PlayerLook playerCam;
    public Slider volSlide;
    public Slider senSlide;

    void Start()
    {
        hud = GameObject.Find("UI");
        playerCam = GameObject.Find("Camera").GetComponent<PlayerLook>();
        if(PlayerPrefs.HasKey("volume"))
        {
            Debug.Log("VOLEXISTS");
            volSlide.value = PlayerPrefs.GetFloat("volume");
            SetVolume(PlayerPrefs.GetFloat("volume"));
        }

        if(PlayerPrefs.HasKey("sensitivity"))
        {
            Debug.Log("SENSEXISTS");
            senSlide.value = PlayerPrefs.GetFloat("sensitivity");
            SetSensitivity(PlayerPrefs.GetFloat("sensitivity"));
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        pauseUI.SetActive(true);
        hud.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        hud.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
        if(settings.activeSelf) settings.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.Save();
    }

    public void SetSensitivity(float sensitivity)
    {
        playerCam.sensMod = sensitivity;
        PlayerPrefs.SetFloat("sensitivity", sensitivity);
        PlayerPrefs.Save();
    }
}
