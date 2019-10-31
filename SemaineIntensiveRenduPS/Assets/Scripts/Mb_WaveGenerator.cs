using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mb_WaveGenerator : MonoBehaviour
{
    public Sc_ShunkOfLd[] shunks;

    List<Sc_ShunkOfLd> possibleLevel = new List<Sc_ShunkOfLd>();

    public int shunkPerLevel;
    public int maxLevel;
    private int shunkGeneratedThisLevel=0;
    private int levelOfLd = 0;
    private Sc_ShunkOfLd lastLevelGenerated;
    public Transform positionOfTheSpawn;
    public int timeBeforeNextLevel;

    private void Awake()
    {
        int randomNumber = Random.Range(0, possibleLevel.Count - 1);
        StartCoroutine(timingBeforeNextLevel(2));
    }

    void GenerateLevel(int LevelSelectionned)
    {
        float spawnWidth = Sc_GameOptions.sc_GameOptions.maxX * 2;
        float distanceBetweenPixels = spawnWidth / possibleLevel[LevelSelectionned].textureToTraduce.width;
     
        //Debug.Log(possibleLevel[LevelSelectionned].name);
        
        for (int x = 0; x < possibleLevel[LevelSelectionned].textureToTraduce.width; x++)
        {
            for (int z = 0; z < possibleLevel[LevelSelectionned].textureToTraduce.height; z++)
            {
                ReadTile(x, z, LevelSelectionned, distanceBetweenPixels);
            }
        }
        StartCoroutine(timingBeforeNextLevel(timeBeforeNextLevel));
        lastLevelGenerated = possibleLevel[LevelSelectionned];
   
        
    }

    void ChooseTheGoodElement(int level)
    {
        
        if (shunkGeneratedThisLevel < shunkPerLevel)
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


        int randomNumber = Random.Range(0, possibleLevel.Count -1);
        GenerateLevel(randomNumber);
    }

    void ReadTile(int x, int z, int LevelSelectionned, float distanceBetweenPixels)
    {
        Color currentPixelColor = possibleLevel[LevelSelectionned].textureToTraduce.GetPixel(x, z);

        if (currentPixelColor.a == 0)
            return;
        else
        {
            Sc_ColorToItems[] code = possibleLevel[LevelSelectionned].colorCode;
            foreach (Sc_ColorToItems colorCode in code)
            {
                if (colorCode.colorToTraduce.Equals(currentPixelColor))
                {              
                    Mb_PoolManager.PoolManager.CallItem(
                        colorCode.itemTospawn,
                        positionOfTheSpawn.position + new Vector3(x* distanceBetweenPixels, 0, z* distanceBetweenPixels ),
                        180);
                }
            }

        }
    }

    IEnumerator timingBeforeNextLevel(int watingTime)
    {
        yield return new WaitForSeconds(watingTime);
        ChooseTheGoodElement(levelOfLd);
    }

}
