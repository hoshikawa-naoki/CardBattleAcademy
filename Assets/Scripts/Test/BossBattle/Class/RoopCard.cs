using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoopCard : Card
{
    private int childIndex; //���[�v�Ώۂ̏���

    //�R���X�g���N�^(: base()�Őe�̃R���X�g���N�^���Ăяo��)
    public RoopCard(GameObject card, int value, string type, int childIndex) : base(card, value, type)
    {
        SetChildIndex(childIndex);
    }

    private void SetChildIndex(int childIndex)
    {
        this.childIndex = childIndex;
    }

    public int GetChildIndex()
    {
        return childIndex;
    }
}