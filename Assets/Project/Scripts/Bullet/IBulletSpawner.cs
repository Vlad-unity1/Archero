using UnityEngine;

namespace Project.Scripts.Bullet
{
    public interface IBulletSpawner
    {
        Bullet SpawnBullet(Bullet bulletPrefab, Vector3 position, Quaternion rotation);
        void ShootProjectile(Bullet bullet, Vector3 direction, float speed);
    }
}
