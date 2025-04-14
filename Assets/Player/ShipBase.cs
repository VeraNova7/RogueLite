using UnityEngine;

[CreateAssetMenu(fileName = "Ship", menuName = "Ship")]

public class ShipBase : ScriptableObject
{
    [SerializeField] new string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite shipSprite;

    [SerializeField] int maxHP;
    [SerializeField] float shieldMultiplier;
    [SerializeField] float damageMultiplier;
    [SerializeField] float attackSpeedMultiplier;
    [SerializeField] float moveSpeed;
    [SerializeField] float sizeMultiplier;
    [SerializeField] float mass;
    [SerializeField] float weaponSizeModifier;

    public string Name
    {
        get { return name; }
    }

    public string Description
    {
        get { return description; }
    }

    public Sprite ShipSprite
    {
        get { return shipSprite; }
    }

    public int MaxHP
    {
        get { return maxHP; }
    }
    public float ShieldMultiplier
    {
        get { return shieldMultiplier; }
    }
    public float DamageMultiplier
    {
        get { return damageMultiplier; }
    }
    public float AttackSpeedMultiplier
    {
        get { return attackSpeedMultiplier; }
    }
    public float MoveSpeed
    {
        get { return moveSpeed; }
    }
    public float SizeMultiplier
    {
        get { return sizeMultiplier; }
    }
    public float Mass
    {
        get { return mass; }
    }
    public float WeaponSizeModifier
    {
        get { return weaponSizeModifier; }
    }
}