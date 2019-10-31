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
            ClearPools(mySelectedScript.allItemsToPool);
            BeginPooling();
            EditorSceneManager.MarkSceneDirty(mySelectedScript.gameObject.scene);
        }

        if (GUILayout.Button("ClearPools", GUILayout.MinHeight(50)))
            ClearPools(mySelectedScript.allItemsToPool);

        EditorGUI.EndChangeCheck();

        void BeginPooling()
        {
            for (int i = 0; i < mySelectedScript.allItemsToPool.Length; i++)
            {
                EnHancePooling(mySelectedScript.allItemsToPool[i]);
            }
        }

        void EnHancePooling(ItemsToPoolCharacts basicCharacts)
        {
            for (int j = 0; j < basicCharacts.NumberOfItemWanted; j++)
            {
                Mb_Poolable newItem = Instantiate(basicCharacts.objectToInstantiate);
                newItem.transform.parent = basicCharacts.transformOfHisPulling.transform;
                newItem.gameObject.SetActive(false);
                basicCharacts.transformOfHisPulling.listOfItem.Add(newItem);
                //PrefabUtility.RecordPrefabInstancePropertyModifications(mySelectedScript);
            }

            for (int p = 0; p < mySelectedScript.allItemsToPool.Length; p++)
            {
                PrefabUtility.RecordPrefabInstancePropertyModifications(mySelectedScript.allItemsToPool[p].transformOfHisPulling); ;
            }
            EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());


        }

        void ClearPools(ItemsToPoolCharacts[] basicCharacts)
        {
            for (int j = 0; j < basicCharacts.Length; j++)
            {
                basicCharacts[j].transformOfHisPulling.listOfItem.Clear();

                Transform parent = basicCharacts[j].transformOfHisPulling.transform;
                int safeCounter = 0;

                while (parent.childCount > 0)
                {
                    DestroyImmediate(parent.GetChild(0).gameObject);
                    safeCounter++;
                    if (safeCounter > 10000)
                        break;
                }
            }
        }
    }
}

