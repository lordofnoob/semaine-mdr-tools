using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "ShipPersonalisation/NewWeapon", order = 100)]
public class Sc_CanonsPart : Sc_ShipPart
{
    public float delayBetweenShots;
    public float damages;
    public Mb_MovingItem projectile;
    public shootOrigin[] shootOrigin;
    public Sc_PatternWay patern;
    public float speedOfBullets;

}

[System.Serializable]
public struct shootOrigin
{
    public Vector3 positionTowardShip;
    public float rotationTowardShip;
   
}
