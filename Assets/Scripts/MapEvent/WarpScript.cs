using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WarpScript : MonoBehaviour
{
    public Vector3 warpDestination;
    public CinemachineVirtualCamera virtualCamera;

    private bool hasPlayerTouched = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !hasPlayerTouched)
        {
            hasPlayerTouched = true;

            // CinemachineVirtualCamera���ꎞ�I�ɖ����ɂ���
            virtualCamera.enabled = false;

            // �v���C���[�̈ʒu��ύX
            other.gameObject.transform.position = warpDestination;

            // �J�����̈ʒu���ύX
            if (virtualCamera != null)
            {
                virtualCamera.transform.position = new Vector3(warpDestination.x, warpDestination.y, virtualCamera.transform.position.z);
            }

            // �J�����ƃv���C���[�̈ړ�������������A���b�҂��Ă���CinemachineVirtualCamera���ēx�L���ɂ���
            StartCoroutine(EnableCameraAfterDelay(0.01f));
        }
    }

    private IEnumerator EnableCameraAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // CinemachineVirtualCamera���ēx�L���ɂ���
        virtualCamera.enabled = true;
    }
}
