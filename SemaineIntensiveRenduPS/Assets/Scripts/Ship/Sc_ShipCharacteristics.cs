using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewShip", menuName = "ShipPersonalisation/NewShip", order = 100)]
public class Sc_ShipCharacteristics : ScriptableObject
{
   // public Sc_ShipPart[] allShipParts;

    [Header("Fight")]
    public float totalHitPoints;
    public List<Sc_CanonsPart> weapons;


    [Header("Movement")]
    public float totalShipSpeed;
    public float totalDashCooldown;
    public float totalDashRange;

    /*
    public void CalculateNewCharacteristics()
    {
        for (int i = 0; i < allShipParts.Length; i++)
        {
            totalHitPoints += allShipParts[i].partCharacteristics.hitPointModifier;
            totalShipSpeed += allShipParts[i].partCharacteristics.DashCooldownModifier;
            totalDashCooldown += allShipParts[i].partCharacteristics.DashCooldownModifier;
            totalDashRange += allShipParts[i].partCharacteristics.DashRangeModifier;
        }
    }*/
}
