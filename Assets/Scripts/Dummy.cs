using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : Character
{
    [Header("Dummy settings")]
    [SerializeField]
    Character target;
    [SerializeField]
    LayerMask layerMask;
    [SerializeField]
    TargetFinder targetFinder;
    void Start()
    {
        nickname = "dummy";
    }
    private void OnEnable()
    {
        target = null;
    }
    private void FixedUpdate() 
    {  

    }
    #region GetSet
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
    #endregion
}
