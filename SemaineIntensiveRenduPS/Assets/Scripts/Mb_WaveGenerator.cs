using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mb_WaveGenerator : MonoBehaviour
{
    public Sc_ShunkOfLd[] shunks;
   
   
    List<Sc_ShunkOfLd> possibleLevel;
    Sc_ShunkOfLd lastLevelGenerated;
    public int shunkPerLevel;
    public int maxLevel;
    private int shunkGeneratedThisLevel;
    private int levelOfLd = 0;

    private void Awake()
    {
        ChooseTheGoodElement(levelOfLd);
    }

    void GenerateLevel(int LevelSelectionned)
    {
        for (int x = 0; x < possibleLevel[LevelSelectionned].textureToTraduce.width; x++)
        {
            for (int z = 0; z < possibleLevel[LevelSelectionned].textureToTraduce.height; z++)
            {
                ReadTile(x, z, LevelSelectionned);
            }
        }
    }

    void ChooseTheGoodElement(int level)
    {
        if (shunkPerLevel < shunkGeneratedThisLevel)
            shunkGeneratedThisLevel += 1;
        else if (levelOfLd < maxLevel)
        {
            shunkGeneratedThisLevel = 0;
            levelOfLd += 1;
        }
        possibleLevel.Clear();

        for (int i = 0; i < shunks.Length; i++)
        {
            if (shunks[i].levelOfDifficulty == levelOfLd && lastLevelGenerated != shunks[i])
            {
                possibleLevel.Add(shunks[i]);
            }
        }

        int randomNumber = Random.Range(0, possibleLevel.Capacity);
        GenerateLevel(randomNumber);
    }

    void ReadTile(int x, int z,int LevelSelectionned)
    {
        Color currentPixelColor = possibleLevel[LevelSelectionned].textureToTraduce.GetPixel(x, z);

        if (currentPixelColor.a == 0)
            return;
        else
            for (int i = 0; i < possibleLevel[LevelSelectionned].colorCode.Length; i++)
            {
                if (possibleLevel[LevelSelectionned].colorCode[i].colorToTraduce.Equals(currentPixelColor))
                {
                    Mb_PoolManager.PoolManager.CallItem(
                        possibleLevel[LevelSelectionned].colorCode[i].itemTospawn,
                        new Vector3(x, 0, z),
                        180);
                }
            }
    }

}
