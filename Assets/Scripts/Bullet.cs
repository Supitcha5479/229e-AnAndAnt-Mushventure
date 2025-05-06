using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Bullet : Weapon
{
    [SerializeField] private float shootDuration = 1f;
    private Rigidbody2D rb;

    void Start()
    {
        Damage = 30;
        rb = GetComponent<Rigidbody2D>();
    }

    

    public override void OnHitWith(Character character)
    {
        if (character is Enemy)
        {
            character.TakeDamage(this.Damage);
        }
    }

    public void ShootTo(Vector2 target)
    {
        Vector2 origin = transform.position;
        Vector2 velocity = CalculateProjectileVelocity(origin, target, shootDuration);
        rb.linearVelocity = velocity;
    }

    private Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;
        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;
        return new Vector2(velocityX, velocityY);
    }

}
