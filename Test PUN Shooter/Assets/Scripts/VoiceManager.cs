using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora_gaming_rtc;

public class VoiceManager : MonoBehaviour
{
    [SerializeField] string appID;
    public static VoiceManager instance;

    private void Awake()
    {
        if(instance)
        {
            Destroy(this);
            
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}
