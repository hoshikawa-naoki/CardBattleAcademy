using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class move_chara: MonoBehaviour
{
    private float speed = 0.011f; //floatは小数点
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();//※使うときは＜＞を半角にしてください
    }


    void Update()
    {
        Vector2 pos = transform.position;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += speed;//右に移動
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= speed;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            pos.y += speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            pos.y -= speed;
        }

        transform.position = pos;
    }
}