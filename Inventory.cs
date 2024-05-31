using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] internal List<Button> buttons;

    [SerializeField] protected GameObject button;
    [SerializeField] protected List<Transform> buttonsTransforms;

    [SerializeField] protected int transformIndex = 1;
    [SerializeField] internal List<int> indexes;

    protected PlayerAttack player;
}
