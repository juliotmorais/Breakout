using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkleVFX;
    [SerializeField] int timesHit = 0;
    [SerializeField] int maxHitsToBreak = 3;
    [SerializeField] Sprite[] blockDamageSprites;


    Level level;
    GameStatus gamestatus;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }


        gamestatus = FindObjectOfType<GameStatus>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (tag == "Breakable")
        {
            timesHit++;
            if (timesHit >= maxHitsToBreak)
            {
                AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
                Destroy(gameObject);
                TriggerSparklesVFX();
                level.MinusBeakableBlocks();
                gamestatus.UpdateScore();
            }
            else
            {
                ShowNextBlockDamageSprite();
            }

        }

    }

    private void ShowNextBlockDamageSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = blockDamageSprites[spriteIndex];
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparkleVFX,transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
