using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeSpriteOnCreate : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public List<Sprite> spritePool = new List<Sprite>();

    void Start()
    {
        if (spritePool.Count == 0)
            return;

        int randomIndex = Random.Range(0, spritePool.Count);

        spriteRenderer.sprite = spritePool[randomIndex];
    }
}
