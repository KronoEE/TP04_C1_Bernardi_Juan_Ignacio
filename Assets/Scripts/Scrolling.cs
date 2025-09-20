using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    void Update()
    {
        // Move the background to the left based on scrollSpeed var and Time.deltaTime
        transform.Translate(Vector2.left * GameManager.instance.GetScrollingSpeed() * Time.deltaTime);
    }
}
