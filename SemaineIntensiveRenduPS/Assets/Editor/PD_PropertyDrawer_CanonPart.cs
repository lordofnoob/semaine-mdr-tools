using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(shootOrigin))]
public class PD_PropertyDrawer_CanonPart : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float lineHeight = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
        float numberOfLines = 2;

        return lineHeight * numberOfLines;
    }
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        float spaceBetween = 10f;
        float rectWidth = (position.width - spaceBetween) * 0.5f;
        float lineHeight = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;


        Rect xRectPosition = new Rect(position.x, position.y, rectWidth, lineHeight);
        Rect zRectPosition = new Rect(position.x+ xRectPosition.width, position.y, position.width*0.5f, lineHeight);

        SerializedProperty positionTowardShipProperty= property.FindPropertyRelative("positionTowardShip");
        float newX = EditorGUI.FloatField(xRectPosition, new GUIContent("xPosition", "The X position from the ship of the shot"), positionTowardShipProperty.vector3Value.x);
        float newZ = EditorGUI.FloatField(zRectPosition, new GUIContent("zPosition", "The Z position from the ship of the shot"), positionTowardShipProperty.vector3Value.z);
        positionTowardShipProperty.vector3Value = new Vector3(newX, 0, newZ);



        Rect rotRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight, rectWidth, lineHeight);
        SerializedProperty rotationTowardShipProperty  = property.FindPropertyRelative("rotationTowardShip");
        float rotationTowardShip = EditorGUI.FloatField(rotRect, new GUIContent("Rotation", "The Rotation Compared to the front of the ship"), rotationTowardShipProperty.floatValue);
        rotationTowardShipProperty.floatValue = rotationTowardShip;

    }

}
