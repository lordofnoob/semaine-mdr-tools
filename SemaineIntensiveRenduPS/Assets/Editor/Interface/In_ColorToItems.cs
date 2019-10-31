using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Sc_ColorToItems))]
public class In_ColorToItems : Editor
{
    Sc_ColorToItems mySelectedScript;

    private void OnEnable()
    {
        mySelectedScript = target as Sc_ColorToItems;
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


        EditorGUI.EndChangeCheck();
    }
}
