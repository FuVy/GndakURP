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
    public void Fire(int damage, string team, float bulletSpeed)
    {
        Vector3 bulletPosition = transform.position;
        Bullet bullet = Instantiate(this.bullet, bulletPosition, objectTransform.rotation);
        bullet.SetDamage(damage);
        bullet.SetTeam(team);
        bullet.SetBulletSpeed(bulletSpeed);
        //bullet.SetTransform(objectTransform);
        //Debug.Log(gameObject.name + " Pew-pew");
    }
}
