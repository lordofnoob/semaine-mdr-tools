using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Mb_WaveGenerator))]
public class In_WaveGenerator : Editor
{
    Mb_WaveGenerator targetBehaviour;
    public thingTogenerate elementToSpawn;
    private void OnEnable()
    {
        targetBehaviour = target as Mb_WaveGenerator;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
       
       // op = (OPTIONS)EditorGUILayout.EnumPopup("Primitive to create:", op);
        //Rect newRect = new Rect(0 + i * 50, 0, 50, 50);
        for (int i =0; i < 10; i++)
        {
            
           
        }
 
    }

    public enum thingTogenerate
    {
        EnemyEasy, EnemyMedium, Enemyhard, Weapon, Player
    }

}
