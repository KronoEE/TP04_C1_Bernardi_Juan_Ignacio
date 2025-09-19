using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIGameOver : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Button btnRestart;

    private void Awake()
    {
        btnRestart.onClick.AddListener(OnPlayClicked);
    }

    private void OnDestroy()
    {
        btnRestart.onClick.RemoveAllListeners();
    }
    private void OnPlayClicked()
    {
        GameManager.instance.RestartGame();
        gameOverScreen.SetActive(false);
    }
}