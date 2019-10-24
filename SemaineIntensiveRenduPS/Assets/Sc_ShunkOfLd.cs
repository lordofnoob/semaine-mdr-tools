using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [System.Serializable]
[CreateAssetMenu(fileName = "NewShunk", menuName = "Ld/NewShunk", order = 101)]
public class Sc_ShunkOfLd : ScriptableObject
{
    public Texture2D textureToTraduce;
    public int levelOfDifficulty;
    public Sc_ColorToItems[] colorCode;
}
