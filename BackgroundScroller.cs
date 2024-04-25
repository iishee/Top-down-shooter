using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 1.0f;
    public Texture2D backgroundTexture;

    private Material material;
    private Vector2 offset;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
        material.mainTexture = backgroundTexture;
        offset = new Vector2(scrollSpeed, 0);
    }

    private void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}