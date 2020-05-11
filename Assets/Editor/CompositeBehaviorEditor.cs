using Behavior_Scripts;
using UnityEditor;
using UnityEngine;


namespace Editor
{
    [CustomEditor(typeof(CompositeBehavior))]
    public class CompositeBehaviorEditor : UnityEditor.Editor 
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
    }
}
