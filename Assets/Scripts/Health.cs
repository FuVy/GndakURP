using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    int maxHealth = 100;
    [SerializeField]
    int currentHealth = 100;
    [SerializeField]
    Vector3 respawnPosition;
    [SerializeField]
    float respawnTime = 0f;
    [SerializeField]
    HealthBar healthBar;

    WeaponHandler weaponHandler;
    Character character;
    CameraFollow cameraFollow;
    Collider attachedCollider;
    [SerializeField]
    MeshRenderer meshRenderer;
    private void Awake()
    {
        weaponHandler = GetComponent<WeaponHandler>();
        character = GetComponent<Character>();
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
        attachedCollider = GetComponent<SphereCollider>();
    }
    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        healthBar?.SetSlider(currentHealth);
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Setup()
    {
        currentHealth = maxHealth;
        weaponHandler.Start();
        character.enabled = true;
        cameraFollow.enabled = true;
        attachedCollider.enabled = true;
        meshRenderer.enabled = true;
        healthBar?.SetMaxHealth(maxHealth);
    }
    private void Respawn()
    {
        transform.position = respawnPosition;
        Setup();
    }
    private void Die()
    {
        //instantiate death vfx
        HideCharacter();
        if (respawnTime != 0f)
        {
            StartCoroutine(WaitForRespawn());
        }
    }
    private void HideCharacter()
    {
        weaponHandler.DestroyWeapon();
        character.enabled = false;
        cameraFollow.CheckPlayer(character);
        meshRenderer.enabled = false;
        attachedCollider.enabled = false;
    }
    IEnumerator WaitForRespawn()
    {
        yield return new WaitForSeconds(respawnTime);
        Respawn();
    }
    public int GetHealth()
    {
        return currentHealth;
    }
}
