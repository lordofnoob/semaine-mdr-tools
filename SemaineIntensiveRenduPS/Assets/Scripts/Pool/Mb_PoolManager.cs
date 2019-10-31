using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mb_PoolManager : MonoBehaviour
{
    public ItemsToPoolCharacts[] allItemsToPool;

    public static Mb_PoolManager PoolManager;

    public void Awake()
    {
        PoolManager = this;
    }

    public void CallItem( Mb_Poolable.poolableTag objectType, Vector3 position, float Yrotation)
    {
        for (int n = 0; n < allItemsToPool.Length; n++)
        {
            if (objectType == allItemsToPool[n].objectToInstantiate.objectType)
            {
                for (int b = 0; b < allItemsToPool[n].transformOfHisPulling.listOfItem.Count; b++)
                {
                   
                    if (allItemsToPool[n].transformOfHisPulling.listOfItem[b].avaible)
                    {
                        allItemsToPool[n].transformOfHisPulling.listOfItem[b].gameObject.SetActive(true);
                        allItemsToPool[n].transformOfHisPulling.listOfItem[b].transform.SetPositionAndRotation(position, Quaternion.Euler(new Vector3(0, Yrotation, 0)));
                        allItemsToPool[n].transformOfHisPulling.listOfItem[b].avaible = false;
                        break;
                    }
                }
                break;
            }
        }

    }
    public void DecallItem(Mb_Poolable itemToDepop)
    {
        itemToDepop.avaible = true;
        itemToDepop.gameObject.SetActive(false);
    }
}

[System.Serializable]
public struct ItemsToPoolCharacts
{
    public Mb_Poolable objectToInstantiate;
    [Range(5, 400)] public int NumberOfItemWanted;
    public Mb_PoolHolder transformOfHisPulling;
}
