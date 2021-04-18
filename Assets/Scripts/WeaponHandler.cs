using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] 
    Weapon startingWeapon; //set starting weapon
    [SerializeField] //временно
    Weapon currentWeapon;
    Transform objectTransform;
    Character player;
    private void Awake()
    {
        objectTransform = GetComponent<Transform>();
        player = GetComponent<Character>();
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
        currentWeapon.SetCharacter(player);
    }
    public void SetCurrentWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
    }
}
