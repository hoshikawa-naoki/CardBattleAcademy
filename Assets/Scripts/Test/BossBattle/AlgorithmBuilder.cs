using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgorithmBuilder : MonoBehaviour
{
    List<GameObject> algoList = new();

    public void AddToAlgo(GameObject g)
    {
        int index = algoList.Count;

        //���X�g����Ȃ�ǉ��A�����łȂ���Δz�u�ʒu�Ɋ�Â��đ}��
        if (index == 0)
        {
            algoList.Add(g);
        } else
        {

        }
    }

    public void RemoveFromAlgo(GameObject g)
    {
        algoList.Remove(g);
    }
}
