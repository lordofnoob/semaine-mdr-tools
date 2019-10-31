using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mb_CharacterControler : MonoBehaviour
{
    [Header("BasicParameters")]
    public Sc_ShipCharacteristics shipCharacteritics;
    public List<Sc_CanonsPart> weapons;
    public Mb_LifeManager life;

    private bool canDash=true;
    private Vector3 desiredposition;
    private Vector3 velocity = Vector3.zero;
    private List<bool> weaponCanShoot = new List<bool>(0); 

    private void Awake()
    {
        life.currentLife = shipCharacteritics.totalHitPoints;
        for (int i = 0; i < weapons.Count; i++)
        {
            weaponCanShoot.Add(true);
        }
    }
    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, desiredposition,ref velocity, 0.2f);
        //  desiredposition += new Vector3(0,0,Sc_GameOptions.gameSpeed)*Time.deltaTime;
        if (life.currentLife <= 0)
        {
            Mb_QuickRestart.quickRestart.QuickRestart();
        }

            if (Input.GetButton("Fire1") && canDash)
        {
            Dash();
            if (Input.GetAxis("Fire") > 0)
            {
                Shoot();
            }
        }
        else
        {
            Move();
            if (Input.GetAxis("Fire") > 0)
            {
                Shoot();
            }
        }


     }
    void Move()
    {
       if (desiredposition.x < Sc_GameOptions.sc_GameOptions.maxX && Input.GetAxis("Horizontal")>0)
            desiredposition += new Vector3(Input.GetAxis("Horizontal") * shipCharacteritics.totalShipSpeed* Time.deltaTime, 0, 0);
       else if (desiredposition.x > -Sc_GameOptions.sc_GameOptions.maxX && Input.GetAxis("Horizontal") < 0)
            desiredposition += new Vector3(Input.GetAxis("Horizontal") * shipCharacteritics.totalShipSpeed * Time.deltaTime, 0, 0);

        if (Input.GetAxis("Vertical") > 0 && desiredposition.z<Sc_GameOptions.sc_GameOptions.maxZ )
            desiredposition += new Vector3(0, 0, Input.GetAxis("Vertical") * shipCharacteritics.totalShipSpeed * Time.deltaTime);
       else if (desiredposition.z > -Sc_GameOptions.sc_GameOptions.maxZ && Input.GetAxis("Vertical") < 0)
            desiredposition += new Vector3(0, 0, Input.GetAxis("Vertical") * shipCharacteritics.totalShipSpeed * Time.deltaTime);
    }
    void Shoot()
    {
        for (int i = 0; i < weapons.Count; i++)       
        {
            if (weaponCanShoot[i] == true)
            {
                for (int j = 0; j < weapons[i].shootOrigin.Length; j++)
                {
                    Mb_PoolManager.PoolManager.CallItem( Mb_Poolable.poolableTag.bullet ,
                    transform.position + weapons[i].shootOrigin[j].positionTowardShip,
                    weapons[i].shootOrigin[j].rotationTowardShip);

                    //application des paramètres du canon sur le MonoBehaviour du projectile
                    weapons[i].projectile.speed = weapons[i].speedOfBullets;
                    weapons[i].projectile.damages = weapons[i].damages;
                    weapons[i].projectile.paternOfMoving = weapons[i].patern;
                } 
                weaponCanShoot[i] = false;
                StartCoroutine(ShootCooldown(weapons[i].delayBetweenShots, i));
            }
        }
    }
    IEnumerator ShootCooldown(float delayBetweenShot, int numListe)
    {
        yield return new WaitForSeconds(delayBetweenShot);
        weaponCanShoot[numListe] = true;
    }
    void Dash()
    {
        canDash = false;
        desiredposition = transform.position + new Vector3(shipCharacteritics.totalDashRange* Input.GetAxis("Horizontal"), 0, shipCharacteritics.totalDashRange * Input.GetAxis("Vertical"));
        if (desiredposition.x > 10)
            desiredposition = new Vector3(10, 0, desiredposition.z);
        else if (desiredposition.x < -10)
            desiredposition = new Vector3(-10, 0, desiredposition.z);
        if (desiredposition.z > 10)
            desiredposition = new Vector3(desiredposition.x, 0, 10);
        else if (desiredposition.z < -10)
            desiredposition = new Vector3(-desiredposition.x, 0, -10);

        StartCoroutine(DashCooldown());
    }
    IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(shipCharacteritics.totalDashCooldown);
        canDash = true;
    }

    public void AddWeapon()
    {
        weaponCanShoot.Add(true);
    }
}

