using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorWindowEffect : MonoBehaviour
{
   [SerializeField] Transform errorParent;            // ���V ErrorCanvas/Panel
    [SerializeField] AudioClip errorSound;
    [SerializeField] float interval = 0.2f;            // �C���}��/�������j�ɶ�
    [SerializeField] float waitBeforeClose = 1.5f;     // �������}���ᵥ�h�[�A��
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
        // ���v�@���}�ü��񭵮�
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

        // �A�v�@����
        foreach (Transform child in errorParent)
        {
            child.gameObject.SetActive(false);
            yield return new WaitForSeconds(interval);
        }
    }
}
