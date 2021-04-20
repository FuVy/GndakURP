using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    Rigidbody characterRigidbody;
    protected Transform characterTransform;
    Weapon characterWeapon;

    float movementX;
    float movementZ;
    Vector2 movementVector;

    [SerializeField]
    float movementSpeed;
    protected virtual void Awake()
    {
        characterRigidbody = GetComponent<Rigidbody>();
        characterTransform = GetComponent<Transform>();
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
    #endregion
    
}
