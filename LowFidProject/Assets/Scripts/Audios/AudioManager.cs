using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   [SerializeField] public enum SoundFX {RunningFootsteps, SpeederEffect, SpeederPickup, Jumping, 
        PlayerDeath, ShootingEffect, PickupWhat}

    public GameObject audioObj;

    public AudioClip[] running;
    public AudioClip[] speeding;
    public AudioClip[] speederPickup;
    public AudioClip[] jumping;
    public AudioClip[] playerDeath;
    public AudioClip[] shooting;
    public AudioClip[] generalPickup; // Object to decide


    public void Audios(SoundFX audioType, Vector3 audiopos, float volume)
    {
        GameObject newAudio = GameObject.Instantiate(audioObj, audiopos, Quaternion.identity); 
        AudioController ac = newAudio.GetComponent<AudioController>();
        switch (audioType)
        {
            case (SoundFX.RunningFootsteps):
                ac.audioclip = running[0];
                break;
            case (SoundFX.SpeederEffect):
                ac.audioclip = speeding[0];
                break;
            case (SoundFX.SpeederPickup):
                ac.audioclip = speederPickup[0];
                break;
            case (SoundFX.Jumping):
                ac.audioclip = jumping[0];
                break;
            case (SoundFX.PlayerDeath):
                ac.audioclip = playerDeath[0];
                break;
            case (SoundFX.ShootingEffect):
                ac.audioclip = shooting[0];
                break;
            case (SoundFX.PickupWhat):
                ac.audioclip = generalPickup[0];
                break;

        }

        ac.volume = volume;
        ac.StartAudio();
    } 
}
