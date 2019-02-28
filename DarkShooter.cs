using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkShooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject firePosition;

    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, firePosition.transform.position, transform.rotation);
    }
}
