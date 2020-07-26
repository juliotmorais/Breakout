﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int breakableBlocks;
    SceneLoader sceneloader;


    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }


    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }
    public void MinusBeakableBlocks()
    {
        breakableBlocks--;
        if (breakableBlocks == 0)
        {
            sceneloader.LoadNextScene();
        }
    }

}
