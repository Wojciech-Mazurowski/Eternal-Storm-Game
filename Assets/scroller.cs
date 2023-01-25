using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scroller : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    public float scrollTime = 10f;
    private float x;
    private float startPosition;
    private float endPosition;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        startPosition = transform.position.x;
        float screenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        endPosition = sr.bounds.size.x - startPosition;
    }

    void Update()
    {
        // x = Mathf.Repeat(Time.time * scrollSpeed, endPosition - startPosition); FOR LOOPING
        x += scrollSpeed * Time.deltaTime;
        if (x >= endPosition) { return; }
        transform.position = new Vector2(startPosition - x, transform.position.y);
    }
}
