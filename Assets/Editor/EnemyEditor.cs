using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(EnemyFighter))]
public class EnemyEditor : Editor
{
    private EnemyFighter _enemyFighter;

    public void OnEnable()
    {
        _enemyFighter = (EnemyFighter)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginVertical("box");
        EditorGUILayout.LabelField("Information");
        GUILayout.BeginHorizontal();
        _enemyFighter._health = EditorGUILayout.IntField("Health", _enemyFighter._health, GUILayout.Width(200));
        _enemyFighter._firstHealth = EditorGUILayout.IntField("first", _enemyFighter._firstHealth, GUILayout.Width(200));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        _enemyFighter._protection = EditorGUILayout.IntField("Protection", _enemyFighter._protection, GUILayout.Width(200));
        _enemyFighter._firstProtection = EditorGUILayout.IntField("first", _enemyFighter._firstProtection, GUILayout.Width(200));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        _enemyFighter._damage = EditorGUILayout.IntField("Damage", _enemyFighter._damage, GUILayout.Width(200));
        _enemyFighter._firstDamage = EditorGUILayout.IntField("first", _enemyFighter._firstDamage, GUILayout.Width(200));
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();

        GUILayout.BeginHorizontal("box");
        if(GUILayout.Button("Improve", GUILayout.Width(200)))
        {
            _enemyFighter.NewLevelEnemy();
        }
        if (GUILayout.Button("On first", GUILayout.Width(200)))
        {
            _enemyFighter.OnFirstWave();
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginVertical("box");
        _enemyFighter._hp = (GameObject)EditorGUILayout.ObjectField("HP", _enemyFighter._hp, typeof(GameObject), false);
        _enemyFighter._zone = (GameObject)EditorGUILayout.ObjectField("Zone", _enemyFighter._zone, typeof(GameObject), false);
        _enemyFighter._placeForTower = (GameObject)EditorGUILayout.ObjectField("Place For Tower", _enemyFighter._placeForTower, typeof(GameObject), false);
        GUILayout.EndVertical();

        if (GUI.changed)
        {
            SetObjectDirty(_enemyFighter.gameObject);
        }
    }

    public static void SetObjectDirty(GameObject gameObject)
    {
        EditorUtility.SetDirty(gameObject);
        EditorSceneManager.MarkSceneDirty(gameObject.scene);
    }
}
