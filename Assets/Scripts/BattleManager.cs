using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    //�I�����E�B���h�E
    public GameObject choiceWindow1;
    public GameObject choiceWindow2;
    public GameObject choiceWindow3;
    public GameObject choiceWindow4;

    //�I�����e�L�X�g
    public GameObject choiceText1;
    public GameObject choiceText2;
    public GameObject choiceText3;
    public GameObject choiceText4;

    //���b�Z�[�W�E�B���h�E
    public GameObject messageWindow;
    public GameObject messageText;

    //�T�E���h
    public GameObject BGM;
    public GameObject AttackSound;


    //�v���C���[���
    int playerLv;
    int playerHp;
    int playerSp;
    int playerAtk;
    int playerDef;
    int playerSpeed;

    //�����X�^�[���
    int monsterHp;
    int monsterSp;
    int monsterAtk;
    int monsterDef;
    int monsterSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartBattle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartBattle()
    {
        //2�b�҂�
        yield return new WaitForSeconds(2);

        //���b�Z�[�W�E�B���h�E������
        messageText.SetActive(false);
        messageWindow.SetActive(false);

        //�I�����Ɩ����o��
        choiceText1.SetActive(true);
        choiceText2.SetActive(true);
        choiceText3.SetActive(true);
        choiceText4.SetActive(true);
        choiceWindow1.SetActive(true);
        choiceWindow2.SetActive(true);
        choiceWindow3.SetActive(true);
        choiceWindow4.SetActive(true);

    }
}
