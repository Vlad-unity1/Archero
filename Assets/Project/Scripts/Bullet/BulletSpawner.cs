using System.Collections;
using UnityEngine;

namespace Project.Scripts.Bullet
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private int _initialPoolSize = 10;

        private BulletPool _bulletPool;

        public void Awake()
        {
            _bulletPool = new BulletPool(_bulletPrefab, _initialPoolSize);
        }

        public void SpawnAndShoot(Vector3 position, Quaternion rotation, Vector3 direction, float speed, int damage)
        {
            Bullet bullet = _bulletPool.GetBullet();
            bullet.transform.SetPositionAndRotation(position, rotation);
            bullet.gameObject.SetActive(true);
            
            bullet.Shoot(direction, speed);
        }

        public void ReturnToPool(Bullet bullet)
        {
            StartCoroutine(ReturnToPoolCoroutine(bullet, 0));
        }

        private IEnumerator ReturnToPoolCoroutine(Bullet bullet, float delay)
        {
            yield return new WaitForSeconds(delay);
            _bulletPool.ReturnBullet(bullet);
        }
    }
}

