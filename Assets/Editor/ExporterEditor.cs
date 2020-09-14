using CustomExporter;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(Exporter))]
    public class ExporterEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            Exporter myGameExporter = (Exporter) target;
            if (GUILayout.Button("Serialize"))
            {
                myGameExporter.SerializeScene();
            }
        }
    }
}