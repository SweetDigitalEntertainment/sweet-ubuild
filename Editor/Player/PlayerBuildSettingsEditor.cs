using UnityEditor;
using UnityEngine;

namespace Sweet.BuildTools.Editor
{
    [CustomEditor(typeof(PlayerBuildSettings), true)]
    public sealed class PlayerBuildSettingsEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUILayout.Space(15);

            if (GUILayout.Button("Build"))
            {
                ((PlayerBuildSettings)target).Run();
                return;
            }


            if (GUILayout.Button("Build and Run"))
            {
                ((PlayerBuildSettings)target).RunAndDeploy();
                return;
            }
        }
    }
}