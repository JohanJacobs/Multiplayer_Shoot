using UnityEngine;
using UnityEngine.UIElements;


public class ShootController : MonoBehaviour
{
    [SerializeField] float timeBetweenShorts;
    float lastShot;

    [SerializeField] GameObject bulletPrefab;

    private void Awake()
    {
        lastShot = 0;
        if (bulletPrefab == null ) {
            Debug.LogError("Bullet prefab not assigned in player!");
        }
    }


    private void Update()
    {
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
        CreateBullet(shootDirection);
        lastShot = Time.time;   
    }

    private void CreateBullet(Vector3 shootDirection)
    {
        // create the bullet         
        var bullet = Instantiate(bulletPrefab, transform.position + shootDirection * 1, Quaternion.identity);

        // set the direction of the bullet
        BulletController bc = bullet.GetComponent<BulletController>();
        bc.SetDirection(shootDirection);
    }

    private Vector3 GetShootDirection()
    {
        var mousePos = Utils.GetMouseWorldPositionNoZ();
        var v =  mousePos - transform.position;
        v.z = 0;

        Debug.Log(v);
        return v.normalized;
    }
}
