using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    DummyWeapon weapon;
    Character target;
    Dummy dummyObject;
    
    private void Awake()
    {
        dummyObject = transform.parent.GetComponent<Dummy>();
    }
    private void OnTriggerStay(Collider other) 
    {
        //Debug.Log(other.name);
        target = other.GetComponent<Character>();
        //if (target)
        //{
            dummyObject.SetTarget(target);
            weapon.SetTarget(target);
        //}
    }
    public void SetWeapon(DummyWeapon weapon)
    {
        this.weapon = weapon;
    }
    private void OnTriggerExit(Collider collision)
    {
        weapon.SetTarget(null);
    }
}
