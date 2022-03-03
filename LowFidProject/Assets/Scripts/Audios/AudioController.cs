using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource aS;
    public AudioClip audioclip;
    [SerializeField] public float volume = 0f;

    public void StartAudio()
    {
        aS = GetComponent<AudioSource>();
        aS.clip = audioclip;
        aS.volume = volume;
        aS.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!aS.isPlaying) Destroy(gameObject);
    }
}
