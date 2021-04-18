using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyWeapon : Weapon
{
    [SerializeField]
    Character target = null;
    Transform targetTransform;
    LayerMask layerMask;
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
    new private void Update()
    {
        
    }
    new public void SetCharacter(Character character)
    {
        Debug.Log(character);
        this.character = character;
        characterTransform = character.GetComponent<Transform>();
        character.GetComponent<WeaponHandler>().SetCurrentWeapon(this);
        character.transform.Find("TargetFinder").GetComponent<TargetFinder>().SetWeapon(this);
    }
    public void SetTarget(Character target)
    {
        Debug.Log(target);
        this.target = target;
        if (target)
        {
            targetTransform = target.transform;
        }
    }
}
