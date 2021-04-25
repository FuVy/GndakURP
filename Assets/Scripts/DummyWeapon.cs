using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyWeapon : Weapon
{
    [SerializeField]
    Character target = null;
    Transform targetTransform;
    LayerMask layerMask;
    private void OnEnable()
    {
        target = null;
    }
    protected override void Start()
    {
        base.Start();
        layerMask = LayerMask.GetMask("RedTeam", "BlueTeam");
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (target != null)
        {
            looker.RotateObject(targetTransform.position, weaponBody, desiredZRotation, layerMask);
            if (ableToShoot && !isReloading)
            {
                Shoot();
            }
        }
    }
    private void Update()
    {

    }
    #region GetSet
    public void SetDummy(Dummy dummy)
    {
        this.character = dummy;
        characterTransform = dummy.GetTransform();
        dummy.GetWeaponHandler().SetCurrentWeapon(this);
        dummy.GetTargetFinder().SetWeapon(this);
    }
    public void SetTarget(Character target)
    {
        this.target = target;
        if (target)
        {
            targetTransform = target.GetTransform();
        }
    }
    #endregion
}
