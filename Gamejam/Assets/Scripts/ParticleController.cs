using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParticleController : MonoBehaviour
{

    ParticleSystem Dust;
    [SerializeField] GameObject ParticleSystem;


    // Start is called before the first frame update
    void Start()
    {
      Dust = GetComponent<ParticleSystem>();  


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
