using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStay : MonoBehaviour
{
    public static MusicStay instance;

    void Awake()
    {
        if (instance != null)
        
            Destroy(gameObject);
        
            
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

    }
}
