using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool isSpawning = true;
    [SerializeField] float enemySpawnRandomLow = 1f;
    [SerializeField] float enemySpawnRandomHigh = 5f;
    [SerializeField] Attacker[] attackerPrefabs;

    IEnumerator Start()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(Random.Range(enemySpawnRandomLow, enemySpawnRandomHigh));
            SpawnEnemies();
        }
    }

    public void StopSpawning()
    {
        isSpawning = false;
        StopAllCoroutines();
    }

    private void SpawnEnemies()
    {
        Attacker attacker = attackerPrefabs[Random.Range(0, attackerPrefabs.Length)];
        Spawn(attacker);
    }

    private void Spawn( Attacker attacker)
    {
        Attacker newAttacker =
                    Instantiate(attacker, transform.position, transform.rotation)
                    as Attacker;
        newAttacker.transform.parent = transform;
    }
}
