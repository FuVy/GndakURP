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
        bullet.SetDamage(damage);
        bullet.SetTeam(friendlyLayer);
        bullet.SetBulletSpeed(bulletSpeed);
        bullet.SetCharacter(character);
        bullet.SetWeapon(weapon);
        //bullet.SetTransform(objectTransform);
        //Debug.Log(gameObject.name + " Pew-pew");
    }
}
