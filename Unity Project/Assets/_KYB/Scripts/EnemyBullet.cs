using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject playerPos;
    public GameObject enemy;
    Vector3 dir;
    private void Awake()
    {

        playerPos = GameObject.FindGameObjectWithTag("Player");
        if (playerPos != null) dir = playerPos.transform.position - transform.position;
        else dir = Vector3.back;
    }
    // Update is called once per frame
    void Update()
    {
        dir.Normalize();
        transform.Translate(dir * speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(playerPos);
            Destroy(collision.gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
