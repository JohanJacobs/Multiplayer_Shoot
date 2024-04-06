using UnityEngine;
using Unity.Netcode;

public class BulletCollision : NetworkBehaviour
{
    private int bulletHits;

    private string bulletTag = "Bullet";
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        bulletHits = 0;
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
        bulletHits += 1;
        Debug.Log("Received " + bulletHits + " bullet hits");        
    }

}
