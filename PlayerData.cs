using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public Vector3 PlayerPosition;
    public float PlayerCurrency;
    public float PlayerHP;
    public float FAKSCount;
    public List<float> FAKS;
    public float Mana;
    public List<Quest> Quests;
}
