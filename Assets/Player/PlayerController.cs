using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] ShipBase shipBase;
    [SerializeField] ShieldBase shieldBase;
    [SerializeField] WeaponBase weaponBase;
    [SerializeField] GameObject hull;
    [SerializeField] GameObject shield;
    [SerializeField] GameObject thrusters;
    [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] float friction;

    [SerializeField] GameObject projectile;

    private float currentHP;
    private int currentShield;

    private int maxHP;
    private int maxShield;
    private float shieldCooldown;
    private float damage;
    private float attacksPerSecond;
    private float weaponSize;
    private float weaponSpread;
    private float projectileSpeed;
    private float moveSpeed;
    private float sizeMultiplier;
    private float mass;

    private bool gameRunning;

    private float fireTiming;

    // Start is called before the first frame update
    void Start()
    {
        fireTiming = 0;
        gameRunning = false;
        thrusters.SetActive(false);

        Color tempColor = shield.GetComponent<SpriteRenderer>().color;
        tempColor.a = .2f;
        shield.GetComponent<SpriteRenderer>().color = tempColor;
    }
    private void Update()
    {
        fireTiming += Time.deltaTime;
        if (gameRunning)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // fire projectile
            if (Input.GetMouseButton(1) && fireTiming > 1/attacksPerSecond)
            {
                float rotationMod = Random.Range(-.5f * weaponSpread, .5f * weaponSpread);
                //Vector3 rotation = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.x * rotationMod);
                
                fireTiming = 0;
                Instantiate(projectile, transform.position, Quaternion.identity, transform.root).GetComponent<Projectile>().Create(mousePosition, transform.position, rotationMod, weaponBase, damage, projectileSpeed);
            }
        }
    }

    void FixedUpdate()
    {
        if (gameRunning)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 targetVelocity = (mousePosition - new Vector2(transform.position.x,transform.position.y)).normalized;
            // rotation
            transform.up = new Vector3(mousePosition.x, mousePosition.y, 0) - new Vector3(transform.position.x, transform.position.y, 0);

            // move ship
            if (Input.GetMouseButton(0))
            {
                Move(new Vector2(targetVelocity.x, targetVelocity.y));
                thrusters.SetActive(true);
            }
            else
            {
                thrusters.SetActive(false);
            }

            
        }
    }

    void Move(Vector3 targetVelocity)
    {
        rigidbody.velocity += moveSpeed * Time.fixedDeltaTime * new Vector2(targetVelocity.x, targetVelocity.y);
    }

    // for other scripts to reference
    public void ChooseShip(ShipBase shipBase)
    {
        this.shipBase = shipBase;
        hull.GetComponent<SpriteRenderer>().sprite = this.shipBase.ShipSprite;
    }
    public void ChooseShield(ShieldBase shieldBase)
    {
        this.shieldBase = shieldBase;
        shield.GetComponent<SpriteRenderer>().color = shieldBase.ShieldColor;
    }
    public void ChooseWeapon(WeaponBase weaponBase)
    {
        this.weaponBase = weaponBase;
    }
    public void StartGame()
    {
        StartCoroutine(StartGame(.5f));
    }
    IEnumerator StartGame(float time)
    {
        maxHP = (int)(shipBase.MaxHP * shieldBase.HPMultiplier);
        maxShield = (int) (shieldBase.MaxShield * shipBase.ShieldMultiplier);
        shieldCooldown = shieldBase.Cooldown * weaponBase.ShieldCooldownMultiplier;
        damage = weaponBase.Damage * shipBase.DamageMultiplier * shieldBase.DamageMultiplier;
        attacksPerSecond = weaponBase.AttacksPerSecond * shipBase.AttackSpeedMultiplier;
        weaponSize = weaponBase.WeaponSize * shipBase.WeaponSizeModifier;
        weaponSpread = weaponBase.Spread;
        projectileSpeed = weaponBase.ProjectileSpeed;
        moveSpeed = shipBase.MoveSpeed * shieldBase.SpeedMultiplier * weaponBase.SpeedMultiplier;
        sizeMultiplier = shipBase.SizeMultiplier * shieldBase.SizeMultiplier;
        mass = shipBase.Mass * shieldBase.MassMultiplier;
        print("HP: " + maxHP);
        print("Shields: " + maxShield);
        print("Shield Cooldown: " + shieldCooldown);
        print("Damage: " + damage);
        print("Attacks Per Second: " + attacksPerSecond);
        print("Weapon Size: " + weaponSize * 100 + "%");
        print("Weapon Spread: " + weaponSpread + "°");
        print("Weapon Spread: " + projectileSpeed);
        print("Move Speed: " + moveSpeed);
        print("Size Modifier: " + sizeMultiplier * 100 + "%");
        print("Mass: " + mass);

        transform.position = Vector3.zero;
        currentHP = maxHP;
        currentShield = maxShield;
        transform.localScale *= sizeMultiplier;
        rigidbody.mass = mass;

        yield return new WaitForSeconds(time);
        gameRunning = true;
    }
    public void EndGame()
    {
        gameRunning = false;
        thrusters.SetActive(false);
    }
}