using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon stats")]
    [SerializeField]
    float reloadTime = 0.7f;
    [SerializeField]
    int damage = 30;
    [SerializeField]
    int maximumMagazineCapacity = 20;
    [SerializeField]
    float firerate = 0.1f;
    [SerializeField]
    float bulletSpeed = 4f;
    [SerializeField]
    Vector3 weaponOffset;
    [SerializeField]
    protected float desiredZRotation = -45f;
    [SerializeField]
    ShootingPosition[] shootingPositions;
    [SerializeField]
    AudioSource[] audioSources;

    protected Transform characterTransform;
    protected Transform weaponBody;
    Transform objectTransform;
    Camera mainCamera;
    protected Looker looker;
    Animator animator;

    protected Character character; 
    
    protected bool ableToShoot;
    protected bool isReloading;
    int currentMagazineSize;

    private void Awake()
    {
        objectTransform = GetComponent<Transform>();
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
        weaponBody = objectTransform.Find("Body");
        looker = GetComponent<Looker>();
    }
    protected virtual void Start()
    {
        animator.SetFloat("reloadTime", 1f/reloadTime);
        currentMagazineSize = maximumMagazineCapacity;
        ableToShoot = true;
        SetWeaponOffset();
        gameObject.layer = characterTransform.gameObject.layer;
    }

    protected virtual void FixedUpdate()
    {
        objectTransform.position = characterTransform.position;    // + weaponOffset;
    }
    private void Update()
    {
        looker.RotateObject(weaponBody.transform, desiredZRotation);
        
        //looker.RotateObject();

        HandleShooting();
    }
    private void SetWeaponOffset()
    {
        weaponBody.localPosition = weaponOffset;
    }

    #region Shooting
    IEnumerator WaitBeforeShooting()
    {
        ableToShoot = false;
        currentMagazineSize--;
        yield return new WaitForSeconds(firerate);
        if (currentMagazineSize > 0)
        {
            ableToShoot = true;
        }
        else if (!isReloading)
        {
            HandleReloading(); //auto reload
        }
    }

    IEnumerator WaitForReload()
    {
        yield return new WaitForSeconds(reloadTime);
        Reload();
    }
    private void Fire()
    {
        audioSources[0].Play();
        animator.SetTrigger("Fire");
        for (int i = 0; i < shootingPositions.Length; i++)
        {
            shootingPositions[i].Fire(damage, character.GetTeam(), bulletSpeed);
        }
    }
    private void HandleShooting()
    {
        if ((Input.GetAxisRaw("Fire1") == 1) && ableToShoot && !isReloading)
        {
            Shoot();
        }
        if (Input.GetAxisRaw("Reload") == 1 && !isReloading)
        {
            HandleReloading();
        }
    }

    protected void Shoot()
    {
        Fire();
        StartCoroutine(WaitBeforeShooting());
    }

    private void HandleReloading()
    {
        audioSources[1].Play();
        currentMagazineSize = 0;
        isReloading = true;
        ableToShoot = false;
        animator.SetTrigger("Reload");
        StartCoroutine(WaitForReload());
    }
    private void Reload()
    {
        currentMagazineSize = maximumMagazineCapacity;
        ableToShoot = true;
        isReloading = false;
    }
    #endregion

    #region GetSet
    public void SetCharacter(Character character)
    {
        this.character = character;
        characterTransform = character.GetComponent<Transform>();
        DummyTest();
    }
    protected void Setup(float reloadTime, int damage, int maximumMagazineCapacity, float firerate, float bulletSpeed, Vector3 weaponOffset, float desiredZRotation, ShootingPosition[] shootingPositions, AudioSource[] audioSources)
    {
        this.reloadTime = reloadTime;
        this.damage = damage;
        this.maximumMagazineCapacity = maximumMagazineCapacity;
        this.firerate = firerate;
        this.bulletSpeed = bulletSpeed;
        this.weaponOffset = weaponOffset;
        this.desiredZRotation = desiredZRotation;
        this.shootingPositions = shootingPositions;
        this.audioSources = audioSources;
    }
    #endregion
    private void DummyTest()
    {
        Dummy dummy = character.GetComponent<Dummy>();
        if (dummy)
        {
            DummyWeapon dummyWeapon = gameObject.AddComponent<DummyWeapon>();
            dummyWeapon.Setup(reloadTime, damage, maximumMagazineCapacity, firerate, bulletSpeed, weaponOffset, desiredZRotation, shootingPositions, audioSources);
            dummyWeapon.SetCharacter(character);
            Destroy(this);
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
