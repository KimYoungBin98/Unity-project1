﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoketFire : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletFactory;    //총알공장
    public GameObject firePoint;        //총알 발사 위치

    float timer;
    float CoolTime;
    private void Start()
    {
        timer = 0.0f;
        CoolTime = 0.5f;
    }
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        timer += Time.deltaTime;
        if (timer > CoolTime)
        {
            timer = 0;
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePoint.transform.position;
        }
    }
}
