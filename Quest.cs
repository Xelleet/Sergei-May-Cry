using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Quest
{
    public string QuestName;
    public string QuestTag;
    public string QuestText;
    //public int Index;
    public List<GameObject> Targets;
    public float RequiredProgress;
    public float CurrentProgess;
    public bool IsActive;
    public float Currency;
}