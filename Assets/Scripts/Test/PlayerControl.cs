using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float speed = 0.01f;    //�ړ����x�̊�{�{��

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //W�L�[�������Ə�ɐi��
        if (Input.GetKey(KeyCode.W))
        {
            //(x,y,z)�Ŏw��
            this.transform.Translate(0.0f, 1.0f * speed, 0.0f);
        }

        //A�L�[�������ƍ��ɐi��
        if (Input.GetKey(KeyCode.A))
        {
            //(x,y,z)�Ŏw��
            this.transform.Translate(-1.0f * speed, 0.0f, 0.0f);
        }

        //S�L�[�������Ə�ɐi��
        if (Input.GetKey(KeyCode.S))
        {
            //(x,y,z)�Ŏw��
            this.transform.Translate(0.0f, -1.0f * speed, 0.0f);
        }

        //D�L�[�������ƍ��ɐi��
        if (Input.GetKey(KeyCode.D))
        {
            //(x,y,z)�Ŏw��
            this.transform.Translate(1.0f * speed, 0.0f, 0.0f);
        }

        //Esc�L�[�������ƃ��j���[��\������
        if (Input.GetKey(KeyCode.Escape))
        {
        }
    }
}
