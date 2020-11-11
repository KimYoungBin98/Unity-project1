using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemySpawn;
    public GameObject enemyManager;
    float timer = 0;
    float coolTime = 0.5f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > coolTime)
        {
            timer = 0;
            GameObject enemy = Instantiate(enemySpawn);
            enemy.transform.position = new Vector3(Random.Range(-3,5), 0, enemyManager.transform.position.z);
        }
    }
}
