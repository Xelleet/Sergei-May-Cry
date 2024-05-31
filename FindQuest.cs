using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FindQuest
{
    public string QuestName;
    public string QuestText;
    public List<GameObject> Targets;
    public float RequiredProgress;
    public float CurrentProgess;
    public bool IsActive;
    public float Currency;
}
