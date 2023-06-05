using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FireStoreManager))]
public class CustomEditor_FireStore : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        EditorGUILayout.HelpBox("Don't forget to set user values before fetching them.", MessageType.Warning);
        
        FireStoreManager _fireStoreManager = (FireStoreManager)target;
        if (GUILayout.Button("Set User Values"))
            _fireStoreManager.SetUserInfo();
    }
}
