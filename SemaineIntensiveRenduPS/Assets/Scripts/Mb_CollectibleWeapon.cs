using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mb_CollectibleWeapon : MonoBehaviour

{
    public Sc_CanonsPart[] weaponAvaible;
    [HideInInspector] public Sc_CanonsPart weaponToAdd;
    public Mb_Poolable me;


    private void Awake()
    {
        int randomWeapon = Random.Range(0, weaponAvaible.Length - 1);
        weaponToAdd = weaponAvaible[randomWeapon];
    }
    private void OnTriggerEnter(Collider other)
    {
        Mb_CharacterControler player = other.GetComponent<Mb_CharacterControler>();
        if (player == true)
        {
            player.weapons.Add(weaponToAdd);
            player.AddWeapon();
            Mb_PoolManager.PoolManager.DecallItem(me);
        }
    }

}
