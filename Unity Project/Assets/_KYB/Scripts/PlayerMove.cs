using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //플레이어 이동
    //플레이어는 사용자가 조작한다
    //따라서 입력을 받아야 한다
    //키보드, 마우스 등등 입력은 Input 매니져가 담당한다

    //이동 속력
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //getAxis 사용하는 이유?
        //멀티 플랫폼 사용 때문에 (윈도우, 안드로이드)
        //GetAxis => 1 ~ -1 사이의 값
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //이동 처리
        transform.Translate(h * speed * Time.deltaTime, v * speed * Time.deltaTime,0);
        //아래 방법도 가능 (덧셈일때는 크게 상관없지만 뺄셈을 써야 할 경우 아래 방법이 더 좋음)
        //Vector3 dir = Vector3.right * h + Vector3.forward * v;
        //벡터의 정규화
        //dir.Normalize();
        //transform.Translate(dir * speed * Time.deltaTime);

        //중요함
        //p = p0 + vt;
        //위치 = 현재위치 + (방향 * 시간)
        //transform.position = transform.position + dir * speed * Time.deltaTime;
       // transform.position += dir * speed * Time.deltaTime;

        //플레이어를 화면밖으로 나가지 못하게 막기
        //1. 화면밖 공간에 큐브 4개를 만들어 배치하면 충돌체 때문에 밖으로 벗어나지 못한다. - 리지드 바디가 포함되어야 충돌처리가 가능함
        //2. 플레이어 트렌스폼 포지션 x,y 값을 고정시킨다.
        //3. 메인 카메라의 뷰포트를 가져와서 처리한다.
        
    }
}
