using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    public string soundName;
    public string exitSoundName;
    void Start()
    {
        AudioPlayer.Instance.PlaySound(soundName);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseExit()
    {
        AudioPlayer.Instance.PlaySound(exitSoundName);
    }
}
