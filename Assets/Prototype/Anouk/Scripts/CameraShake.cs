using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
// using Cinemachine.Editor;
using Cinemachine.Utility;

public class CameraShake : MonoBehaviour
{
    public float amplitudeGain;
    public float frequemcyGain;
    public CinemachineVirtualCamera cm;
    public float shakeDuration;

    void Start()
    {
        AD_EventManager.DamageDealt += DoShake;
    }

    public void DoShake()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(Shake());         
        }        
    }

    public IEnumerator Shake()
    {
        Noise(amplitudeGain, frequemcyGain);
        yield return new WaitForSeconds(shakeDuration);
        Noise(0,0);
    }

    void Noise(float amplitude,float frequency)
    {
        cm.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitude;
        cm.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = frequency;
    }
    
}
