using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sc_GameOptions : MonoBehaviour
{
    [SerializeField] [Range(1,5)] public float gameSpeed=2;
    public float maxX=10;
    public float maxZ=10;
    public static Sc_GameOptions sc_GameOptions;

    private void Awake()
    {
        sc_GameOptions = this;

    }
}
