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
    float desiredZRotation = -45f;
    [SerializeField]
    ShootingPosition[] shootingPositions;

    protected Transform playerTransform;
    protected Transform weaponBody;
    protected Transform objectTransform;
    protected Camera mainCamera;
    protected LookAtMouse looker;
    protected Animator animator;

    [SerializeField]
    protected Player player; //Временно, заменить в конце
    
    bool ableToShoot;
    bool isReloading;
    int currentMagazineSize;
    string team;

    private void Awake()
    {
        
        objectTransform = GetComponent<Transform>();
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
        weaponBody = objectTransform.Find("Body");
        looker = GetComponent<LookAtMouse>();
    }
    void Start()
    {
        animator.SetFloat("reloadTime", 1f/reloadTime);
        currentMagazineSize = maximumMagazineCapacity;
        ableToShoot = true;
        team = player.GetTeam();
        //gameObject.layer = LayerMask.NameToLayer(team);
        SetWeaponOffset();
    }

    void FixedUpdate()
    {
        objectTransform.position = playerTransform.position;    // + weaponOffset;
    }
    protected virtual void Update()
    {
        looker.RotateObject(weaponBody.transform, desiredZRotation);
        
        //looker.RotateObject();

        HandleShooting();
    }
    public void SetWeaponOffset()
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
    private void Shoot()
    {
        animator.SetTrigger("Fire");
        for (int i = 0; i < shootingPositions.Length; i++)
        {
            shootingPositions[i].Fire(damage, team, bulletSpeed);
        }
    }
    private void HandleShooting()
    {
        if ((Input.GetAxisRaw("Fire1") == 1) && ableToShoot && !isReloading)
        {
            Shoot();
            StartCoroutine(WaitBeforeShooting());
        }
        if (Input.GetAxisRaw("Reload") == 1 && !isReloading)
        {
            HandleReloading();
        }
    }
    private void HandleReloading()
    {
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
    public void SetPlayer(Player player)
    {
        this.player = player;
        playerTransform = player.GetComponent<Transform>();

    }
    #endregion
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
