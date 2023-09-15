using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour
{
    public GameObject player;   //�v���C���[�I�u�W�F�N�g���擾
    public GameObject warpPoint;    //�ΏƂɂȂ郏�[�v�|�C���g�̎擾
    private Vector3 wp; //���[�v����W�̎擾

    public static bool isAfterWarp = false; //���[�v���ォ���m(�A�����[�v�̖h�~)
    public static bool isStay = false;

    // Start is called before the first frame update
    void Start()
    {
        //���[�v����W��ΏƂƂȂ郏�[�v�|�C���g����擾����
        wp = warpPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�v���C���[���ڐG�����
        if (collision.gameObject == player)
        {
            //���[�v��łȂ��A��ɏ�葱���Ă��Ȃ��ꍇ
            if (!isAfterWarp && !isStay)
            {
                //���[�v����
                player.transform.position = wp;

                isAfterWarp = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //���[�v����Ȃ�
        if(isAfterWarp)
        {
            //�v���C���[����葱������Ȃ�
            if(collision.gameObject == player && isStay)
            {
                isAfterWarp = false;
                isStay = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            isStay = true;
        }
    }
}