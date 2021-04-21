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
    [SerializeField]
    ParticleSystem[] impactEffect;
    Character sender;
    Weapon weapon;
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.layer);
        if (friendlyLayers != other.gameObject.layer)
        {
            //Debug.Log(damage);
            Health objectHealth = other.GetComponent<Health>();
            objectHealth?.ChangeHealth(-damage);
            objectTransform.Find("Body").GetComponent<MeshRenderer>().enabled = false;
            bulletRigidbody.velocity = Vector3.zero;
            Destroy(gameObject, 1f);
            //impactEffect[0].Play();
            if (objectHealth?.GetHealth() <= 0)
            { 
                sender.GetComponent<Dummy>()?.SetTarget(null);
                weapon.GetComponent<DummyWeapon>()?.SetTarget(null);
                //Debug.Log(sender.gameObject.GetComponent<Dummy>()?.GetTarget()); 
            }
        }
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
    public void SetTransform(Transform transform)
    {
        direction = transform;
    }
    public void SetCharacter(Character character)
    {
        sender = character;
    }
    public void SetWeapon(Weapon weapon)
    {
        this.weapon = weapon;
    }
    #endregion
}
