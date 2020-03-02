using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelEditorPlayerMovement))]
public class EditorCamera : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        LevelEditorPlayerMovement player = (LevelEditorPlayerMovement)target;

        GUILayout.Space(10);

        if (GUILayout.Button("Resetar Rotação"))
        {
            Quaternion rotation = Quaternion.Euler(15, -45, 0);
            player.transform.rotation = rotation;
        }

        GUILayout.Space(10);

        if (GUILayout.Button("Resetar Movimentação"))
        {
            player.transform.position = new Vector3(0, 0, 0);
            player.transform.GetChild(0).transform.position = new Vector3(0, 0, -10);
        }

        GUILayout.Space(10);
    }
}
