using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Threading;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera CinemachineVirtualCamera;
    private float _shakeIntensitvy = 1f;
    private float _shakeTime = 0.2f;
   
   private float _timer;
   private CinemachineBasicMultiChannelPerlin _cbmcp;

   void Awake()
   {
    CinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();

   }

    private void Start() 
    {
        StopShake();
    }
   public void ShakeCamera() 
   {
    CinemachineBasicMultiChannelPerlin _cbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    _cbmcp.m_AmplitudeGain = _shakeIntensitvy;

    _timer = _shakeTime;
   }

   void StopShake() {
    CinemachineBasicMultiChannelPerlin _cbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    _cbmcp.m_AmplitudeGain = 0f;
    _timer = 0;
   }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ShakeCamera();
        }
        if(_timer <= 0) {
            StopShake();

        }
    }
}
