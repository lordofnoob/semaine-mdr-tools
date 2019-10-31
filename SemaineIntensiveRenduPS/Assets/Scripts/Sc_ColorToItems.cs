using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "NewColorToItem", menuName = "Ld/NewColorToItem", order = 101)]
public class Sc_ColorToItems : ScriptableObject
{
    public Color colorToTraduce;
    public Mb_Poolable.poolableTag itemTospawn;
}
