using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    [SerializeField]
    float radius;
    DummyWeapon weapon;
    Character target;
    [SerializeField]
    Dummy dummyObject;
    LayerMask friendlyLayer;
    private void Awake()
    {
        friendlyLayer = dummyObject.gameObject.layer;
    }
    
    private void OnTriggerStay(Collider other) 
    {
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
