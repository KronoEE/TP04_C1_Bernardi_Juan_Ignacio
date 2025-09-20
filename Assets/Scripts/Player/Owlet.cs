using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owlet : MonoBehaviour
{
    [SerializeField] private float upForce = 750f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float radius;
    private Rigidbody2D rb;
    private Animator owlerAnimator;

    public PlayerSoundController playerSoundController;
    public AudioManager audioManager;
    public ParticleSystem jumpParticle;
    void Start()
    {
        // Getting the Rigidbody2D component attached to the Owlet GameObject
        rb = GetComponent<Rigidbody2D>();
        owlerAnimator = GetComponent<Animator>();

    }


    void Update()
    {
        bool bisGrounded = Physics2D.OverlapCircle(groundCheck.position, radius, ground);
        owlerAnimator.SetBool("bisGrounded", bisGrounded);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bisGrounded)
            {
                CrateJumpParticle();
                playerSoundController.playJumpSound();
                rb.AddForce(Vector2.up * upForce);
            }
        }

    }
    void CrateJumpParticle()
    {
        jumpParticle.Play();
    }

    // Detecting collision with obstacles
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (GameManager.Instance.isInvincible)
            {
                return;
            }
            if (GameManager.Instance.isDead == false)
            {
                GameManager.Instance.DecreaseHealth();
                Destroy(collision.gameObject);
            }
            if (GameManager.Instance.isDead == true)
            {  
                 // Trigger death animation
                owlerAnimator.SetTrigger("Die");

                // Calling coroutine
                StartCoroutine(WaitAndPause());
            }
            
        }
    }

    private IEnumerator WaitAndPause()
    {
        // Wait for 0.5 seconds
        yield return new WaitForSecondsRealtime(0.5f);

        // Play death sound
        playerSoundController.playDeathSound();

        // Show Game Over screen
        GameManager.Instance.ShowGameOverScreen();

        audioManager.Stop();

        // Pause the game
        Time.timeScale = 0f;
    }
    

}
