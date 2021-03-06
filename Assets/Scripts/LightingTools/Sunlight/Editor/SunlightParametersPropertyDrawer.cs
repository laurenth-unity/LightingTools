using UnityEditor;
using UnityEngine;
using EditorLightUtilities;
using LightUtilities;

[CustomPropertyDrawer(typeof(SunlightParameters))]
public class SunlightParametersPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        LightUIUtilities.DrawSplitter();

        property.FindPropertyRelative("orientationParameters.yAxis").isExpanded = LightUIUtilities.DrawHeaderFoldout("Orientation", property.FindPropertyRelative("orientationParameters.yAxis").isExpanded);
        EditorGUI.indentLevel++;

        if (property.FindPropertyRelative("orientationParameters.yAxis").isExpanded)
        {
            EditorGUILayout.PropertyField(property.FindPropertyRelative("orientationParameters.yAxis"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("orientationParameters.lattitude"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("orientationParameters.timeOfDay"), GUILayout.MaxWidth(EditorGUIUtility.labelWidth + 250 + EditorGUIUtility.fieldWidth));
            if (property.FindPropertyRelative("lightParameters.lightCookie").objectReferenceValue != null)
            {
                EditorGUILayout.PropertyField(property.FindPropertyRelative("orientationParameters.Roll"));
            }
        }

        EditorGUI.indentLevel--;
        LightUIUtilities.DrawSplitter();
        property.FindPropertyRelative("lightParameters.intensity").isExpanded = LightUIUtilities.DrawHeaderFoldout("Light", property.FindPropertyRelative("lightParameters.intensity").isExpanded);
        EditorGUI.indentLevel++;

        if (property.FindPropertyRelative("lightParameters.intensity").isExpanded)
        {
            EditorGUILayout.PropertyField(property.FindPropertyRelative("intensityCurve"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("colorGradient"));

            //EditorGUILayout.PropertyField(property.FindPropertyRelative("lightParameters.useColorTemperature"));  
            //if (property.FindPropertyRelative("lightParameters.useColorTemperature").boolValue == true)
            //{
            //    EditorGUILayout.PropertyField(property.FindPropertyRelative("lightParameters.colorTemperature"));
            //}
            EditorGUILayout.PropertyField(property.FindPropertyRelative("lightParameters.mode"), new GUIContent("Light mode / Indirect Intensity"), GUILayout.MaxWidth(EditorGUIUtility.labelWidth + 80));
            var modeRect = GUILayoutUtility.GetLastRect();
            var indirectRect = new Rect(modeRect.x + EditorGUIUtility.labelWidth + 100, modeRect.y, position.xMax * 0.3f, EditorGUIUtility.singleLineHeight);
            EditorGUI.PropertyField(indirectRect, property.FindPropertyRelative("lightParameters.indirectIntensity"), GUIContent.none);
            EditorGUILayout.PropertyField(property.FindPropertyRelative("lightParameters.lightCookie"));
            if (property.FindPropertyRelative("lightParameters.lightCookie").objectReferenceValue != null)
                EditorGUILayout.PropertyField(property.FindPropertyRelative("lightParameters.cookieSize"));
        }


        EditorGUI.indentLevel--;
        LightUIUtilities.DrawSplitter();
        property.FindPropertyRelative("lightParameters.shadows").boolValue = LightUIUtilities.DrawHeader("Shadows", property.FindPropertyRelative("lightParameters.shadows").boolValue);
        EditorGUI.indentLevel++;

        if (property.FindPropertyRelative("lightParameters.shadows").boolValue)
        {
            EditorGUILayout.PropertyField(property.FindPropertyRelative("lightParameters.shadowResolution"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("lightParameters.viewBiasScale"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("lightParameters.normalBias"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("lightParameters.contactShadows"));
        }
        EditorGUI.indentLevel--;
        EditorGUI.EndProperty();
    }
}
