using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mb_PoolReseter : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Mb_Poolable itemToReset = other.GetComponent<Mb_Poolable>();

        if (itemToReset != null)
        {
            Mb_PoolManager.PoolManager.DecallItem(itemToReset);
        }
    }

}
