﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField]
    //GameObject weaponObject;
    Weapon weapon;
    [SerializeField]
    float cooldown = 10f;

    //[SerializeField]
    MeshFilter weaponMesh;
    [SerializeField]
    MeshFilter pickupMesh;
    //Transform objectTransform;
    Collider objectCollider;
    [SerializeField]
    GameObject body;
    private void Awake()
    {
        //objectTransform = GetComponent<Transform>();

        //weaponMesh = weaponObject.transform.Find("Body/AnimatedBody").GetComponent<MeshFilter>();
        //objectTransform.Find("PickupBody").GetComponent<MeshFilter>().mesh = weaponMesh.sharedMesh;
        //weapon = weaponObject.GetComponent<Weapon>();
        //body = objectTransform.Find("PickupBody").gameObject;
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
