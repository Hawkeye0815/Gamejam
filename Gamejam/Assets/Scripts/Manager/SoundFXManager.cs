using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundFXManager : MonoBehaviour
{
    [SerializeField] private AudioSource soundFXObject;
    public static SoundFXManager instance;
    // Start is called before the first frame update

    private void Awake() 
    {
            if (instance == null)
            {
                instance = this;
            }
    }

    public void PlaySoundFX(AudioClip audioClip, Transform spawnTransform, float volume) 
    {
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);


    }

    public void PlayRandomSoundFX(AudioClip[] audioClip, Transform spawnTransform, float volume) 
    {
        int rand= Random.Range(0, audioClip.Length);


        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip[rand];

        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);


    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
