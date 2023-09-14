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

    //���E�B���h�E
    public GameObject questionWindow;
    public GameObject questionText;

    //�T�E���h
    public GameObject BGM;
    public GameObject AttackSound;

    //HP�ASP�o�[
    public GameObject playerHpBar;
    public GameObject playerSpBar;
    public GameObject monsterHpBar;

    //��������
    public GameObject timeBar;
    public GameObject timeText;

    //�v���C���[���
    string playerName;
    int playerLv;
    int playerHp = 12;
    int playerSp;
    int playerAtk = 5;
    int playerDef = 2;
    int playerSpeed;

    //�����X�^�[���
    string monsterName = "�X���C��";
    int monsterHp = 5;
    int monsterSp;
    int monsterAtk = 4;
    int monsterDef = 2;
    int monsterSpeed;

    //���^�[����
    bool isQuestionTurn;

    //�^�C�}�[
    float leftTime = 15;
    float timer;

    GameObject clickedGameObject;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartBattle");
    }

    // Update is called once per frame
    void Update()
    {
        //���^�[����
        if (isQuestionTurn)
        {
            
            //�������ԓ���
            if (leftTime >= 0)
            {
                //�J�E���g�_�E��
                leftTime -= Time.deltaTime;
                timeText.GetComponent<Text>().text = leftTime.ToString("f1");
                timeBar.GetComponent<Slider>().value = leftTime;
            }
            if (Input.GetMouseButtonDown(0))
            {
                //�I�������N���b�N
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit2D = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

                if (hit2D)
                {
                    isQuestionTurn = false;
                    ChangePhase();
                    clickedGameObject = hit2D.transform.gameObject;
                    //�������s������
                    if(clickedGameObject.tag == "true")
                    {
                        Debug.Log("����");
                        //�_���[�W�v�Z
                        int damage = playerAtk - monsterDef;
                        messageText.GetComponent<Text>().text = "����!" + monsterName + "��" + damage + "�̃_���[�W��^����";
                        monsterHpBar.GetComponent<Slider>().value = monsterHp - damage;
                    }
                    else
                    {
                        Debug.Log("�s����");
                        messageText.GetComponent<Text>().text = "�s����!";
                    }
                    StartCoroutine("Interval");
                    MonsterTurn();
                }
            }
        }
    }

    void MonsterTurn()
    {
        int damage = monsterAtk - playerDef;
        messageText.GetComponent<Text>().text = "�X���C���̍U��!" + damage + "�̃_���[�W���󂯂�";
        playerHpBar.GetComponent<Slider>().value = playerHp - damage;
        StartCoroutine("Interval");
        SetQuestion();
        ChangePhase();
    }

    void SetQuestion()
    {
        //��蕶�ƑI����
        questionText.GetComponent<Text>().text = "�l�̕s���ӂɕt������ŋ@�����Ȃǂ�s���ɓ��肷���@�́H";
        choiceText1.GetComponent<Text>().text = "SQL�C���W�F�N�V����";
        choiceText2.GetComponent<Text>().text = "�\�[�V�����G���W�j�A�����O";
        choiceText3.GetComponent<Text>().text = "DDOS�U��";
        choiceText4.GetComponent<Text>().text = "�o�b�t�@�I�[�o�[�t���[";

        //�����Z�b�g
        choiceWindow1.tag = "false";
        choiceWindow2.tag = "true";
        choiceWindow3.tag = "false";
        choiceWindow4.tag = "false";
    }

    IEnumerator Interval()
    {
        //2�b�҂�
        yield return new WaitForSeconds(2);
    }

 

    IEnumerator StartBattle()
    {
        //2�b�҂�
        yield return new WaitForSeconds(2);
        playerHpBar.GetComponent<Slider>().maxValue = playerHp;
        playerHpBar.GetComponent<Slider>().value = playerHp;
        monsterHpBar.GetComponent<Slider>().maxValue = monsterHp;
        monsterHpBar.GetComponent<Slider>().value = monsterHp;
        isQuestionTurn = true;
        SetQuestion();
        ChangePhase();
    }


    void ChangePhase()
    {
        if (isQuestionTurn)
        {
            //�I�����Ɩ����o��
            choiceText1.SetActive(true);
            choiceText2.SetActive(true);
            choiceText3.SetActive(true);
            choiceText4.SetActive(true);
            choiceWindow1.SetActive(true);
            choiceWindow2.SetActive(true);
            choiceWindow3.SetActive(true);
            choiceWindow4.SetActive(true);
            questionText.SetActive(true);
            questionWindow.SetActive(true);
            timeText.SetActive(true);
            timeBar.SetActive(true);

            //���b�Z�[�W�E�B���h�E������
            messageText.SetActive(false);
            messageWindow.SetActive(false);
        }
        else
        {
            //�I�����Ɩ�������
            choiceText1.SetActive(false);
            choiceText2.SetActive(false);
            choiceText3.SetActive(false);
            choiceText4.SetActive(false);
            choiceWindow1.SetActive(false);
            choiceWindow2.SetActive(false);
            choiceWindow3.SetActive(false);
            choiceWindow4.SetActive(false);
            questionText.SetActive(false);
            questionWindow.SetActive(false);
            timeText.SetActive(false);
            timeBar.SetActive(false);

            //���b�Z�[�W�E�B���h�E���o��
            messageText.SetActive(true);
            messageWindow.SetActive(true);
        }
    }
}