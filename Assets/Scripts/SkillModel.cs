using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillModel : MonoBehaviour
{
    BattleManager bm;
    string skillName;
    string skillMessage;
    Skill[] skills = new Skill[99];

    // Start is called before the first frame update
    void Start()
    {

        bm = GetComponent<BattleManager>();   
        for(int i = 1; i < skills.Length; i++)
        {
            skills[i] = new Skill();
        }
        skills[1].name = "���W��";
        skills[1].cost = 2;
        skills[1].message = "���̎v�l�������Ȃ�I";
        skills[2].name = "�O��";
        skills[2].cost = 4;
        skills[2].message = "��蓹�ɌÂ�����`�����̌^�I";
        skills[3].name = "����";
        skills[3].cost = 4;
        skills[3].message = "�G�̋}�������������I";
    }
    
    public void SkillUse(int skillAct, int playerSp)
    {

        switch (skillAct)
        {
            case 1:
                bm.timeRate = 0.5f;
                bm.costSp = 2;
                skillName = "���W��";
                skillMessage = "���̎v�l�������Ȃ�I";
                break;
            case 2:
                bm.playerDefRate = 3;
                bm.costSp = 4;
                skillName = "�O��";
                skillMessage = "��蓹�ɌÂ�����`�����̌^�I";
                break;
            case 3:
                bm.playerAtkRate = 1.5f;
                bm.costSp = 4;
                skillName = "����";
                skillMessage = "�G�̋}�������������I";
                break; 
        }
        bm.messageText.GetComponent<Text>().text = "��l����" + skillName + "!\n" + skillMessage;
    }

    
}

public class Skill
{
    public string name;
    public int cost;
    public string message;
}
