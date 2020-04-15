using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(SpawnerManager))]
public class SpawnerManagerEditor : Editor
{
    private SpawnerManager _spawnerManager;

    public void OnEnable()
    {
        _spawnerManager = (SpawnerManager)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginVertical("box");
        EditorGUILayout.LabelField("Enemies");
        GUILayout.BeginHorizontal();
        for(int i = 0; i < _spawnerManager._prefabs.Length; i++)
        {
            _spawnerManager._prefabs[i] = (GameObject)EditorGUILayout.ObjectField( _spawnerManager._prefabs[i], typeof(GameObject), false);
        }
        GUILayout.EndHorizontal();
        if(GUILayout.Button("Remote Enemy"))
        {
            for (int i = _spawnerManager._prefabs.Length - 1; i >= 0; i--)
            {
                if(_spawnerManager._prefabs[i] != null)
                {
                    _spawnerManager._prefabs[i] = null;
                    break;
                }
            }
        }
        GUILayout.EndVertical();

        GUILayout.BeginVertical("box");
        EditorGUILayout.LabelField("Spawners");
        GUILayout.BeginHorizontal();
        for (int i = 0; i < _spawnerManager._spawners.Length; i++)
        {
            _spawnerManager._spawners[i] = (GameObject)EditorGUILayout.ObjectField(_spawnerManager._spawners[i], typeof(GameObject), true);
        }
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();

        GUILayout.BeginVertical("box");
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Wave Count Text");
        _spawnerManager._waveCountText = (GameObject)EditorGUILayout.ObjectField(_spawnerManager._waveCountText , typeof(GameObject), false);
        GUILayout.EndHorizontal();
        _spawnerManager._addTowerButton = (GameObject)EditorGUILayout.ObjectField("Add Tower Button", _spawnerManager._addTowerButton, typeof(GameObject), true);
        GUILayout.EndVertical();

        if (GUI.changed)
        {
            SetObjectDirty(_spawnerManager.gameObject);
        }
    }

    public static void SetObjectDirty(GameObject gameObject)
    {
        EditorUtility.SetDirty(gameObject);
        EditorSceneManager.MarkSceneDirty(gameObject.scene);
    }
}
