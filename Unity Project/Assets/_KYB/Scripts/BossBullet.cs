using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public GameObject enemyBullet;
    public float speed = 5.0f;      //에너미 이동속도

    float timer;
    float coolTimer = 0.5f;

    float pattonTimer;
    float pattonCoolTimer = 2f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > coolTimer)
        {
            timer = 0;
            GameObject bullet = Instantiate(enemyBullet);
            bullet.transform.position = transform.position;
            bullet.GetComponent<EnemyBullet>().initBullet();
        }
        pattonTimer += Time.deltaTime;
        if (pattonTimer > pattonCoolTimer)
        {
            pattonTimer = 0;
            shot();
        }
    }

    void shot()
    {
        //360번 반복
        for (int i = 0; i < 20; i++)
        {
            //총알 생성
            GameObject bullet = Instantiate(enemyBullet);

            //총알 생성 위치를 (0,0) 좌표로 한다.
            bullet.transform.position = transform.position;

            //Z에 값이 변해야 회전이 이루어지므로, Z에 i를 대입한다.
            bullet.transform.Rotate(0, i * 18, 0);
            bullet.tag = "Boss";
        }
        // Update is called once per frame

    }
}
