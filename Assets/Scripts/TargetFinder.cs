using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    DummyWeapon weapon;
    Character target;
    Dummy dummyObject;
    LayerMask friendlyLayer;
    private void Awake()
    {
        dummyObject = transform.parent.GetComponent<Dummy>();
        friendlyLayer = dummyObject.gameObject.layer;
    }
    
    private void OnTriggerStay(Collider other) 
    {
        //Debug.Log(other.name);
        target = other.GetComponent<Character>();
        if (other.gameObject.layer != friendlyLayer)
        {
            dummyObject.SetTarget(target);
            weapon.SetTarget(target);
        }
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
