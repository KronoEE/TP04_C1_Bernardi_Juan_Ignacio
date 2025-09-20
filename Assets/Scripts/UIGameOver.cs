using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIGameOver : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Button btnRestart;
    [SerializeField] private Button btnMenu;

    private void Awake()
    {
        btnRestart.onClick.AddListener(OnPlayClicked);
        btnMenu.onClick.AddListener(OnMenuClicked);
    }

    private void OnDestroy()
    {
        btnRestart.onClick.RemoveAllListeners();
        btnMenu.onClick.RemoveAllListeners();
    }
    private void OnPlayClicked()
    {
        GameManager.Instance.RestartGame();
        gameOverScreen.SetActive(false);
    }

    private void OnMenuClicked()
    {
        GameManager.Instance.BackToMenu();
        gameOverScreen.SetActive(false);
    }
}