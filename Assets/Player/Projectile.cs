using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] SpriteRenderer spriteRenderer;

    private Vector2 targetVelocity;

    float speed;
    float damage;

    public void Create(Vector2 target, Vector2 startPos, float rotationMod, WeaponBase weaponBase, float damage, float speed)
    {
        transform.position = startPos;
        spriteRenderer.sprite = weaponBase.WeaponSprite;
        this.speed = speed * 50;
        this.damage = damage;
        transform.up = (new Vector2(target.x, target.y) - new Vector2(transform.position.x, transform.position.y)).normalized;
        transform.Rotate(Vector3.forward * rotationMod);
        targetVelocity = transform.up;
        Move(targetVelocity);
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(damage);
    }

    void Move(Vector3 targetVelocity)
    {
        rigidbody.velocity += speed * Time.fixedDeltaTime * new Vector2(targetVelocity.x, targetVelocity.y);
    }
}
