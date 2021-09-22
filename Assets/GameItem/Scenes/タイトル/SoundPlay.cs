using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{
    [SerializeField]
    AudioSource Source = null;
    
    static bool playRequire;

    void Update()
    {
        if (playRequire == true)
        {
            Source.volume = SaveData.SoundVolume;
            Source.PlayOneShot(Source.clip);
            playRequire = false;
        }
    }

    public static void Play()
    {
        playRequire = true;
    }
}
