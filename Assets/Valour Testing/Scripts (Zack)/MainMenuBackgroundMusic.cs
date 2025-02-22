﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBackgroundMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private static MainMenuBackgroundMusic instance = null;
    public static MainMenuBackgroundMusic Instance
    {
        get { return instance; }
    }

    // Update is called once per frame
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);

    }
}
