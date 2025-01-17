using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillModel : MonoBehaviour
{
    BattleManager bm;
    Skill[] skills = new Skill[7];

    // Start is called before the first frame update
    void Start()
    {
        bm = GetComponent<BattleManager>();   
    }
    
    public void SkillUse(int skillAct)
    {
        switch (skillAct)
        {
            case 1:
                bm.timeRate = 0.5f;
                break;

            case 2:
                bm.playerDefRate = 3;
                break;

            case 3:
                bm.playerAtkRate = 1.5f;
                break; 

            case 4:
                bm.addDamage = 10;
                break;

            case 5:

                break;
            case 6:

                break;
        }
    }

    public void Set()
    {
        for (int i = 1; i < skills.Length; i++)
        {
            skills[i] = new Skill();
        }
        skills[1].id = 1;
        skills[1].name = "超集中";
        skills[1].cost = 2;
        skills[1].message = "問題の思考が早くなる！";
        skills[1].expo = "制限時間を2倍にする";
        skills[2].id = 2;
        skills[2].name = "三戦";
        skills[2].cost = 4;
        skills[2].message = "空手道に古くから伝わる守りの型！";
        skills[2].expo = "防御力を1ターン3倍にする";
        skills[3].id = 3;
        skills[3].name = "分析";
        skills[3].cost = 4;
        skills[3].message = "敵の急所を見分けた！";
        skills[3].expo = "次の攻撃力が1.5倍にする";
        skills[4].id = 4;
        skills[4].name = "追尾弾";
        skills[4].cost = 6;
        skills[4].message = "敵に10の追加固定ダメージ！";
        skills[4].expo = "次の攻撃の後追加で10の固定ダメージ";


    }

    public Skill SkillSet(int skillID)
    {
        return skills[skillID];
    }

}

public class Skill
{
    public int id;
    public string name;
    public int cost;
    public string message;
    public string expo;
}
