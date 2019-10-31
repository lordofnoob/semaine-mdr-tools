using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mb_Enemi : Mb_MovingItem
{
    public Sc_CanonsPart[] weapons;
    public float minRandomTimeToShoot;
    public float maxRandomTimeToShoot;
    private List<bool> weaponCanShoot = new List<bool>(0);
    float randomTime;

    public void Awake()
    {
        weaponCanShoot.Clear();
        for (int i = 0; i<weapons.Length; i++)
        {
            weaponCanShoot.Add(true);
        }
        if (isEnemy == true)
        {
            gameObject.layer = 8;
        }
        else
            gameObject.layer = 9;
        Invoke("Shoot", 0.1f);
        Debug.Log(transform.position);
    }


    void Shoot()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weaponCanShoot[i] == true)
            {
                for (int j = 0; j < weapons[i].shootOrigin.Length; j++)
                {
                    Mb_PoolManager.PoolManager.CallItem(Mb_Poolable.poolableTag.bullet,
                    transform.position + weapons[i].shootOrigin[j].positionTowardShip,
                    weapons[i].shootOrigin[j].rotationTowardShip);
                   
                    //application des paramètres du canon sur le MonoBehaviour du projectile
                    weapons[i].projectile.speed = weapons[i].speedOfBullets;
                    weapons[i].projectile.damages = weapons[i].damages;
                    weapons[i].projectile.paternOfMoving =weapons[i].patern;
                    weapons[i].projectile.isEnemy = true;

                   StartCoroutine(DelayToShoot(i));
                }
                weaponCanShoot[i] = false;

              
            }
        }
    }

    void RandomizeTimeToShoot()
    {
        randomTime = Random.Range(minRandomTimeToShoot, maxRandomTimeToShoot);
    }
    
    IEnumerator DelayToShoot(int numberOfTheWeapon)
    {

        yield return new WaitForSeconds(weapons[numberOfTheWeapon].delayBetweenShots + randomTime);
        weaponCanShoot[numberOfTheWeapon] = true;

    }
}
