using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owlet : MonoBehaviour
{
    [SerializeField] private float upForce = 750f;
    private Rigidbody2D rb;
    void Start()
    {
        // Getting the Rigidbody2D component attached to the Owlet GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
             rb.AddForce(Vector2.up * upForce);
        }
       
    }
}
