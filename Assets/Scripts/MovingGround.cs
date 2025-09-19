using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{
    private float spriteWidth;
    void Start()
    {
        // Getting the width of the BoxCollider2D attached to the ground GameObject and setting spritewidth variable to that value
        BoxCollider2D groundCollider = GetComponent<BoxCollider2D>();
        spriteWidth = groundCollider.size.x;
    }

    void Update()
    {
        // If the ground's x position is less than negative spriteWidth, move it to the right by spriteWidth * 2, so it appears to be always generating
        if (transform.position.x < -spriteWidth)
        {
            transform.Translate(Vector2.right * spriteWidth * 2);
        }
    }
}
