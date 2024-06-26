using UnityEngine;
using Unity.Netcode;


public class BulletCollision : NetworkBehaviour
{    
    PlayerStats playerStats;
    private string bulletTag = "Bullet";
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
 
        if (!playerStats)
            playerStats = GetComponent<PlayerStats>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!IsOwner) return;

        if (IsBullet(collision.transform))
            IncrementStats();
    }    

    private bool IsBullet(Transform collisionObject)
    {
        return collisionObject.tag == bulletTag;
    }

    private void IncrementStats()
    {
        playerStats.IncreaseHits(1);
    }
}
