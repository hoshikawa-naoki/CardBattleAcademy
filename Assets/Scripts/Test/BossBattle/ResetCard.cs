using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetCard : MonoBehaviour
{
    public GameObject cardsParent;
    LayoutGroup layoutGroup;

    // Start is called before the first frame update
    void Start()
    {
        layoutGroup = cardsParent.GetComponent<LayoutGroup>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClick()
    {
        //���C�A�E�g�O���[�v�̍čX�V���s��
        layoutGroup.CalculateLayoutInputHorizontal();
        layoutGroup.CalculateLayoutInputVertical();
        layoutGroup.SetLayoutHorizontal();
        layoutGroup.SetLayoutVertical();
    }
}
