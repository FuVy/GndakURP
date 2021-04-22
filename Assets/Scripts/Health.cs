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
    public int GetHealth()
    {
        return currentHealth;
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
        GetComponent<WeaponHandler>().Start();
        GetComponent<Character>().enabled = true;
        Camera.main.GetComponent<CameraFollow>().enabled = true;
        GetComponent<SphereCollider>().enabled = true;
        transform.Find("Body").GetComponent<MeshRenderer>().enabled = true;
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
        GetComponent<WeaponHandler>().DestroyWeapon();
        Character character = GetComponent<Character>();
        character.enabled = false;
        Camera.main.GetComponent<CameraFollow>().CheckPlayer(character);
        transform.Find("Body").GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
    }
    IEnumerator WaitForRespawn()
    {
        yield return new WaitForSeconds(respawnTime);
        Respawn();
    }
}
