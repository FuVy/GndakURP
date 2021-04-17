using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField]
    GameObject weaponObject;
    Weapon weapon;
    MeshFilter weaponMesh;
    Transform objectTransform;
    int maxUses;
    int currentUses;
    private void Awake()
    {
        objectTransform = GetComponent<Transform>();
        weaponMesh = weaponObject.transform.Find("Body/AnimatedBody").GetComponent<MeshFilter>();
        objectTransform.Find("PickupBody").GetComponent<MeshFilter>().mesh = weaponMesh.sharedMesh;
        weapon = weaponObject.GetComponent<Weapon>();
    }
    private void Start()
    {
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(weaponMesh);
        Player player = other.GetComponent<Player>();
        if (player)
        {
            Weapon newWeapon = Instantiate(weapon, player.transform.position, Quaternion.identity);
            player.DestroyWeapon();
            player.SetWeapon(newWeapon);
        }
        
    }
}
