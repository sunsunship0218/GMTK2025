using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorWindowEffect : MonoBehaviour
{
   [SerializeField] Transform errorParent;            // 指向 ErrorCanvas/Panel
    [SerializeField] AudioClip errorSound;
    [SerializeField] float interval = 0.2f;            // 每次開啟/關閉間隔時間
    [SerializeField] float waitBeforeClose = 1.5f;     // 等全部開完後等多久再關
    [SerializeField] private Button LeaveButton;

    [SerializeField] AudioSource audioSource;

    void Start()
    {
       
        if (LeaveButton != null)
            LeaveButton.onClick.AddListener(StartErrorSequence);
    }

    public void StartErrorSequence()
    {
        StartCoroutine(ErrorSequence());
    }

    IEnumerator ErrorSequence()
    {
        // 先逐一打開並播放音效
        foreach (Transform child in errorParent)
        {
            
            if (audioSource != null && errorSound != null)
            {
                child.gameObject.SetActive(true);
                audioSource.PlayOneShot(errorSound);
            }
  
            yield return new WaitForSeconds(interval);
        }

        yield return new WaitForSeconds(waitBeforeClose);

        // 再逐一關閉
        foreach (Transform child in errorParent)
        {
            child.gameObject.SetActive(false);
            yield return new WaitForSeconds(interval);
        }
    }
}
