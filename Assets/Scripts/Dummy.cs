using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : Character
{
    [SerializeField]
    Character target;
    [SerializeField]
    LayerMask layerMask;
    [SerializeField]
    TargetFinder targetFinder;
    private void OnEnable()
    {
        target = null;
    }
    private void FixedUpdate()
    {  

    }
    public Character GetTarget()
    {
        return target;
    }
    public TargetFinder GetTargetFinder()
    {
        return targetFinder;
    }
    public void SetTarget(Character target)
    {
        this.target = target;
    }
}
