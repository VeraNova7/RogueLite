using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shield", menuName = "Shield")]

public class ShieldBase : ScriptableObject
{
    [SerializeField] new string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Color shieldColor;

    [SerializeField] int maxShield;
    [SerializeField] float cooldown;
    [SerializeField] float hpMultiplier;
    [SerializeField] float speedMultiplier;
    [SerializeField] float sizeMultiplier;
    [SerializeField] float damageMultiplier;
    [SerializeField] float massMultiplier;


    private Sprite circle;

    private void OnEnable()
    {
        circle = Resources.Load<Sprite>("Circle");
    }

    public string Name
    {
        get { return name; }
    }

    public string Description
    {
        get { return description; }
    }

    public Color ShieldColor
    {
        get { return shieldColor; }
    }
    public int MaxShield
    {
        get { return maxShield; }
    }
    public float HPMultiplier
    {
        get { return hpMultiplier; }
    }
    public float Cooldown
    {
        get { return cooldown; }
    }
    public float SpeedMultiplier
    {
        get { return speedMultiplier; }
    }
    public float SizeMultiplier
    {
        get { return sizeMultiplier; }
    }
    public float DamageMultiplier
    {
        get { return damageMultiplier; }
    }
    public float MassMultiplier
    {
        get { return massMultiplier; }
    }
    public Sprite Circle
    {
        get { return circle; }
    }
}