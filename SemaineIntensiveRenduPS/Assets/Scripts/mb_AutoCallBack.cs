using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mb_AutoCallBack : MonoBehaviour
{
    public Mb_Poolable self;

    private void Awake()
    {
        StartCoroutine(waitBeforePool());
    }
    
    IEnumerator waitBeforePool()
    {
        yield return new WaitForSeconds(1);
        Mb_PoolManager.PoolManager.DecallItem(self);
    }
}
