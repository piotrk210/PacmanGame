using System;
using _PROJECT.Scripts.Data;
using UnityEngine;

public class TeleportIn : MonoBehaviour
{
    [SerializeField]
    private Transform _transformToTeleport;
    
    [SerializeField]
    private LayerMask _openingLayers;
    
    public event Action<Transform> OnTriggerEnterPlayer = EventUtility.Empty;
    
    private void OnTriggerEnter(Collider other)
    {
        if ((_openingLayers.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            OnTriggerEnterPlayer.Invoke(_transformToTeleport);
        }
    }

    public void SetTargetToTeleport(Transform transformOfTarget)
    {
        _transformToTeleport = transformOfTarget;
    }

    public void ResetEvent()
    {
        OnTriggerEnterPlayer = EventUtility.Empty;
    }
}
