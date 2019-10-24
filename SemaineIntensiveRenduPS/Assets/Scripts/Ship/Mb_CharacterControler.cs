using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mb_CharacterControler : MonoBehaviour
{
    [Header("BasicParameters")]
    public Sc_ShipCharacteristics shipCharacteritics;
 

    private bool canDash=true;
    private Vector3 desiredposition;
    private Vector3 velocity = Vector3.zero;
    private List<bool> weaponCanShoot = new List<bool>(0); 

    private void Awake()
    {
        for (int i = 0; i < shipCharacteritics.weapons.Count; i++)
        {
            weaponCanShoot.Add(true);
        }
    }
    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, desiredposition,ref velocity, 0.2f);

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
       if (desiredposition.x < Sc_GameOptions.maxX && Input.GetAxis("Horizontal")>0)
            desiredposition += new Vector3(Input.GetAxis("Horizontal") * shipCharacteritics.totalShipSpeed* Time.deltaTime, 0, 0);
       else if (desiredposition.x > -Sc_GameOptions.maxX && Input.GetAxis("Horizontal") < 0)
            desiredposition += new Vector3(Input.GetAxis("Horizontal") * shipCharacteritics.totalShipSpeed * Time.deltaTime, 0, 0);

        if (desiredposition.z < Sc_GameOptions.maxZ && Input.GetAxis("Vertical") > 0)
            desiredposition += new Vector3(0, 0, Input.GetAxis("Vertical") * shipCharacteritics.totalShipSpeed * Time.deltaTime);
       else if (desiredposition.z > -Sc_GameOptions.maxZ && Input.GetAxis("Vertical") < 0)
            desiredposition += new Vector3(0, 0, Input.GetAxis("Vertical") * shipCharacteritics.totalShipSpeed * Time.deltaTime);
    }
    
    void Shoot()
    {
        for (int i = 0; i < shipCharacteritics.weapons.Count; i++)       
        {
            if (weaponCanShoot[i] == true)
            {
                for (int j = 0; j < shipCharacteritics.weapons[i].shootOrigin.Length; j++)
                {
                    Mb_PoolManager.PoolManager.CallItem( Mb_Poolable.poolableTag.bullet , transform.position + shipCharacteritics.weapons[i].shootOrigin[j].positionTowardShip,  shipCharacteritics.weapons[i].shootOrigin[j].rotationTowardShip);
                    shipCharacteritics.weapons[i].projectile.damages = shipCharacteritics.weapons[i].damages;
                } 
                weaponCanShoot[i] = false;
                StartCoroutine(ShootCooldown(shipCharacteritics.weapons[i].delayBetweenShots, i));
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
        StartCoroutine(DashCooldown());
    }
    IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(shipCharacteritics.totalDashCooldown);
        canDash = true;
    }
}

