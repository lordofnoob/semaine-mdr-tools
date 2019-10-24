using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(Mb_PoolManager))]
public class In_PoolManager : Editor
{
    Mb_PoolManager mySelectedScript;

    private void OnEnable()
    {
        mySelectedScript = target as Mb_PoolManager;
        Undo.undoRedoPerformed += MyUndoCallback;
    }
    void MyUndoCallback()
    {
        Debug.Log("undo has been perfromed");
    }


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Undo.RecordObject(mySelectedScript, "Edited Something");
        EditorGUI.BeginChangeCheck();

        if (GUILayout.Button("GeneratePools", GUILayout.MinHeight(50)))
        {
            beginPooling();
            EditorSceneManager.MarkSceneDirty(mySelectedScript.gameObject.scene);
            Debug.Log("Pull generated Please aplly the prefab");
            Debug.Log("Aled simon les piliers save pas sans apply");
        }


        void beginPooling()
        {
            for (int i = 0; i <mySelectedScript.allItemsToPool.Length; i++)
            {
                enHancePooling(mySelectedScript.allItemsToPool[i]);
            }
        }

        void enHancePooling(ItemsToPoolCharacts basicCharacts)
        {
            for (int j = 0; j < basicCharacts.NumberOfItemWanted; j++)
            {
                Mb_Poolable newItem = basicCharacts.objectToInstantiate;
                newItem.transform.parent = basicCharacts.transformOfHisPulling.transform;
                basicCharacts.transformOfHisPulling.listOfItem.Add(newItem);
                newItem.gameObject.SetActive(false);
                Undo.RegisterCreatedObjectUndo(mySelectedScript.allItemsToPool[j].objectToInstantiate, mySelectedScript.allItemsToPool[j].objectToInstantiate.ToString());
         
                Debug.Log(newItem);
            }
        }

    }
}
