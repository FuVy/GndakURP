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
        
        playerRigidbody = GetComponent<Rigidbody>();
        //radius = GetComponent<SphereCollider>().radius;
        playerTransform = GetComponent<Transform>();
    }
    private void Start()
    {
        SetWeapon(playerWeapon);
        Debug.Log(GetTeam());
    }
    void Update()
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
    public void SetWeapon(Weapon weapon)
    {
        Weapon newWeapon = Instantiate(weapon, playerTransform.position, Quaternion.identity);

        playerWeapon = newWeapon;
        playerWeapon.SetPlayer(this);
    }
    public void DestroyWeapon()
    {
        playerWeapon?.Destroy();
    }

    #endregion
}
