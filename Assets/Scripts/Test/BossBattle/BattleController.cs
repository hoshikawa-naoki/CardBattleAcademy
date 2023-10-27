using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public Slider HeroHP;
    public Slider BossHP;

    public TextMeshProUGUI maxHP;
    public TextMeshProUGUI nowHP;

    int maxHPValue, nowHPValue;

    // Start is called before the first frame update
    void Start()
    {
        //HP�̍ő�l�ݒ�
        HeroHP.maxValue = 100;
        BossHP.maxValue = 100;

        //����HP���ő�l�ɍ��킹��
        HeroHP.value = HeroHP.maxValue;
        BossHP.value = BossHP.maxValue;

        //���������킹��
        maxHPValue = (int)HeroHP.maxValue;
        maxHP.text = maxHPValue.ToString();
        ChangeNowHP();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Attack();
    }

    private void Attack()
    {
        Debug.Log("��킵��");
        BossHP.value -= 50;
        HeroHP.value -= 20;

        ChangeNowHP();
    }

    private void ChangeNowHP()
    {
        //����HP(����)�̍X�V
        nowHPValue = (int)HeroHP.value;
        nowHP.text = nowHPValue.ToString();
    }
}
