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
        EditorGUILayout.LabelField("Health", GUILayout.MinWidth(50));
        _towerFighter.Health = EditorGUILayout.IntField(_towerFighter.Health, GUILayout.MinWidth(30));
        EditorGUILayout.LabelField(" ", GUILayout.MinWidth(7));
        EditorGUILayout.LabelField("Protection", GUILayout.MinWidth(50));
        _towerFighter.Protection = EditorGUILayout.IntField(_towerFighter.Protection, GUILayout.MinWidth(30));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Damage", GUILayout.MinWidth(50));
        _towerFighter.Damage = EditorGUILayout.IntField(_towerFighter.Damage, GUILayout.MinWidth(30));
        EditorGUILayout.LabelField(" ", GUILayout.MinWidth(7));
        EditorGUILayout.LabelField("Index", GUILayout.MinWidth(50));
        _towerFighter._index = EditorGUILayout.IntField(_towerFighter._index, GUILayout.MinWidth(30));
        GUILayout.EndHorizontal();
        _towerFighter.Hp = (GameObject)EditorGUILayout.ObjectField("HP", _towerFighter.Hp, typeof(GameObject), false);
        GUILayout.EndVertical();

        GUILayout.BeginVertical("box");
        EditorGUILayout.LabelField("Information for gun");
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Bullet", GUILayout.MinWidth(32));
        _towerFighter._prefab = (GameObject)EditorGUILayout.ObjectField(_towerFighter._prefab, typeof(GameObject), false, GUILayout.MinWidth(55));
        EditorGUILayout.LabelField("Gun position", GUILayout.MinWidth(68));
        _towerFighter.gun = (GameObject)EditorGUILayout.ObjectField(_towerFighter.gun, typeof(GameObject), true, GUILayout.MinWidth(55));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Interval", GUILayout.MinWidth(35));
        _towerFighter._interval = EditorGUILayout.FloatField(_towerFighter._interval, GUILayout.MinWidth(52));
        EditorGUILayout.LabelField("Target", GUILayout.MinWidth(68));
        _towerFighter._target = (GameObject)EditorGUILayout.ObjectField(_towerFighter._target, typeof(GameObject), true, GUILayout.MinWidth(55));
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
