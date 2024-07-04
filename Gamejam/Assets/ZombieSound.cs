using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;



public class ZombieSound : MonoBehaviour
{
    [SerializeField] public AudioClip[] idleSoundClips;
    public bool TestNoises;
    private bool IsReady;
    private float waitingTime;
    // Start is called before the first frame update
    void Start()
    {
        SoundFXManager.instance.PlayRandomSoundFX(idleSoundClips, transform, 1f);   
        IsReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsReady)
        {
            IsReady = false;
            SoundFXManager.instance.PlayRandomSoundFX(idleSoundClips, transform, 1f);
            waitingTime = Time.deltaTime + 5f;   
        }

        if (Time.deltaTime > waitingTime)
        {
            IsReady = true;
        }

    }
}
