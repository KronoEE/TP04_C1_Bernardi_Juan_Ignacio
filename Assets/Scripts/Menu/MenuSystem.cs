using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSystem : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject menuPanel;

    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnSettings;
    [SerializeField] private Button btnQuit;
    [SerializeField] private Button btnBack;

    private void Awake()
    {
        btnPlay.onClick.AddListener(OnPlayClicked);
        btnSettings.onClick.AddListener(OnSettingsClicked);
        btnQuit.onClick.AddListener(OnQuitClicked);
        btnBack.onClick.AddListener(OnbtnBackClicked);
    }


    private void OnDestroy()
    {
        btnPlay.onClick.RemoveAllListeners();
        btnSettings.onClick.RemoveAllListeners();
        btnQuit.onClick.RemoveAllListeners();
        btnBack.onClick.RemoveAllListeners();
    }
    private void OnPlayClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnSettingsClicked()
    {
        settingsPanel.SetActive(true);
    }

    private void OnQuitClicked()
    {
        Application.Quit();
    }

    private void OnbtnBackClicked()
    {
        settingsPanel.SetActive(false);
    }
}
