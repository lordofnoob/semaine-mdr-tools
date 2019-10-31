using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
//[CustomEditor(typeof(Sc_CanonsPart))]
public class In_CanonInterface : Editor
{
    SerializedProperty shootOriginProperty;
    SerializedProperty delayBetweenShotsProperty, damagesProperty, projectileProperty, paternProperty;
    Sc_CanonsPart mySelectedScript;
    bool foldoutShootOrigin;
    bool foldoutPatern;
    private void OnEnable()
    {
        Sc_CanonsPart mySelectedScript = target as Sc_CanonsPart;
        delayBetweenShotsProperty = serializedObject.FindProperty("delayBetweenShots");
        damagesProperty = serializedObject.FindProperty("damages");
        projectileProperty = serializedObject.FindProperty("projectile");
        shootOriginProperty = serializedObject.FindProperty("shootOrigin");
        paternProperty = serializedObject.FindProperty("patern");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        /*
        if (!delayBetweenShotsProperty.hasMultipleDifferentValues)
            delayBetweenShotsProperty.floatValue = EditorGUILayout.FloatField("Delay Between Shots (seconds)", delayBetweenShotsProperty.floatValue);
        else EditorGUILayout.LabelField("nonnon");
        */
        #region
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PropertyField(delayBetweenShotsProperty);
        EditorGUILayout.PropertyField(damagesProperty);
        EditorGUILayout.EndHorizontal();
        #endregion

        EditorGUILayout.PropertyField(projectileProperty);
     
        
        shootOriginProperty.arraySize = EditorGUILayout.IntField("Shoot Origin Elements", shootOriginProperty.arraySize);

        if (shootOriginProperty.arraySize > 0)
        {
            foldoutShootOrigin = EditorGUILayout.Foldout(foldoutShootOrigin, "ShootOrigin", true);
            if (foldoutShootOrigin)
            {
                for (int i = 0; i < shootOriginProperty.arraySize; i++)
                {
                    SerializedProperty currentElement = shootOriginProperty.GetArrayElementAtIndex(i);
                    EditorGUILayout.PropertyField(currentElement);
                }
                EditorGUI.indentLevel -= 2;
            }
            serializedObject.ApplyModifiedProperties();
        }

        EditorGUILayout.PropertyField(damagesProperty);

        if (paternProperty != null)
        {
            foldoutPatern = EditorGUILayout.Foldout(foldoutPatern, "PaternElement", true);
            if(foldoutPatern)
            {
               /* for (int i = 0; i < mySelectedScript.patern.patern.Length; i++)
                {
                   /* SerializedProperty currentElement = mySelectedScript.patern.patern[i];
                    EditorGUILayout.PropertyField(currentElement);
                }*/
                EditorGUI.indentLevel -= 2;
            }
        }

    

    }
}
