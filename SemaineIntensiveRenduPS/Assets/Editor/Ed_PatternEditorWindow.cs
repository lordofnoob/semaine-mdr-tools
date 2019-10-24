using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Mb_PatternGenerator))]
public class Ed_PatternEditorWindow : Editor
{
    Mb_PatternGenerator targetBehaviour;

    private void OnEnable()
    {
        targetBehaviour = target as Mb_PatternGenerator;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("SavePath", GUILayout.MinWidth(250)))
        {
            Sc_PatternWay newPattern = new Sc_PatternWay();
            newPattern.patern= targetBehaviour.patern;
            string finalPath = AssetDatabase.GenerateUniqueAssetPath("Assets/Scriptables/AllPaths/NewPattern.asset");
            AssetDatabase.CreateAsset(newPattern, finalPath);
        }
    }

    private void OnSceneGUI()
    {
        if (targetBehaviour.patern != null)
        {
            if (targetBehaviour.patern.Length > 0)
            {
                for (int i = 0; i < targetBehaviour.patern.Length; i++)
                {
                    if (i == 0)
                    {
                        Vector3 pos = new Vector3(0, 0, 0);
                        targetBehaviour.patern[i] = Handles.FreeMoveHandle(pos, Quaternion.identity, HandleUtility.GetHandleSize(targetBehaviour.transform.position) * 0.5f, Vector3.one * 0.1f, Handles.SphereHandleCap);
                        Handles.Label(targetBehaviour.patern[i] + Vector3.one, new GUIContent(i.ToString()), EditorStyles.boldLabel);
                    }
                    else
                    {
                        Vector3 pos = new Vector3(Mathf.Round(targetBehaviour.patern[i].x * 10.0f) * 0.1f, 0, Mathf.Round(targetBehaviour.patern[i].z * 10.0f) * 0.1f);
                        targetBehaviour.patern[i] = Handles.FreeMoveHandle(pos, Quaternion.identity, HandleUtility.GetHandleSize(targetBehaviour.transform.position) * 0.5f, Vector3.one * 0.1f, Handles.SphereHandleCap);
                        Handles.Label(targetBehaviour.patern[i] + Vector3.one, new GUIContent(i.ToString()), EditorStyles.boldLabel);
                    }
               
                }
                Handles.color = Color.red;
                Handles.DrawPolyLine(targetBehaviour.patern);
                Handles.DrawLine(targetBehaviour.patern[0], targetBehaviour.patern[targetBehaviour.patern.Length - 1]);
            }
        }

        Handles.BeginGUI();

        if (GUILayout.Button("Add Point", GUILayout.MaxWidth(100)))
        {
            Vector3[] oldPath = targetBehaviour.patern;
            targetBehaviour.patern = new Vector3[targetBehaviour.patern.Length + 1];
            for (int i = 0; i < oldPath.Length; i++)
            {
                targetBehaviour.patern[i] = oldPath[i];
            }

            targetBehaviour.patern[targetBehaviour.patern.Length - 1] = targetBehaviour.patern[targetBehaviour.patern.Length - 2] + Vector3.one;
        }

        Handles.EndGUI();
    }
}
