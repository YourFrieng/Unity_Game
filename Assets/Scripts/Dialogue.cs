﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue //used as a data type
{
    [TextArea(3,10)]
    public string[] sentences;
    public Color npcTextColor;
    public bool[] isPlayerSentence;
    public Color[] colors;
}
