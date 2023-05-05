using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CustomEditor(typeof(GridManager))]
public class GridManagerEditor : Editor
{
    private GridManager gridManager;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        gridManager = (GridManager)target;

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        int newRow = EditorGUILayout.IntField("New Rows", gridManager.rows);
        int newColumn = EditorGUILayout.IntField("New Columns", gridManager.columns);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Update Grid Size"))
        {
            gridManager.UpdateGridSize(newRow, newColumn);
        }
    }
}