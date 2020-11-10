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
    public float speed = 10.0f;
    private Rigidbody playerRigidbody;

    public Vector2 margin;  //뷰포트 좌표는 (0, 0) ~ (1, 1) 사이의 값을 사용한다.
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
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
        //transform.Translate(h * speed * Time.deltaTime, 0, v * speed * Time.deltaTime);
        //아래 방법도 가능 (덧셈일때는 크게 상관없지만 뺄셈을 써야 할 경우 아래 방법이 더 좋음)
       // Vector3 dir = Vector3.right * h + Vector3.forward * v;
        Vector3 dir = new Vector3(h, 0, v);
        //벡터의 정규화
        //dir.Normalize();
        //transform.Translate(dir * speed * Time.deltaTime);

        //Vector3.zero == new Vector3(0, 0, 0);
        //Vector3.one == new Vector3(1, 1, 1);
        //Vector3.right == new Vector3(1, 0, 0);
        //Vector3.left == new Vector3(-1, 0, 0);
        //Vector3.forward = new Vector3(0, 0, 1);
        //Vector3.back = new Vector3(0, 0, -1);
        //Vector3.up = new Vector3(0, 1, 0);
        //Vector3.down = new Vector3(0, -1, 0);

        //중요함
        //p = p0 + vt;
        //위치 = 현재위치 + (방향 * 시간)
        //transform.position = transform.position + dir * speed * Time.deltaTime;
        transform.position += dir * speed * Time.deltaTime;


        //1. 화면밖 공간에 큐브 4개를 만들어 배치하면 충돌체 때문에 밖으로 벗어나지 못한다. - 리지드 바디가 포함되어야 충돌처리가 가능함
        //playerRigidbody.velocity = new Vector3(h * speed, 0, v * speed);

        // 1 * 10 * 0.016 = 0.16


        //2. 플레이어 트렌스폼 포지션 x,y 값을 고정시킨다.
       // Vector3 pos = transform.position;
        //if (transform.position.x > 4.5)
        //    pos.x = 4.5f;  
        //if (transform.position.x < -4.5)
        //    pos.x = -4.5f;
        //if (transform.position.z > 4.5)
        //    pos.z = 4.5f;
        //if (transform.position.z < -4.5)
        //    pos.z = -4.5f;
        //위 방법으로도 가능하나
        //아래 친구가 더 성능이 좋다.
       // pos.x = Mathf.Clamp(pos.x, -4.5f, 4.5f);     
        //pos.z = Mathf.Clamp(pos.z, -4.5f, 4.5f);

        //transform.position = pos;

         MoveInScreen();
    }

    void MoveInScreen()
    {
        //3. 메인 카메라의 뷰포트를 가져와서 처리한다.
        //뷰포트 좌표 - 카메라의 사작뿔 끝에있는 사각형 왼쪽하단(0,0),우측상단(1,1)
        //스크린 좌표 - 모니터 해상도 픽셀 단위
        //UV좌표 - 화면 텍스트, 2D 이미지를 표시하기 위한 좌표계로 텍스쳐 좌표계라고도 한다
        //좌상단(0, 0), 우측하단(1, 1)
        
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        pos.x = Mathf.Clamp(pos.x, 0.0f + margin.x, 1.0f - margin.x);
        pos.y = Mathf.Clamp(pos.y, 0.0f + margin.y, 1.0f - margin.y);

        transform.position = Camera.main.ViewportToWorldPoint(pos);

        /*
         메인 카메라의 중요 함수
         메인 카메라또한 자주 사용하기 때문에 어디에서든  접근할 수 있도록
         Camera.main으로 사용이 가능하다.
         */
    }
}
