using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField]
    GameObject weaponObject;
    [SerializeField]
    float cooldown = 10f;

    Weapon weapon;
    MeshFilter weaponMesh;
    Transform objectTransform;
    Collider objectCollider;
    GameObject body;
    private void Awake()
    {
        objectTransform = GetComponent<Transform>();
        weaponMesh = weaponObject.transform.Find("Body/AnimatedBody").GetComponent<MeshFilter>();
        objectTransform.Find("PickupBody").GetComponent<MeshFilter>().mesh = weaponMesh.sharedMesh;
        weapon = weaponObject.GetComponent<Weapon>();
        objectCollider = GetComponent<CapsuleCollider>();
        body = objectTransform.Find("PickupBody").gameObject;
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
