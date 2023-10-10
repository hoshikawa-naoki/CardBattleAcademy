using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCarryer : MonoBehaviour
{
    Vector3 cardPos, mousePos;
    GameObject framePrefab, nowFrame, nextFrame;
    public static List<GameObject> frameList;
    bool isEnterAlgo, isOnFrame, isInFrameList;

    // Start is called before the first frame update
    void Start()
    {
        //��������v���n�u
        framePrefab = Resources.Load<GameObject>("Frame");

        //���Ɏg�p����Ă���t���[���̃��X�g
        frameList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        //�t���[���ɏd�Ȃ�����g�p�ҋ@��Ԃɂ���
        if (collision.gameObject.tag == "Frame" && !isEnterAlgo)
        {
            nowFrame = collision.gameObject;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        //�t���[���ɏd�Ȃ��Ă��邱�Ƃ����m����
        if (collision.gameObject == nowFrame && isEnterAlgo)
        {
            isOnFrame = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        //�ҋ@��Ԃ̃t���[���̏ォ�A���S���Y���ɑg�ݍ��܂�Ă���ꍇ�A��������
        if (collision.gameObject == nowFrame && isEnterAlgo)
        {
            if (transform.tag == "Roop")
            {
                nowFrame.transform.Translate(0.0f, -1.0f, 0.0f);
            }

            Destroy(nextFrame);
            frameList.Remove(nowFrame);

            nowFrame = null;
            isEnterAlgo = false;
            isOnFrame = false;
        }
    }


    public void OnMouseDown()
    {
        //��ʂ̍��W��unity��Ԃ̍��W��A��������
        Debug.Log("�J�[�h������");

        cardPos = Camera.main.WorldToScreenPoint(transform.position);
        cardPos = Camera.main.ScreenToWorldPoint(cardPos);
    }

    public void OnMouseDrag()
    {
        //�}�E�X�̓����ɃJ�[�h��Ǐ]������
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = mousePos;
    }

    public void OnMouseUp()
    {

        //�d�����m�g�[�N���̏�����
        isInFrameList = false;

        //�����t���[���ɒu�����Ƃ���Ɣz�u���~�߂�
        if (frameList != null && !isOnFrame)
        {
            foreach (GameObject f in frameList)
            {
                if (f == nowFrame)
                {
                    Debug.Log("����frame�ւ̔z�u");
                    isInFrameList = true;
                    break;
                }
            }
        }

        //���̃t���[�����쐬���A���̃t���[���̈ʒu�𒲐�����
        if (!isInFrameList)
        {
            if (nowFrame != null && !isEnterAlgo)
            {
                isEnterAlgo = true;

                Vector3 nextPos = nowFrame.transform.position;

                if (tag == "Roop")
                {
                    nowFrame.transform.Translate(0.0f, 1.0f, 0.0f);
                    nextPos.y -= 1.0f;
                }
                else
                {
                    nextPos.x += 1.5f;
                }

                nextFrame = Instantiate(framePrefab, nextPos, Quaternion.identity);
                nextFrame.transform.SetParent(nowFrame.transform.parent);

                transform.position = nowFrame.transform.position;
                transform.Translate(0.0f, 0.0f, -1.0f);

                frameList.Add(nowFrame);

            }
            else if (isOnFrame)
            {
                transform.position = nowFrame.transform.position;
                transform.Translate(0.0f, 0.0f, -1.0f);
            }
        }
    }

}
