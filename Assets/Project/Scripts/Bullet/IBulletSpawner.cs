using UnityEngine;

public interface IBulletSpawner
{
    GameObject SpawnBullet(GameObject bulletPrefab, Vector3 position, Quaternion rotation);
    void SetupBullet(GameObject bullet, Vector3 direction, float speed);
}
