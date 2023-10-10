using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    //�X�N���v�g
    PlayerModel pm;
    SkillModel sm;
    ItemModel im;
    MonsterModel mm;
    Player p;
    MonsterDB m;
   
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
    int skillAct = 1;

    //�X�L���E�B���h�E
    public GameObject skillWindow;

    //�X�L���e�L�X�g
    public GameObject skillText1;
    public GameObject skillText2;
    public GameObject skillText3;
    public GameObject skillText4;
    public GameObject skillText5;
    public GameObject skillText6;

    //�T�E���h
    public GameObject BGM;
    public GameObject AttackSound;

    //HP�ASP�o�[
    public GameObject playerHpBar;
    public GameObject playerSpBar;
    public GameObject monsterHpBar;
    public GameObject nowHp;
    public GameObject nowSp;
    public GameObject maxHp;
    public GameObject maxSp;

    //��������
    public GameObject timeBar;
    public GameObject timeText;

    //�v���C���[���
    public GameObject playerText;
    string playerName = "��������";
    int playerLv = 1;
    int playerHp = 12;
    int playerMaxHp = 15;
    int playerMaxSp = 10;
    int playerSp = 10;
    float playerAtk = 5;
    float playerDef = 2;

    //�����X�^�[���
    public static int monsterID;
    public GameObject monsterText;
    int monsterMaxHp;

    //�^�[������
    bool isQuestionTurn;
    bool isActTurn;
    bool isSkillTurn;

    //�^�C�}�[
    float remainTime;
    float timer;

    //�I�񂾑I����
    GameObject playerChoice;

    //�{��
    public int costSp;
    public float timeRate;
    public float playerAtkRate;
    public float playerDefRate;

    int battleSpeed = 1;

    void Start()
    {
        sm = GetComponent<SkillModel>(); //�X�L�����
        im = GetComponent<ItemModel>(); //�A�C�e�����
        mm = GetComponent<MonsterModel>(); //�����X�^�[���
        pm = GetComponent<PlayerModel>();//�v���C���[���
        StartCoroutine("StartBattle");
    }

    //�o�g�������ݒ�
    IEnumerator StartBattle()
    {
        //�v���C���[���
        p = pm.PlayerSet();
        playerName = p.name;
        playerLv = p.lv;
        playerMaxHp = p.maxHp;
        playerHp = p.nowHp;
        playerMaxSp = p.maxSp;
        playerSp = p.nowSp;
        playerAtk = p.atk;
        playerDef = p.def;

        //�����X�^�[���
        m = mm.MonsterDB(2);

        monsterText.GetComponent<Text>().text = m.name;
        messageText.GetComponent<Text>().text = m.name + "�������ꂽ�I";

        //HP�ݒ�
        playerHpBar.GetComponent<Slider>().maxValue = p.maxHp;
        playerHpBar.GetComponent<Slider>().value = p.nowHp;
        playerSpBar.GetComponent<Slider>().maxValue = p.maxSp;
        playerSpBar.GetComponent<Slider>().value = p.nowSp;
        monsterHpBar.GetComponent<Slider>().maxValue = m.hp;
        monsterHpBar.GetComponent<Slider>().value = m.hp;
        maxHp.GetComponent<Text>().text = p.maxHp.ToString();
        nowHp.GetComponent<Text>().text = p.nowHp.ToString();
        maxSp.GetComponent<Text>().text = p.maxSp.ToString();
        nowSp.GetComponent<Text>().text = p.nowSp.ToString();

        playerAtkRate = 1;
        playerDefRate = 1;
        timeRate = 1;
        remainTime = 15;

        //2�b�҂�
        yield return new WaitForSeconds(battleSpeed);
        
        //�s���^�[���ɂ���
        isActTurn = true;
        isQuestionTurn = false;
        ActActive();
    }


    void Update()
    {
        //�s���^�[����
        if (isActTurn)
        {
            if (Input.GetKeyDown(KeyCode.W) && act != 1)
            {
                //���ɖ��𓮂���
                act--;
                actSelect.transform.Translate(-0.65f,0,0);
            }
            if (Input.GetKeyDown(KeyCode.S) && act != 4)
            {
                //��ɖ��𓮂���
                act++;
                actSelect.transform.Translate(0.65f,0,0);
            }
            if(Input.GetKeyDown(KeyCode.Return))
            {
                //��������
                if(act == 1)
                {
                    isActTurn = false;
                    isQuestionTurn = true;
                    SetQuestion();
                    QuestionActive();
                }
                //�X�L��
                else if(act == 2 || act == 3)
                {
                    isSkillTurn = true;
                    isActTurn = false;
                    SkillActive();   
                }
                //������
                else if(act == 4)
                {
                    isActTurn = false;
                    MessageActive();
                    StartCoroutine("EndBattle");
                }
            }
        }

        //�X�L���^�[����
        if (isSkillTurn)
        {
            if (Input.GetKeyDown(KeyCode.W) && skillAct != 1 && skillAct != 4)
            {
                //���𓮂���
                skillAct--;
                actSelect.transform.Translate(-0.8f, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.S) && skillAct != 3 && skillAct != 6)
            {
                //���𓮂���
                skillAct++;
                actSelect.transform.Translate(0.8f, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.A) && skillAct != 1 && skillAct != 2 && skillAct != 3)
            {
                //���𓮂���
                skillAct -= 3;
                actSelect.transform.Translate(0, -5.25f, 0);
            }
            if (Input.GetKeyDown(KeyCode.D) && skillAct != 4 && skillAct != 5 && skillAct != 6)
            {
                //���𓮂���
                skillAct += 3;
                actSelect.transform.Translate(0, 5.25f, 0);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //���𓮂���
                isActTurn = true;
                isSkillTurn = false;
                ActActive();
            }
            if (Input.GetKeyDown(KeyCode.F) && act == 2)
            {
               StartCoroutine("SkillUse");
            }
            if (Input.GetKeyDown(KeyCode.F) && act == 3)
            {
                StartCoroutine("PlayerTurn");
            }
        }

        //���^�[����
        if (isQuestionTurn)
        {
            
            //�������ԓ���
            if (remainTime >= 0)
            {
                //�J�E���g�_�E��
                remainTime -= Time.deltaTime * timeRate;
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
                MessageActive();
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
                    MessageActive();
                    playerChoice = hit2D.transform.gameObject;

                    //�������s������
                    if(playerChoice.tag == "true")
                    {
                        //�e�L�X�g�\��
                        messageText.GetComponent<Text>().text = "�����I" + p.name + "�̍U���I";
                        StartCoroutine("PlayerTurn");
                    }
                    else
                    {
                        //�e�L�X�g�\��
                        messageText.GetComponent<Text>().text = "�s����...";
                        //�G�̃^�[��
                        StartCoroutine("MonsterTurn");
                    }
                }
            }
        }
    }

    IEnumerator SkillUse()
    {
        //�X�L��
        isSkillTurn = false;
        sm.SkillUse(skillAct, playerSp);
        MessageActive();

        if(0 > p.nowSp - costSp)
        {
            messageText.GetComponent<Text>().text = "SP������Ȃ��I";
            yield return new WaitForSeconds(battleSpeed);
            isActTurn = true;
            ActActive();
        }
        else
        {
            yield return new WaitForSeconds(battleSpeed);
            //SP�o�[���f
            playerSp -= costSp;
            playerSpBar.GetComponent<Slider>().value = p.nowSp;
            nowSp.GetComponent<Text>().text = p.nowSp.ToString();
            isQuestionTurn = true;
            SetQuestion();
            QuestionActive();
        }
    }

    IEnumerator PlayerTurn()
    {
        if(act == 1 || act == 2)
        {
            //2�b�҂�
            yield return new WaitForSeconds(battleSpeed);
            //�_���[�W�v�Z
            int damage = (int)Mathf.Floor(p.atk * playerAtkRate - m.def);

            //HP���f
            if (damage >= 1)
            {
                m.hp -= damage;
                messageText.GetComponent<Text>().text = m.name + "��" + damage + "�̃_���[�W��^����";
                //HP�o�[���f
                monsterHpBar.GetComponent<Slider>().value = m.hp;
            }
            else
            {
                messageText.GetComponent<Text>().text = "�~�X�I�_���[�W��^�����Ȃ������I";
            }

            //�퓬�I������
            if (m.hp <= 0)
            {
                //�v���C���[�̏���
                StartCoroutine("EndBattle");
            }
            else
            {
                //�G�̃^�[��
                StartCoroutine("MonsterTurn");
            }
        }
        else if(act == 3)
        {
            isSkillTurn = false;
            im.ItemUse(skillAct);
            MessageActive();
            //�G�̃^�[��
            StartCoroutine("MonsterTurn");
        }
    }

    //�G�̃^�[��
    IEnumerator MonsterTurn()
    {
        //2�b�҂�
        yield return new WaitForSeconds(battleSpeed);
        messageText.GetComponent<Text>().text = m.name + "�̍U���I";
        //2�b�҂�
        yield return new WaitForSeconds(battleSpeed);
        //�_���[�W�v�Z
        int damage = (int)Mathf.Floor(m.atk - p.def * playerDefRate);
        if(damage >= 1)
        {
            //HP���f
            p.nowHp -= damage;
            messageText.GetComponent<Text>().text = damage + "�̃_���[�W���󂯂�";
            //HP�o�[���f
            if (p.nowHp <= 0)
            {
                playerHpBar.GetComponent<Slider>().value = 0;
                nowHp.GetComponent<Text>().text = "0";

            }
            else
            {
                playerHpBar.GetComponent<Slider>().value = p.nowHp;
                nowHp.GetComponent<Text>().text = p.nowHp.ToString();
            }
        }
        else
        {
            messageText.GetComponent<Text>().text = "�~�X�I�_���[�W���󂯂Ȃ������I";
        }
        //�_���[�W�o�[�ύX
        playerHpBar.GetComponent<Slider>().value = p.nowHp;
        //2�b�҂�
        yield return new WaitForSeconds(battleSpeed);
        //�퓬�I������
        if (p.nowHp <= 0)
        {
            //�v���C���[�̕���
            StartCoroutine("EndBattle");
        }
        else
        {
            RateReset();
            //�s���^�[���ɂ���
            isActTurn = true;
            //�^�[���ύX
            ActActive();
        }
    }

    //�퓬�I��
    IEnumerator EndBattle()
    {
        //2�b�҂�
        isQuestionTurn = false;
        yield return new WaitForSeconds(battleSpeed);
        if (m.hp <= 0)
        {
            messageText.GetComponent<Text>().text = "�G��|�����I";
        }
        else if(p.nowHp <= 0)
        {
            messageText.GetComponent<Text>().text = "�S�ł���...";
        }
        else
        {
            messageText.GetComponent<Text>().text = "�����o�����I";
        }
        //2�b�҂�
        yield return new WaitForSeconds(battleSpeed);
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
    }

    //�{�����Z�b�g
    void RateReset()
    {
        playerAtkRate = 1;
        playerDefRate = 1;
        timeRate = 1;

    }

    //���o��
    void QuestionActive()
    {
        //���o��
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
        remainTime = 15;

        //���b�Z�[�W�E�B���h�E������
        messageText.SetActive(false);
        messageWindow.SetActive(false);

        //�s������
        actSelect.SetActive(false);
        actWindow.SetActive(false);
        fightText.SetActive(false);
        skillText.SetActive(false);
        itemText.SetActive(false);
        escapeText.SetActive(false);
    }

    //�s���o��
    void ActActive()
    {
        //�s���o��
        actSelect.SetActive(true);
        actWindow.SetActive(true);
        fightText.SetActive(true);
        skillText.SetActive(true);
        itemText.SetActive(true);
        escapeText.SetActive(true);
        actSelect.transform.position = new Vector3(-5.7f, -1.6f, 0);
        skillAct = 1;
        act = 1; 

        //�X�L������
        skillWindow.SetActive(false);
        skillText1.SetActive(false);
        skillText2.SetActive(false);
        skillText3.SetActive(false);
        skillText4.SetActive(false);
        skillText5.SetActive(false);
        skillText6.SetActive(false);

        //���b�Z�[�W�E�B���h�E������
        messageText.SetActive(false);
        messageWindow.SetActive(false);
    }

    //�X�L���o��
    void SkillActive()
    {
        //�X�L���o��
        skillWindow.SetActive(true);
        skillText1.SetActive(true);
        skillText2.SetActive(true);
        skillText3.SetActive(true);
        skillText4.SetActive(true);
        skillText5.SetActive(true);
        skillText6.SetActive(true);
        actSelect.transform.position = new Vector3(-5, -1.9f, 0);

        //�s������
        actWindow.SetActive(false);
        fightText.SetActive(false);
        skillText.SetActive(false);
        itemText.SetActive(false);
        escapeText.SetActive(false);
    }

    //���b�Z�[�W�E�B���h�E���o��
    void MessageActive()
    {
        //���b�Z�[�W�E�B���h�E���o��
        messageText.SetActive(true);
        messageWindow.SetActive(true);

        //�X�L������
        skillWindow.SetActive(false);
        skillText1.SetActive(false);
        skillText2.SetActive(false);
        skillText3.SetActive(false);
        skillText4.SetActive(false);
        skillText5.SetActive(false);
        skillText6.SetActive(false);
        actSelect.SetActive(false);

        //�s������
        actSelect.SetActive(false);
        actWindow.SetActive(false);
        fightText.SetActive(false);
        skillText.SetActive(false);
        itemText.SetActive(false);
        escapeText.SetActive(false);

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
    }
}
