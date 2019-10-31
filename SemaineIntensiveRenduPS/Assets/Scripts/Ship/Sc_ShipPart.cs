using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewShipPart", menuName = "ShipPersonalisation/NewShipPart", order = 100)]
public class Sc_ShipPart : ScriptableObject
{
    public AllModifier partCharacteristics;
}

[System.Serializable]
public struct AllModifier
{
    public float speedModifier, DashCooldownModifier, DashRangeModifier;
}

