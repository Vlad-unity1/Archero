using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Bullet
{
    public class BulletFactory : MonoBehaviour, IBulletSpawner
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private int _initialPoolSize = 10;

        private readonly List<Bullet> _bulletPool = new();

        public void Initialize()
        {
            for (int i = 0; i < _initialPoolSize; i++)
            {
                Bullet bullet = CreateBullet(_bulletPrefab);
                _bulletPool.Add(bullet);
            }
        }

        public Bullet SpawnBullet(Bullet prefab, Vector3 position, Quaternion rotation)
        {
            Bullet bullet = GetBulletFromPool();
            if (!bullet)
            {
                bullet = CreateBullet(prefab);
                _bulletPool.Add(bullet);
            }

            bullet.transform.SetPositionAndRotation(position, rotation);
            bullet.gameObject.SetActive(true);
            return bullet;
        }

        public void ShootProjectile(Bullet bullet, Vector3 direction, float speed)
        {
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.AddForce(direction.normalized * speed, ForceMode.Impulse);
        }

        private Bullet GetBulletFromPool()
        {
            foreach (var bullet in _bulletPool)
            {
                if (!bullet.gameObject.activeInHierarchy)
                {
                    return bullet;
                }
            }

            return null;
        }

        private Bullet CreateBullet(Bullet prefab)
        {
            Bullet bullet = Instantiate(prefab);
            bullet.gameObject.SetActive(false);
            bullet.Initialize(this);
            
            return bullet;
        }

        public void ReturnToPool(Bullet bullet, float delay)
        {
            StartCoroutine(ReturnToPoolCoroutine(bullet, delay));
        }

        private IEnumerator ReturnToPoolCoroutine(Bullet bullet, float delay)
        {
            yield return new WaitForSeconds(delay);
            bullet.gameObject.SetActive(false);
        }
    }
}

