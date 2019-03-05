using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCastle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var attacker = other.GetComponent<Attacker>();
        var darkLaserProjectile = other.GetComponent<DarkLaserProjectile>();
        if (attacker || darkLaserProjectile)
        {
            FindObjectOfType<GameStatus>().DamageBase();
            Destroy(other.gameObject);
        }
    }
}
