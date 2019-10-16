using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public class SaveOnPlay
{
    static SaveOnPlay()
    {
        EditorApplication.playModeStateChanged += SaveCurrentScene;
    }

    static void SaveCurrentScene(PlayModeStateChange stat)
    {
        if (!EditorApplication.isPlaying && EditorApplication.isPlayingOrWillChangePlaymode)
        {
#if UNITY_5_3
            Debug.Log("Saving open scenes on play...");
            UnityEditor.SceneManagement.EditorSceneManager.SaveOpenScenes();
#else
            Debug.Log("Saving scene on play...");
            EditorSceneManager.SaveOpenScenes();
#endif
        }
    }
}