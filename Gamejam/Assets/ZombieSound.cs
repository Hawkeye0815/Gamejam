using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class ZombieSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] idleSoundClips;
    public bool TestNoises;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SoundFXManager.instance.PlayRandomSoundFX(idleSoundClips, transform, 1f);
    }
}
