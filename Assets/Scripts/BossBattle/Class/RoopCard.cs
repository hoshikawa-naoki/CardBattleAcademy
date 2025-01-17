using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoopCard : Card
{
    private int childIndex; //ループ対象の処理

    //コンストラクタ(: base()で親のコンストラクタを呼び出す)
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