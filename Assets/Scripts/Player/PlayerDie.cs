using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("Monster")))
        {
            Debug.Log("Die");
            this.gameObject.SetActive(false);
        }
    }
}
