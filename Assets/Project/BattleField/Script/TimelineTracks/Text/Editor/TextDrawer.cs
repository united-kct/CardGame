using UnityEditor;
using UnityEngine;

namespace Project.BattleField.Script.TimelineTracks.Text.Editor
{
    [CustomPropertyDrawer(typeof(TextBehaviour))]
    public class TextDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
        {
            int fieldCount = 1;
            return fieldCount * EditorGUIUtility.singleLineHeight;
        }

        public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty textProp = property.FindPropertyRelative("text");

            Rect singleFieldRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
            EditorGUI.PropertyField(singleFieldRect, textProp);
        }
    }
}
