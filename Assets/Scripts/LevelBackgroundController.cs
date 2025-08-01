using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBackgroundController : MonoBehaviour
{
    [System.Serializable]
    public class SceneObjectGroup
    {
        public string sceneName;
        public GameObject[] objectsToEnable;
    }

    public SceneObjectGroup[] sceneObjectGroups;

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        foreach (var group in sceneObjectGroups)
        {
            bool shouldEnable = group.sceneName == currentScene;
            foreach (var obj in group.objectsToEnable)
            {
                if (obj != null)
                    obj.SetActive(shouldEnable);
            }
        }
    }
}
