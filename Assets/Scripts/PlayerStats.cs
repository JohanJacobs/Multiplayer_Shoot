using UnityEngine;
using Unity.Netcode;
using Unity.VisualScripting;

public class PlayerStats: NetworkBehaviour
{
    public static event System.Action OnReceivedHit;
    private NetworkVariable<ushort> hits = new(0, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    public int HITS
    {
        get => hits.Value;
    }

    public void IncreaseHits(ushort count)
    {
        hits.Value += count;        
    }

    public int GetHits()
    {
        return hits.Value;
    }
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        hits.OnValueChanged += HitsValueChanged;
    }

    private void HitsValueChanged(ushort prevValue, ushort newValue) 
    {
        OnReceivedHit?.Invoke();
    }

}
