﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detele : MonoBehaviour
{
    public GameObject[] heroes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < 5; i++)
            {
                Destroy(heroes[i]);
            }
        }
    }
}
