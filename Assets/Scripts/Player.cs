using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody playerRigidbody;
    Transform playerTransform;
    [SerializeField] //Временно
    Weapon playerWeapon;    

    float movementX;
    float movementZ;

    [SerializeField]
    float movementSpeed;


    void Awake()
    {
        //SetWeapon(playerWeapon);
        playerRigidbody = GetComponent<Rigidbody>();
        //radius = GetComponent<SphereCollider>().radius;
        playerTransform = GetComponent<Transform>();
    }
    private void Start()
    {
        SetDefaultWeapon();
        Debug.Log(GetTeam());

    }
    // Update is called once per frame
    void Update()
    {
        UpdateMovementAxis();
    }
    private void FixedUpdate()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.F)) //Убрать
        {
            SetWeapon(FindObjectOfType<Shotgun>());
        }
    }

    #region Movement
    private void UpdateMovementAxis()
    {
        movementX = Input.GetAxis("Horizontal");
        movementZ = Input.GetAxis("Vertical");
    }
    private void Move()
    {
        Vector3 movement = new Vector3(movementX * movementSpeed, 0, movementZ * movementSpeed);
        playerRigidbody.velocity = movement;
    }

    #endregion

    #region GetSet
    public string GetTeam()
    {
        return LayerMask.LayerToName(this.gameObject.layer);//gameObject.layer.ToString();
    }

    void SetDefaultWeapon()
    {
        playerWeapon.SetPlayer(this);
    }
    public void SetWeapon(Weapon weapon)
    {
        //playerWeapon?.Destroy();
        playerWeapon = weapon;
        playerWeapon.SetPlayer(this);
        //weapon.SetWeaponOffset();
    }
    public void DestroyWeapon()
    {
        playerWeapon.Destroy();
    }

    /*
    public void SetWeapon(Weapon weapon)
    {
        playerWeapon = weapon;
        weapon.SetPlayer(this);
    }
    public void SetWeapon(Weapon weapon, MeshFilter mesh)
    {
        playerWeapon = weapon;
        //Debug.Log(mesh);
        weapon.SetMesh(mesh);
        
        weapon.SetPlayer(this);
    }
    */

    #endregion
}
