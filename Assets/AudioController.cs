using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip walk;
    [Range(0f, 1f)] public float volume;
    AudioSource audio;
    float delay = 1;

    // Start is called before the first frame update
    void Start()
    {
        delay = delay * 44100;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       /* audio.Play(44100);
        audio.volume = volume;
        audio.clip = walk;*/

    }
}
