using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField]
    Weapon weapon;
    [SerializeField]
    float cooldown = 10f;

    MeshFilter weaponMesh;
    [SerializeField]
    MeshFilter pickupMesh;
    Collider objectCollider;
    [SerializeField]
    GameObject body;
    private void Awake()
    {
        weaponMesh = weapon.GetMeshFilter();
        pickupMesh.mesh = weaponMesh.sharedMesh;
        objectCollider = GetComponent<CapsuleCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        WeaponHandler weaponHandler = other.GetComponent<WeaponHandler>();
        if (weaponHandler)
        {
            weaponHandler.DestroyWeapon();
            weaponHandler.SetWeapon(weapon);
            StartCoroutine(StartCooldown());
        }
    }
    IEnumerator StartCooldown()
    {
        body.SetActive(false);
        objectCollider.enabled = false;
        yield return new WaitForSeconds(cooldown);
        body.SetActive(true);
        objectCollider.enabled = true;
    }
}
