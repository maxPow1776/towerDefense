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
        EditorGUILayout.LabelField("Health", GUILayout.MinWidth(50));
        _enemyFighter._health = EditorGUILayout.IntField(_enemyFighter._health, GUILayout.MinWidth(30));
        EditorGUILayout.LabelField("  => ", GUILayout.MinWidth(7));
        EditorGUILayout.LabelField("first", GUILayout.MinWidth(35));
        _enemyFighter._firstHealth = EditorGUILayout.IntField(_enemyFighter._firstHealth, GUILayout.MinWidth(30));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Protection", GUILayout.MinWidth(50));
        _enemyFighter._protection = EditorGUILayout.IntField( _enemyFighter._protection, GUILayout.MinWidth(30));
        EditorGUILayout.LabelField("  => ", GUILayout.MinWidth(7));
        EditorGUILayout.LabelField("first", GUILayout.MinWidth(35));
        _enemyFighter._firstProtection = EditorGUILayout.IntField(_enemyFighter._firstProtection, GUILayout.MinWidth(30));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Damage", GUILayout.MinWidth(50));
        _enemyFighter._damage = EditorGUILayout.IntField( _enemyFighter._damage, GUILayout.MinWidth(30));
        EditorGUILayout.LabelField("  => ", GUILayout.MinWidth(7));
        EditorGUILayout.LabelField("first", GUILayout.MinWidth(35));
        _enemyFighter._firstDamage = EditorGUILayout.IntField(_enemyFighter._firstDamage, GUILayout.MinWidth(30));
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();

        GUILayout.BeginHorizontal("box");
        if(GUILayout.Button("Improve", GUILayout.MinWidth(60)))
        {
            _enemyFighter.NewLevelEnemy();
        }
        if (GUILayout.Button("On first", GUILayout.MinWidth(60)))
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
