using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    static AudioHandler singleton = null;
    public static AudioHandler Singleton
    {
        get
        {
            singleton = FindObjectOfType(typeof(AudioHandler)) as AudioHandler;

            if (singleton == null)
            {
                GameObject g = new GameObject("AudioHandler");
                singleton = g.AddComponent<AudioHandler>();
            }

            return singleton;
        }
    }

    [System.Serializable]
    public struct Sounds
    { 
    }

    [System.Serializable]
    public struct Audios
    {
    }

    public Audios audios;
    public Sounds sounds;

}
