using Project.Scripts.Bullet;
using UnityEngine;

namespace Project.Scripts.Weapons
{
    public class WeaponFactory : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private BowConfig _bowConfig;
        [SerializeField] private Bullet.Bullet _bulletPrefab;
        [SerializeField] private BulletSpawner _bulletSpawner;

        [Header("EnemyModel")]
        [SerializeField] private Bullet.Bullet _bulletEnemyPrefab;
        [SerializeField] private StoneCannonConfig _stoneCannonConfig;
        [SerializeField] private BulletSpawner _bulletSpawnerEnemy;

        public Weapon CreateWeapon(GameObject playerObject)
        {
            Transform weaponMountPoint = playerObject.transform.Find("Weapon"); // ужас, я знаю, но нашел только такое решение проблемы, подскажи как тут лучше сделать
            Bow bow = new(_bowConfig, _bulletPrefab, weaponMountPoint, _bulletSpawner);
            return bow;
        }

        public Weapon CreateEnemyWeapon(Transform[] spawnPoints)
        {
            StoneCannon stoneCannon = new(_stoneCannonConfig, _bulletEnemyPrefab, spawnPoints, _bulletSpawnerEnemy);
            return stoneCannon;
        }
    }
}