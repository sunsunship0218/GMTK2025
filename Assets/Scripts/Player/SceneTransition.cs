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
            // �w���ˬd�קK�W�X�d��
            if (targetSceneIndex >= 0 && targetSceneIndex < sceneCount)
            {
                SceneManager.LoadScene(targetSceneIndex);
            }
            else
            {
                Debug.LogWarning("�ؼг��� Index �W�X�d��: " + targetSceneIndex);
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
       
    }

}

