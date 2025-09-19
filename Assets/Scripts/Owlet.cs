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
                rb.AddForce(Vector2.up * upForce);
            }
        }

    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }
}
