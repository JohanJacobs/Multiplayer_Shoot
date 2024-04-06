using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Netcode;
using UnityEngine;

public class BulletController : NetworkBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float timeToLife;
    float currentLifetime;
    private Vector3 directionVector;
    private bool bulletIntitialized;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        bulletIntitialized = false;
        directionVector = Vector3.zero;
        currentLifetime = 0;
    }

    public void SetDirection(Vector3 directionVector)
    {
        this.directionVector = directionVector;
        this.directionVector.z = 0;
        this.directionVector.Normalize();
        bulletIntitialized = true;
    }

    private void Update()
    {
        if (!IsServer) return;

        if (!bulletIntitialized)
            return;

        MoveBulletInDirection(directionVector, speed);

        KillBullet();
    }

    private void MoveBulletInDirection(Vector3 dir, float spd)
    {
        var displacement = dir * spd * Time.deltaTime;
        transform.position += displacement;
    }

    private void KillBullet()
    {
        currentLifetime += Time.deltaTime;

        if (currentLifetime > timeToLife)
            GameObject.Destroy(transform.gameObject);
    }
}
