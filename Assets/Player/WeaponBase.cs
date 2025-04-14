using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]

public class WeaponBase : ScriptableObject
{
    [SerializeField] new string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite weaponSprite;

    [SerializeField] float damage;
    [SerializeField] float attacksPerSecond;
    [SerializeField] float speedMultiplier;
    [SerializeField] float shieldCooldownMultiplier;
    [SerializeField] float weaponSize;
    [SerializeField] float spread;
    [SerializeField] float projectileSpeed;
    
    public string Name
    {
        get { return name; }
    }

    public string Description
    {
        get { return description; }
    }

    public Sprite WeaponSprite
    {
        get { return weaponSprite; }
    }
    public float Damage
    {
        get { return damage; }
    }
    public float AttacksPerSecond
    {
        get { return attacksPerSecond; }
    }
    public float SpeedMultiplier
    {
        get { return speedMultiplier; }
    }
    public float ShieldCooldownMultiplier
    {
        get { return shieldCooldownMultiplier; }
    }
    public float WeaponSize
    {
        get { return weaponSize; }
    }
    public float Spread
    {
        get { return spread; }
    }
    public float ProjectileSpeed
    {
        get { return projectileSpeed; }
    }
}