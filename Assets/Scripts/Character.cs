using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    protected string nickname;
    [SerializeField]
    NicknameHandler nicknameObject;
    Rigidbody characterRigidbody;
    protected Transform characterTransform;
    Weapon characterWeapon;
    WeaponHandler weaponHandler;
    
    float movementX;
    float movementZ;
    Vector2 movementVector;

    [SerializeField]
    float movementSpeed;
    protected virtual void Awake()
    {
        nickname = PlayerPrefs.GetString("nickname");
        weaponHandler = GetComponent<WeaponHandler>();
        characterRigidbody = GetComponent<Rigidbody>();
        characterTransform = GetComponent<Transform>();
    }
    void Start()
    {
        NicknameHandler nickname = Instantiate(nicknameObject);
        nickname.SetTarget(this);
        nicknameObject = nickname;
    }
    private void Update()
    {
        UpdateMovementAxis();
    }
    private void FixedUpdate()
    {
        Move();
    }
    #region Movement
    private void UpdateMovementAxis()
    {
        movementX = Input.GetAxis("Horizontal");
        movementZ = Input.GetAxis("Vertical");
        //movementVector = new Vector2(movementX, movementZ).normalized;
    }
    private void Move()
    {
        
        Vector3 movement = new Vector3(movementX * movementSpeed, 0, movementZ * movementSpeed);
        //Vector3 movement = new Vector3(movementVector.x * movementSpeed, 0, movementVector.y * movementSpeed);
        characterRigidbody.velocity = movement;
    }

    #endregion

    #region GetSet
    public LayerMask GetTeam()
    {
        //return LayerMask.LayerToName(this.gameObject.layer);//gameObject.layer.ToString();
        return gameObject.layer;
    }
    public void SetWeapon(Weapon weapon)
    {
        characterWeapon = weapon;
    }
    public Weapon GetWeapon()
    {
        return characterWeapon;
    }
    public WeaponHandler GetWeaponHandler()
    {
        return weaponHandler;
    }
    public Transform GetTransform()
    {
        return characterTransform;
    }
    public Character GetCharacter()
    {
        return this;
    }
    public string GetNickname()
    {
        return nickname;
    }
    public void ChangeNicknameState()
    {
        if (nicknameObject.isActiveAndEnabled)
        {
            nicknameObject.gameObject.SetActive(false);
        }
        else
        {
            nicknameObject.gameObject.SetActive(true);
        }
    }
    #endregion
    
}
