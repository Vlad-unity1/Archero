using Project.Scripts.BulletModel;
using Project.Scripts.Weapons;
using UnityEngine;
using Zenject;

public class WeaponFactory : MonoBehaviour
{
    private BowConfig _bowConfig;
    private BulletFactoryPlayer _bulletFactory;
    private StoneCannonConfig _stoneCannonConfig;
    private BulletFactoryEnemies _bulletFactoryEnemy;

    [Inject]
    public void Construct(BowConfig bowConfig, BulletFactoryPlayer bulletFactory,
                          StoneCannonConfig stoneCannonConfig, BulletFactoryEnemies bulletFactoryEnemy)
    {
        _bowConfig = bowConfig;
        _bulletFactory = bulletFactory;
        _stoneCannonConfig = stoneCannonConfig;
        _bulletFactoryEnemy = bulletFactoryEnemy;
    }

    public Bow CreateWeapon(Transform spawnPoint)
    {
        return new Bow(_bowConfig, spawnPoint, _bulletFactory);
    }

    public StoneCannon CreateEnemyWeapon(Transform[] spawnPoints)
    {
        return new StoneCannon(_stoneCannonConfig, spawnPoints, _bulletFactoryEnemy);
    }
}
