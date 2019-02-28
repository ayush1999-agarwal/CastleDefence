using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkLaserProjectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] int damage = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var health = other.GetComponent<Health>();
        var defender = other.GetComponent<Defender>();
        var hitCastle = other.GetComponent<HitCastle>();
        if (defender && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
        else if (hitCastle)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * projectileSpeed);
    }
}
