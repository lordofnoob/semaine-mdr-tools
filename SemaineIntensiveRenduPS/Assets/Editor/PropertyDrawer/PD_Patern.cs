
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[CustomPropertyDrawer(typeof(Sc_PatternWay))]
public class PD_Patern : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        float spaceBetween = 10f;
        float rectWidth = (position.width - spaceBetween) * 0.5f;
        float lineHeight = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;


        Rect xRectPosition = new Rect(position.x, position.y, rectWidth, lineHeight);
        Rect zRectPosition = new Rect(position.x + xRectPosition.width*2, position.y, position.width * 0.5f, lineHeight);
        
        SerializedProperty directionVector = property.FindPropertyRelative("patern");
        float newX = EditorGUI.FloatField(xRectPosition, new GUIContent("xPosition", "the X position compare to the begining of the item"), directionVector.vector3Value.x);
        float newZ = EditorGUI.FloatField(zRectPosition, new GUIContent("zPosition", "the Z position compare to the begining of the item + deplacement de base"), directionVector.vector3Value.z);
        directionVector.vector3Value = new Vector3(newX, 0, newZ);
    }
}
