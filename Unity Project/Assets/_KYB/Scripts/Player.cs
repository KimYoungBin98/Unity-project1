using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject RoketRight;
    public GameObject RoketLeft;
    bool roketOn = false;
    public float speed = 10.0f;
    public Vector2 margin;

    float camWidth;
    float camHeight;
    float playerHalfWidth;
    float playerHalfHeight;

    void Start()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Screen.width / Screen.height;

        Vector3 colHalfSize = GetComponent<Collider>().bounds.extents;
        playerHalfWidth = colHalfSize.x;
        playerHalfHeight = colHalfSize.y;
    }


    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        transform.position += dir * speed * Time.deltaTime;

        MakeRoket();

        MoveInScreen();
    }
    void MoveInScreen()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = Vector3.right * h + Vector3.forward * v;
        dir = dir.normalized;

        //Vector3 movePosition = transform.position + dir * speed * Time.deltaTime;
        Vector3 movePosition = transform.position;

        movePosition = new Vector3(Mathf.Clamp(movePosition.x, -camWidth + playerHalfWidth, camWidth - playerHalfWidth),
                         transform.position.y,
                         Mathf.Clamp(movePosition.z, -camHeight + playerHalfHeight, camHeight - playerHalfHeight));
        transform.position = movePosition;
    }

    void MakeRoket()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!roketOn)
            {
                RoketLeft.SetActive(true);
                RoketRight.SetActive(true);
                roketOn = true;
            }
            else
            {
                RoketLeft.SetActive(false);
                RoketRight.SetActive(false);
                roketOn = false;
            }
           
        }
    }
}
