using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShakeScript : MonoBehaviour
{
    public static ScreenShakeScript instance;

    private CinemachineVirtualCamera cmVC;
    private float shakeTimer;

    private void Awake()
    {
        instance = this;
        cmVC = GetComponent<CinemachineVirtualCamera>();
    }

    public void shakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cmBMCP = cmVC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cmBMCP.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    private void Update()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cmBMCP = cmVC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cmBMCP.m_AmplitudeGain = 0f;
            }
        }
    }
}
