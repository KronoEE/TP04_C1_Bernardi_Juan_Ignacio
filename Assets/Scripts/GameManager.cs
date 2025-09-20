using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float initialScrollingSpeed;
    [SerializeField] private TMP_Text invincibleTimerText;

    public bool isDead = false;
    public bool isInvincible = false;
    private float invincibleDuration = 3f;
    public int Health = 3;
    private int score;
    private float scoreTimer;
    private float scrollingSpeed;
    public static GameManager Instance { get; private set; }
    public HealthManager healthManager;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        UpdateScore();
        UpdateSpeed();

    }
    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    private void UpdateScore()
    {
        int scorePerSeconds = 10;

        scoreTimer += Time.deltaTime;
        score = (int)(scoreTimer * scorePerSeconds);
        scoreText.text = string.Format("{0:0000}", score);
    }

    public float GetScrollingSpeed()
    {
        return scrollingSpeed;
    }

    private void UpdateSpeed()
    {
        float speedDivider = 10f;
        scrollingSpeed = initialScrollingSpeed + scoreTimer / speedDivider;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void DecreaseHealth()
    {
        Health--;

        if (Health < 0)
            Health = 0;

        healthManager.UpdateHearts(Health);

        if (Health <= 0)
        {
            isDead = true;
            ShowGameOverScreen();
            Time.timeScale = 0f;
        }
    }

    public void IncreaseHealth()
    {
        Health++;
        healthManager.UpdateHearts(Health);
    }

    public void SetInvincible()
    {
        if (!isInvincible)
        {
            StartCoroutine(InvincibilityCoroutine());
        }
    }
   private IEnumerator InvincibilityCoroutine()
{
    isInvincible = true;

    float timer = invincibleDuration;

    while (timer > 0f)
    {
        // Mostrar tiempo con 1 decimal
        if (invincibleTimerText != null)
            invincibleTimerText.text = "Invincible: " + timer.ToString("F1") + "s";

        timer -= Time.deltaTime;
        yield return null;
    }

    // Reset UI cuando termina
    if (invincibleTimerText != null)
        invincibleTimerText.text = "";

    isInvincible = false;
}

    public bool IsInvincible()
    {
        return isInvincible;
    }

}
