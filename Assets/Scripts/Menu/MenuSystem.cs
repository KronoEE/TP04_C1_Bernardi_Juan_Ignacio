using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSystem : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnQuit;

    private void Awake()
    {
        btnPlay.onClick.AddListener(OnPlayClicked);
        btnQuit.onClick.AddListener(OnPlayClicked);
    }



    private void OnPlayClicked()
    {
        Play();
        Quit();
    }

    private void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Quit()
    {
        Application.Quit();
    }

}
