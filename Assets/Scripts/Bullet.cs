using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    private int damage;
    private float bulletSpeed;
    Rigidbody bulletRigidbody;
    Transform direction;
    Transform objectTransform;
    Camera mainCamera;
    LayerMask friendlyLayers;
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.layer);
        if (friendlyLayers != other.gameObject.layer)
        {
            //Debug.Log(damage);
            other.GetComponent<Health>()?.ChangeHealth(-damage);
            Destroy(gameObject);
        }
        //Play destroy vfx
        //Destroy(gameObject);
    }

    void Awake()
    {
        objectTransform = GetComponent<Transform>(); //LAM
        bulletRigidbody = GetComponent<Rigidbody>();
        mainCamera = Camera.main; //LAM
        Destroy(gameObject, 4f);
    }
    void Start()
    {
        objectTransform.parent = null;
        objectTransform.position = new Vector3(objectTransform.position.x, 1f, objectTransform.position.z);
        bulletRigidbody.velocity = objectTransform.forward * bulletSpeed;
    }
    #region GetSet
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
    public void SetTeam(LayerMask layer)
    {
        //gameObject.layer = LayerMask.NameToLayer(team);
        friendlyLayers = layer;
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
