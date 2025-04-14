using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrusters : MonoBehaviour
{
    [SerializeField] float animationDelay;
    [SerializeField] List<Sprite> spriteList;
    private float animTimer;
    private SpriteRenderer spriteRenderer;
    private Sprite[] sprites;
    private int currentIndex;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sprites = spriteList.ToArray();
        currentIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        animTimer += Time.deltaTime;
        if (animTimer % animationDelay < Time.deltaTime)
        {
            currentIndex++;
            if (currentIndex >= sprites.Length)
                currentIndex = 0;

            spriteRenderer.sprite = sprites[currentIndex];
        }
    }
}
