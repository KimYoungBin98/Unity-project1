﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;    //총알공장
    public GameObject firePoint;        //총알 발사 위치


    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        //마우스 왼쪽버튼 or 왼쪽 컨트롤 키
        if (Input.GetButtonDown("Fire1"))
        {
            //총알공장(총알 프리팹)에서 총알을 무한대로 찍어낼 수 있다.
            //Instantiate()함수로 프리팹 파일을 게임 오브젝트로 만든다.

            //총알 게임 오브젝트 만들기
            GameObject bullet = Instantiate(bulletFactory);
            //총알 오브젝트의 위치 지정
            //bullet.transform.position = transform.position;
            bullet.transform.position = firePoint.transform.position;
        }
    }
}
