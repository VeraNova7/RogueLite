using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    [SerializeField] SpriteRenderer highlight;
    [SerializeField] Image image;
    [SerializeField] ShipBase shipBase;
    [SerializeField] ShieldBase shieldBase;
    [SerializeField] WeaponBase weaponBase;
    [SerializeField] MenuDescription menuDescription;
    [SerializeField] SystemManager systemManager;

    public bool ship;
    public bool shield;
    public bool weapon;

    private Color highlightColor;

    void Start()
    {
        highlightColor = highlight.color;
        highlight.color = new Color(highlightColor.r, highlightColor.g, highlightColor.b, 0);
        if (ship)
        {
            image.sprite = shipBase.ShipSprite;
        }
        if (shield)
        {
            image.sprite = shieldBase.Circle;
            image.color = shieldBase.ShieldColor;
        }
        if (weapon)
        {
            image.sprite = weaponBase.WeaponSprite;
        }
    }

    private void OnMouseEnter()
    {
        highlight.color = new Color(highlightColor.r, highlightColor.g, highlightColor.b, 1);
        if (ship)
        {
            menuDescription.SetDescription(shipBase);
        }
        if (shield)
        {
            menuDescription.SetDescription(shieldBase);
        }
        if (weapon)
        {
            menuDescription.SetDescription(weaponBase);
        }
    }

    private void OnMouseExit()
    {
        highlight.color = new Color(highlightColor.r, highlightColor.g, highlightColor.b, 0);
    }
    private void OnMouseDown()
    {
        if (ship)
        {
            systemManager.ChooseShip(shipBase);
        }
        if (shield)
        {
            systemManager.ChooseShield(shieldBase);
        }
        if (weapon)
        {
            systemManager.ChooseWeapon(weaponBase);
            systemManager.StartGame();
        }
    }
}
