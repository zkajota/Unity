﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPC")]
public class NPC_Base : ScriptableObject
{

    public new string name;
    public int id;
    public string[] npcType;
}
