using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    public AudioSource audioSource;
    public static AudioPlayer Instance { get; private set; }
    public AudioClip[] clips;
    private Dictionary<string, AudioClip> clipDict;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);


        clipDict = new Dictionary<string, AudioClip>();
        foreach (AudioClip clip in clips)
        {
            clipDict[clip.name] = clip;
        }
    }
    void Start()
    {

    }

    void Update()
    {

    }

    public void PlayDefaultSound()
    {
        PlaySound("mainmenu");
    }

    public void PlaySound(string clipName)
    {
        if (clipName == "default")
        {
            PlayDefaultSound();
        }
        else if (clipDict.ContainsKey(clipName))
        {
            audioSource.clip = clipDict[clipName];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Clip not found: " + clipName);
        }
    }
}
