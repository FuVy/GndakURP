using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : Character
{
    [SerializeField]
    Character target;
    [SerializeField]
    LayerMask layerMask;
    private void FixedUpdate()
    {  

    }
    public Character GetTarget()
    {
        return target;
    }
    public void SetTarget(Character target)
    {
        this.target = target;
    }
}
