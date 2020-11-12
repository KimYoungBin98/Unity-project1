using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject playerPos;
    public GameObject enemy;
    Vector3 dir;

    public void initBullet()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player");
        if (playerPos != null) dir = playerPos.transform.position - transform.position;
        else dir = Vector3.back;
        dir.Normalize();
    }
    // Update is called once per framew
    void Update()
    {
        if (gameObject.tag == "Boss")
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(dir * speed * Time.deltaTime);
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Destroy(playerPos);
    //        Destroy(collision.gameObject);
    //    }
    //}
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
