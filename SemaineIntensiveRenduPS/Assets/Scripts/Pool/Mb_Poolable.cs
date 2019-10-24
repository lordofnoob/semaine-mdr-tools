using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mb_Poolable : MonoBehaviour
{
    public poolableTag objectType;
    public bool avaible;

    public enum poolableTag
    {
        bullet,enemy,obstacle,Fx
    }
}

