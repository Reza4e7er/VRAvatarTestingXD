using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class TunnelVignetteActivator : MonoBehaviour
{
    public TunnelingVignetteController tunnelingVignetteController;
    
    public TunnelVignetteActivatorProvider tunnelVignetteActivatorProvider;
    
    [Serializable]
    public class TunnelVignetteActivatorProvider : ITunnelingVignetteProvider
    {
        [SerializeField] bool m_Enabled;
        public bool enabled
        {
            get => m_Enabled;
            set => m_Enabled = value;
        }

        [SerializeField] bool m_OverrideDefaultParameters;
        public bool overrideDefaultParameters
        {
            get => m_OverrideDefaultParameters;
            set => m_OverrideDefaultParameters = value;
        }

        [SerializeField] VignetteParameters m_OverrideParameters = new VignetteParameters();
        public VignetteParameters overrideParameters
        {
            get => m_OverrideParameters;
            set => m_OverrideParameters = value;
        }
        public VignetteParameters vignetteParameters => m_OverrideDefaultParameters ? m_OverrideParameters : null;
    }
    
    public void ActivateTunnel(float reactivationTime)
    {
        StartCoroutine(ActivateTunnelCoroutine(reactivationTime));
    }

    public void DeactivateTunnel()
    {
        tunnelingVignetteController.EndTunnelingVignette(tunnelVignetteActivatorProvider);
    }

    private IEnumerator ActivateTunnelCoroutine(float reActivationTime)
    {
        tunnelingVignetteController.BeginTunnelingVignette(tunnelVignetteActivatorProvider);

        yield return new WaitForSeconds(reActivationTime);
        
        tunnelingVignetteController.EndTunnelingVignette(tunnelVignetteActivatorProvider);
    }
}
