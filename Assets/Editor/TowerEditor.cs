using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(TowerFighter))]
public class TowerEditor : Editor
{
    private TowerFighter _towerFighter;

    private void OnEnable()
    {
        _towerFighter = (TowerFighter)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginVertical("box");
        EditorGUILayout.LabelField("Information");
        GUILayout.BeginHorizontal();
        _towerFighter._health = EditorGUILayout.IntField("Health", _towerFighter._health, GUILayout.Width(200));
        _towerFighter._protection = EditorGUILayout.IntField("Protection", _towerFighter._protection, GUILayout.Width(200));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        _towerFighter._damage = EditorGUILayout.IntField("Damage", _towerFighter._damage, GUILayout.Width(200));
        _towerFighter._index = EditorGUILayout.IntField("Index", _towerFighter._index, GUILayout.Width(200));
        GUILayout.EndHorizontal();
        _towerFighter._hp = (GameObject)EditorGUILayout.ObjectField("HP", _towerFighter._hp, typeof(GameObject), false);
        GUILayout.EndVertical();

        GUILayout.BeginVertical("box");
        EditorGUILayout.LabelField("Information for gun");
        GUILayout.BeginHorizontal();
        _towerFighter._prefab = (GameObject)EditorGUILayout.ObjectField("Bullet", _towerFighter._prefab, typeof(GameObject), false, GUILayout.Width(200));
        _towerFighter.gun = (GameObject)EditorGUILayout.ObjectField("Gun position", _towerFighter.gun, typeof(GameObject), true, GUILayout.Width(200));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        _towerFighter._interval = EditorGUILayout.FloatField("Interval", _towerFighter._interval, GUILayout.Width(200));
        _towerFighter._target = (GameObject)EditorGUILayout.ObjectField("Target", _towerFighter._target, typeof(GameObject), true, GUILayout.Width(200));
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();

        if (GUI.changed)
        {
            SetObjectDirty(_towerFighter.gameObject);
        }
    }

    public static void SetObjectDirty(GameObject gameObject)
    {
        EditorUtility.SetDirty(gameObject);
        EditorSceneManager.MarkSceneDirty(gameObject.scene);
    }
}
