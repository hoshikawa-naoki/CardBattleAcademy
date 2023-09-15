using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControl : MonoBehaviour
{
    float speed = 0.005f;    //�ړ����x�̊�{�{��
    public GameObject ui;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!UIControl.isUINow)
        {
            //W�܂��́��������Ə�ɐi��
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                //(x,y,z)�Ŏw��
                this.transform.Translate(0.0f, 1.0f * speed, 0.0f);
            }

            //A�܂��́��������ƍ��ɐi��
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                //(x,y,z)�Ŏw��
                this.transform.Translate(-1.0f * speed, 0.0f, 0.0f);
            }

            //S�܂��́��������Ɖ��ɐi��
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                //(x,y,z)�Ŏw��
                this.transform.Translate(0.0f, -1.0f * speed, 0.0f);
            }

            //D�܂��́��������ƉE�ɐi��
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                //(x,y,z)�Ŏw��
                this.transform.Translate(1.0f * speed, 0.0f, 0.0f);
            }

            //Shift�������ƃ_�b�V������
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 0.01f;
            }

            //Shift�𗣂��ƌ��̑����ɖ߂�
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = 0.005f;
            }

            //Esc�������ƃ��j���[��\������
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UIControl.isUINow = true;
                ui.SetActive(UIControl.isUINow);
            }
        }
    }
}
