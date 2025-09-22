using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    GameObject[] backgrounds;
    Material[] mat;
    float[] backSpeed;

    float distance;

    [Range(0.01f, 0.05f)]
    public float parallaxSpeed = 0.02f; 

    void Start()
    {
        int backCount = transform.childCount;
        mat = new Material[backCount];
        backSpeed = new float[backCount];
        backgrounds = new GameObject[backCount];

        float farthestBack = 0f;

        
        for (int i = 0; i < backCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;

            float depth = Mathf.Abs(backgrounds[i].transform.position.z);
            if (depth > farthestBack)
                farthestBack = depth;
        }

        
        for (int i = 0; i < backCount; i++)
        {
            float depth = Mathf.Abs(backgrounds[i].transform.position.z);
            backSpeed[i] = 1 - (depth / farthestBack);
        }
    }

    void LateUpdate()
    {
        
        float worldSpeed = GameManager.Instance.GetScrollingSpeed();
        distance += worldSpeed * Time.deltaTime;

        for (int i = 0; i < backgrounds.Length; i++)
        {
            float speed = backSpeed[i] * parallaxSpeed;
            mat[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
        }
    }
}