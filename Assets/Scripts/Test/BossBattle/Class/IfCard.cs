using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfCard : Card
{
    private int trueIndex, falseIndex;  //���萬�����̏���, ���莸�s���̏���(�������͏�������)
    private string judgePattern;        //����(��v�E�ȏ�E�ȉ��Ȃ�)

    public IfCard(GameObject card, int value, string cardType, int trueIndex, int falseIndex, string judgePattern) : base(card, value, cardType)
    {
        SetTrueIndex(trueIndex);
        SetFalseIndex(falseIndex);
        SetJudgePattern(judgePattern);
    }

    private void SetTrueIndex(int trueIndex)
    {
        this.trueIndex = trueIndex;
    }

    private void SetFalseIndex(int falseIndex)
    {
        this.falseIndex = falseIndex;
    }

    private void SetJudgePattern(string judgePattern)
    {
        this.judgePattern = judgePattern;
    }
}