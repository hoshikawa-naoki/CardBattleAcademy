using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class move_chara: MonoBehaviour
{
    private float speed = 0.1f; //float�͏����_

    void Update()
    {
        Vector2 pos = transform.position;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += speed;//�E�Ɉړ�
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