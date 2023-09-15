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

    //�s���E�B���h�E
    public GameObject actWindow;
    public GameObject actSelect;
    int act = 1;

    //�s���e�L�X�g
    public GameObject fightText;
    public GameObject skillText;
    public GameObject itemText;
    public GameObject escapeText;

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
    bool isActTurn;

    //�^�C�}�[
    float remainTime = 15;
    float timer;

    //�I�񂾑I����
    GameObject playerChoice;


    void Start()
    {
        StartCoroutine("StartBattle");
    }

    //�o�g�������ݒ�
    IEnumerator StartBattle()
    {
        //2�b�҂�
        yield return new WaitForSeconds(2);
        //HP�ݒ�
        playerHpBar.GetComponent<Slider>().maxValue = playerHp;
        playerHpBar.GetComponent<Slider>().value = playerHp;
        monsterHpBar.GetComponent<Slider>().maxValue = monsterHp;
        monsterHpBar.GetComponent<Slider>().value = monsterHp;
        
        //�s���^�[���ɂ���
        isActTurn = true;
        isQuestionTurn = false;
        //�^�[���ύX
        ChangeTurn();
    }

    //���^�[������
    void Update()
    {
        //�s���^�[����
        if (isActTurn)
        {
            if (Input.GetKeyDown(KeyCode.W) && act != 1)
            {
                //���𓮂���
                act--;
                actSelect.transform.Translate(-0.5f,0,0);
            }
            if (Input.GetKeyDown(KeyCode.S) && act != 4)
            {
                //���𓮂���
                act++;
                actSelect.transform.Translate(0.5f,0,0);
            }
            if(Input.GetKeyDown(KeyCode.Return) && act == 1)
            {
                isActTurn = false;
                isQuestionTurn = true;
                SetQuestion();
                ChangeTurn();
            }
        }

        //���^�[����
        if (isQuestionTurn)
        {
            
            //�������ԓ���
            if (remainTime >= 0)
            {
                //�J�E���g�_�E��
                remainTime -= Time.deltaTime;
                //�������ʂ܂�
                timeText.GetComponent<Text>().text = remainTime.ToString("f1");
                //�������ԃo�[���f
                timeBar.GetComponent<Slider>().value = remainTime;
            }
            else
            //���Ԃ�0�ɂȂ�����
            {
                messageText.GetComponent<Text>().text = "���Ԑ؂�...";
                isQuestionTurn = false;
                ChangeTurn();
                //�G�̃^�[��
                StartCoroutine("MonsterTurn");
            }
            //���N���b�N������
            if (Input.GetMouseButtonDown(0))
            {
                //�N���b�N�����ʒu���擾
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //�N���b�N�����ʒu�ɂ���I�u�W�F�N�g���擾
                RaycastHit2D hit2D = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

                //�I�u�W�F�N�g���擾���Ă�����
                if (hit2D)
                {
                    isQuestionTurn = false;
                    ChangeTurn();
                    playerChoice = hit2D.transform.gameObject;

                    //�������s������
                    if(playerChoice.tag == "true")
                    {
                        //�_���[�W�v�Z
                        int damage = playerAtk - monsterDef;
                        //�e�L�X�g�\��
                        messageText.GetComponent<Text>().text = "����!" + monsterName + "��" + damage + "�̃_���[�W��^����";
                        //HP���f
                        monsterHp -= damage;
                        //HP�o�[���f
                        monsterHpBar.GetComponent<Slider>().value = monsterHp;
                    }
                    else
                    {
                        //�e�L�X�g�\��
                        messageText.GetComponent<Text>().text = "�s����...";
                    }
                    //�퓬�I������
                    if (monsterHp <= 0)
                    {
                        isActTurn = false;
                        isQuestionTurn = false;
                        EndBattle();
                    }
                    else
                    {
                        //�G�̃^�[��
                        StartCoroutine("MonsterTurn");
                    }
                }
            }
        }
    }

    //�G�̃^�[��
    IEnumerator MonsterTurn()
    {
        //2�b�҂�
        yield return new WaitForSeconds(2);
        //�_���[�W�v�Z
        int damage = monsterAtk - playerDef;
        //���b�Z�[�W�o��
        messageText.GetComponent<Text>().text = "�X���C���̍U��!" + damage + "�̃_���[�W���󂯂�";
        //HP���f
        playerHp -= damage;
        //�_���[�W�o�[�ύX
        playerHpBar.GetComponent<Slider>().value = playerHp;
        //2�b�҂�
        yield return new WaitForSeconds(2);
        //�퓬�I������
        if (playerHp <= 0)
        {
            isActTurn = false;
            isQuestionTurn = false;
            EndBattle();
        }
        else
        {
            //�s���^�[���ɂ���
            isActTurn = true;
            //�^�[���ύX
            ChangeTurn();
        }
    }

    IEnumerator EndBattle()
    {
        if(playerHp == 0)
        {
            messageText.GetComponent<Text>().text = "�G��|�����I";
        }
        else
        {
            messageText.GetComponent<Text>().text = "�S�ł���...";
        }
        //2�b�҂�
        yield return new WaitForSeconds(2);
    }

    //���Z�b�g
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

        //�������ԃ��Z�b�g
        remainTime = 15;
    }

    //���^�[���Ƃ��̑��^�[���̕ύX
    void ChangeTurn()
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

        //�s���^�[����
        if (isActTurn)
        {
            actSelect.SetActive(true);
            actWindow.SetActive(true);
            fightText.SetActive(true);
            skillText.SetActive(true);
            itemText.SetActive(true);
            escapeText.SetActive(true);

            //���b�Z�[�W�E�B���h�E������
            messageText.SetActive(false);
            messageWindow.SetActive(false);
        }
        else
        {
            actSelect.SetActive(false);
            actWindow.SetActive(false);
            fightText.SetActive(false);
            skillText.SetActive(false);
            itemText.SetActive(false);
            escapeText.SetActive(false);
        }
    }
}
