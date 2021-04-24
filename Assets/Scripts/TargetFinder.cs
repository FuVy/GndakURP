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
    Transform dummyTransform;
    LayerMask friendlyLayer;
    private void Awake()
    {
        //dummyObject = transform.parent.GetComponent<Dummy>();
        dummyTransform = dummyObject.transform;
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
    /*
    private void FixedUpdate()
    {
        dummyObject.SetTarget(null);
        weapon.SetTarget(null);

        Collider[] hitColliders = Physics.OverlapSphere(dummyTransform.position, radius);
        foreach (Collider hitCollider in hitColliders)
        {
            target = hitCollider.GetComponent<Character>();
            if (hitCollider.gameObject.layer != friendlyLayer)
            {
                //dummyObject = hitCollider.GetComponent<>
                hitCollider.SendMessage("SetTarget",target); //todo посмотреть кто ближайший
            }
        }
    }
    */
    public void SetWeapon(DummyWeapon weapon)
    {
        this.weapon = weapon;
    }
    private void OnTriggerExit(Collider collision)
    {
        weapon.SetTarget(null);
    }
}
