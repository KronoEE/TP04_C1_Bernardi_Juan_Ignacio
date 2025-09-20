using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPauseMenu : MonoBehaviour
{
    [Header("Pause Menu References")]
    [SerializeField] private Button btnResume;
    [SerializeField] private Button btnSettings;
    [SerializeField] private Button btnExit;
    [SerializeField] private Button btnOptionsBack;
    [SerializeField] private Button btnMainMenu;


    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject panelSettings;
    

    bool isPaused = true;

    private void Awake()
    {
        // Pause Menu Buttons
        btnResume.onClick.AddListener(OnResumeClicked);
        btnSettings.onClick.AddListener(OnOptionsClicked);
        btnExit.onClick.AddListener(OnExitClicked);
        btnMainMenu.onClick.AddListener(OnMainMenuClicked);

        btnOptionsBack.onClick.AddListener(OnOptionsBackClicked);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
            panelPause.SetActive(isPaused);
        }
    }

    private void OnDestroy()
    {
        // Pause Menu
        btnResume.onClick.RemoveAllListeners();
        btnSettings.onClick.RemoveAllListeners();
        btnExit.onClick.RemoveAllListeners();
        btnOptionsBack.onClick.RemoveAllListeners();
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    private void OnResumeClicked()
    {
        TogglePause();
        panelPause.SetActive(false);
    }


    private void OnOptionsClicked()
    {
        panelSettings.SetActive(true);
        panelPause.SetActive(false);
    }

    private void OnExitClicked()
    {
        Application.Quit();
    }
    private void OnOptionsBackClicked()
    {
        panelSettings.SetActive(false);
        panelPause.SetActive(true);
    }

    private void OnMainMenuClicked()
    {
        GameManager.Instance.BackToMenu();
        Time.timeScale = 1f;
    }


}