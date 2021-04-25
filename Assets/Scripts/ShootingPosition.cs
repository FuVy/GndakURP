using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPosition : MonoBehaviour
{
    [SerializeField]
    Bullet bullet;
    Transform objectTransform;
    private void Awake()
    {
        objectTransform = GetComponent<Transform>();
    }
    public void Fire(int damage, LayerMask friendlyLayer, float bulletSpeed, Character character, Weapon weapon)
    {
        Vector3 bulletPosition = transform.position;
        Bullet bullet = Instantiate(this.bullet, bulletPosition, objectTransform.rotation);
        SetBulletStats(damage, friendlyLayer, bulletSpeed, character, weapon, bullet);
    }
    private void SetBulletStats(int damage, LayerMask friendlyLayer, float bulletSpeed, Character character, Weapon weapon, Bullet bullet)
    {
        bullet.SetDamage(damage);
        bullet.SetTeam(friendlyLayer);
        bullet.SetBulletSpeed(bulletSpeed);
        bullet.SetCharacter(character);
        bullet.SetWeapon(weapon);
    }
}
