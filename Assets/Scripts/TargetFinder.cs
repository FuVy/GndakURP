using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    DummyWeapon weapon;
    Character target;
    private void OnTriggerEnter(Collider other)
    {
        target = other.GetComponent<Character>();
        if (target)
        {
            transform.parent.GetComponent<Dummy>().SetTarget(target);
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
