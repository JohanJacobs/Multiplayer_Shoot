using UnityEngine;
using Unity.Netcode;
using System;


public class ShootController : NetworkBehaviour
{
    [SerializeField] float timeBetweenShorts;
    float lastShot;

    [SerializeField] GameObject bulletPrefab;
    private float bulletOffset = 1.5f;


    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        lastShot = 0;
        if (bulletPrefab == null ) {
            Debug.LogError("Bullet prefab not assigned in player!");
        }
    }

    private void Update()
    {
        if (!IsOwner) return;

        if (CanShoot() && Utils.IsMouseButtonDown(0))
            Shoot();
    }

    private bool CanShoot()
    {
        return (Time.time >= lastShot + timeBetweenShorts);        
    }

    private void Shoot()
    {
        // Get the direction to shoot
        var shootDirection = GetShootDirection();
        CreateBulletServerRpc(shootDirection);
        lastShot = Time.time;   
    }

    private Vector3 GetShootDirection()
    {
        var mousePos = Utils.GetMouseWorldPositionNoZ();
        var v =  mousePos - transform.position;
        v.z = 0;

        return v.normalized;
    }

    [ServerRpc]
    private void CreateBulletServerRpc(Vector3 shootDirection)
    {
        // create the bullet         
        var networkBullet = Instantiate(bulletPrefab, transform.position + shootDirection * bulletOffset, Quaternion.identity);
        if (!networkBullet)
            Debug.LogError("Failed to create networked bullet!");

        var bulletNetworkObject  = networkBullet.GetComponent<NetworkObject>();
        bulletNetworkObject.Spawn();

        // set the direction of the bullet        
        BulletController bc = networkBullet.GetComponent<BulletController>();
        bc.SetDirection(shootDirection);
    }
}
