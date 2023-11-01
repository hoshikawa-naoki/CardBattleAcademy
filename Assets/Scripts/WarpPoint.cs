using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WarpPoint : MonoBehaviour
{
    public Vector3 pos;
    public CinemachineVirtualCamera virtualCamera;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Cinemachine�J�������ꎞ�I�ɖ����ɂ���
            virtualCamera.enabled = false;

            // �v���C���[�̈ʒu��ύX
            other.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);

            // �J�����̈ʒu���ύX
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                mainCamera.transform.position = new Vector3(pos.x, pos.y, mainCamera.transform.position.z);
            }

            // �ړ�������������Cinemachine�J�������ēx�L���ɂ���
            virtualCamera.enabled = true;
        }
    }
}
