using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[�̍��W���擾����
        Vector3 vector = player.transform.position;

        //Z���ȊO�������W�ɂ���
        this.transform.position = new Vector3(vector.x, vector.y, -1);
    }
}
