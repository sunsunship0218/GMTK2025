using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScneTransition : MonoBehaviour
{
    int offsetSceneIndex = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.sceneLoaded += OnSceneLoaded;

            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int sceneCount = SceneManager.sceneCountInBuildSettings;
            int targetSceneIndex = currentSceneIndex + offsetSceneIndex;

            if (targetSceneIndex >= sceneCount)
            {
                targetSceneIndex = 0;
            }
            // 安全檢查避免超出範圍
            if (targetSceneIndex >= 0 && targetSceneIndex < sceneCount)
            {
                SceneManager.LoadScene(targetSceneIndex);
            }
            else
            {
                Debug.LogWarning("目標場景 Index 超出範圍: " + targetSceneIndex);
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
       
    }

}

