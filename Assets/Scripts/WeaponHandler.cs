using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] 
    Weapon startingWeapon; //sets starting weapon
    [SerializeField] 
    Weapon currentWeapon;
    Transform objectTransform;
    Character character;
    private void Awake()
    {
        objectTransform = GetComponent<Transform>();
        character = GetComponent<Character>();
    }
    public void Start()
    {
        SetWeapon(startingWeapon);
    }
    public void DestroyWeapon()
    {
        currentWeapon?.Destroy(); 
        currentWeapon = null;
    }
    public void SetWeapon(Weapon weapon)
    {
        Weapon newWeapon = Instantiate(weapon, objectTransform.position, Quaternion.identity);

        currentWeapon = newWeapon;
        currentWeapon.SetCharacter(character);
    }
    public void SetCurrentWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
    }
}
