using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PersonajeStats))]
public class PersonajeStatsEditor : Editor
{
    public PersonajeStats statsTarget => target as PersonajeStats;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Resetear Valores"))
        {
            statsTarget.ResetearValores();
        }
    }
}
