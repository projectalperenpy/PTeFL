using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;
    public float timeBetweenShots = 0.5f;

    private float shotCooldown = 0f;

    void Update()
    {
        // Atış hızını kontrol et
        shotCooldown += Time.deltaTime;

        // Sol tıklama yapıldığında ve atış yapılabilecek durumda
        if (Input.GetMouseButtonDown(0) && shotCooldown >= timeBetweenShots)
        {
            FireBullet();
            shotCooldown = 0f; // Soğuma süresini yeniden başlat
        }
    }

    private void FireBullet()
    {
        // Mermiyi oluştur
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Mermiyi ileri doğru itmek için kuvvet uygula
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = bulletSpawnPoint.up * bulletSpeed;
    }
}
