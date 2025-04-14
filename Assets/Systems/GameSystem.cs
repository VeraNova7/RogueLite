using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    [SerializeField] new GameObject camera;
    [SerializeField] PlayerController player;
    public void StartGame(ShipBase ship, ShieldBase shield, WeaponBase weapon)
    {
        camera.SetActive(true);
        player.ChooseShip(ship);
        player.ChooseShield(shield);
        player.ChooseWeapon(weapon);
        player.StartGame();
    }
    public void EndGame()
    {
        camera.SetActive(false);
        player.EndGame();
    }
}
