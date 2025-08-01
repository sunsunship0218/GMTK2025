using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScneTransition : MonoBehaviour
{
    int offsetSceneIndex = 1;
    private void Start()
    {
        if (!SceneManager.GetSceneByName("Background").isLoaded)
        {
            SceneManager.LoadScene("Background", LoadSceneMode.Additive);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.sceneLoaded += OnSceneLoaded;

            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int sceneCount = SceneManager.sceneCountInBuildSettings;
            int targetSceneIndex = currentSceneIndex + offsetSceneIndex;

            if (targetSceneIndex >= sceneCount-1)
            {
                targetSceneIndex = 0;
            }
            // �w���ˬd�קK�W�X�d��
            if (targetSceneIndex >= 0 && targetSceneIndex < sceneCount)
            {

                SceneManager.LoadScene(targetSceneIndex, LoadSceneMode.Single);


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

