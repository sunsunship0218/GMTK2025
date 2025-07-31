using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    public static PlayerControllers Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // ¾P·´­«½Æªº Player
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
