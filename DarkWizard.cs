using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<DefenderSpawner>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }


}
