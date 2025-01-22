using Archero.Bullets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archero.BulletSpawner
{
    public class BulletSpawn : MonoBehaviour, IBulletSpawner
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private int _initialPoolSize = 10;

        private readonly List<GameObject> _bulletPool = new();

        public void Initialize()
        {
            for (int i = 0; i < _initialPoolSize; i++)
            {
                GameObject bullet = CreateBullet();
                _bulletPool.Add(bullet);
            }
        }

        public GameObject SpawnBullet(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            GameObject bullet = GetBulletFromPool();
            if (bullet == null)
            {
                bullet = CreateBullet();
                _bulletPool.Add(bullet);
            }

            bullet.transform.position = position;
            bullet.transform.rotation = rotation;
            bullet.SetActive(true);
            return bullet;
        }

        public void SetupBullet(GameObject bullet, Vector3 direction, float speed)
        {
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = direction * speed;
            rb.AddForce(rb.velocity, ForceMode.Impulse);
        }

        private GameObject GetBulletFromPool()
        {
            foreach (var bullet in _bulletPool)
            {
                if (!bullet.activeInHierarchy)
                {
                    return bullet;
                }
            }

            return null;
        }

        private GameObject CreateBullet()
        {
            GameObject bullet = Instantiate(_bulletPrefab);
            bullet.SetActive(false);
            bullet.GetComponent<Bullet>().Initialize(this);
            return bullet;
        }

        public void ReturnToPool(GameObject bullet, float delay)
        {
            StartCoroutine(ReturnToPoolCoroutine(bullet, delay));
        }

        private IEnumerator ReturnToPoolCoroutine(GameObject bullet, float delay)
        {
            yield return new WaitForSeconds(delay);
            bullet.SetActive(false);
        }
    }
}

