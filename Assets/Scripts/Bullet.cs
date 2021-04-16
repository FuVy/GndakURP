using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour //LAM
{
    private int damage;
    private float bulletSpeed;
    Rigidbody bulletRigidbody;
    Transform direction;
    Transform objectTransform;
    Camera mainCamera;
    void Awake()
    {
        objectTransform = GetComponent<Transform>(); //LAM
        bulletRigidbody = GetComponent<Rigidbody>();
        mainCamera = Camera.main; //LAM
    }
    void Start()
    {
        //RotateObject(); //LAM
        objectTransform.rotation = direction.rotation;
        objectTransform.parent = null;
        objectTransform.position = new Vector3(objectTransform.position.x, 1f, objectTransform.position.z);

        bulletRigidbody.velocity = objectTransform.forward * bulletSpeed;
    }
    #region GetSet
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
    public void SetTeam(string team)
    {
        gameObject.layer = LayerMask.NameToLayer(team);
    }
    public void SetBulletSpeed(float speed)
    {
        bulletSpeed = speed;
    }
    public void SetTransform(Transform transformy)
    {
        direction = transformy;
    }
    #endregion
}
