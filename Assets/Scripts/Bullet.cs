using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage;
    private float bulletSpeed;
    Rigidbody bulletRigidbody;
    Transform objectTransform;
    LayerMask friendlyLayers;
    Character sender;
    Weapon weapon;
    [SerializeField]
    MeshRenderer bodyRenderer;
    private void OnTriggerEnter(Collider other)
    {
        if (friendlyLayers != other.gameObject.layer)
        {
            HandleHit(other);
        }
    }
    private void HandleHit(Collider other)
    {
        Health objectHealth = other.GetComponent<Health>();
        objectHealth?.ChangeHealth(-damage);
        bodyRenderer.enabled = false;
        bulletRigidbody.velocity = Vector3.zero;
        Destroy(gameObject, 1f);
        if (objectHealth?.GetHealth() <= 0)
        {
            sender.GetComponent<Dummy>()?.SetTarget(null);
            weapon.GetComponent<DummyWeapon>()?.SetTarget(null);
        }
    }
    void Awake()
    {
        objectTransform = GetComponent<Transform>();
        bulletRigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject, 4f);
    }
    void Start()
    {
        Setup();
    }
    private void Setup()
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
