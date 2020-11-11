using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
//자동으로 원하는 컴포넌트를 추가한다
//반드시 필요한 컴포넌트를 실수로 삭제할 수 있기 때문에 강제로 붙어있게 해준다.
public class Enemy : MonoBehaviour
{
    //에너미의 역할?
    //똥피하기 느낌으로 위에서 아래로 떨어진다.
    //에너미가 플레이어를 향해서 총알을 발사한다.
    //충돌처리 - 리지드바디 사용하자

    //유니티 어트리뷰트[] 공부하기

    public float speed = 5.0f;      //에너미 이동속도

    // Update is called once per frame
    void Update()
    {
        //아래로 이동해라
        EnemyMove();
    }

    void EnemyMove()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //자기 자신도 없애고
        //충돌된 오브젝트도 날린다
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }

}
