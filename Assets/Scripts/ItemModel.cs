using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemModel : MonoBehaviour
{
    BattleManager bm;
    Item[] items = new Item[7];
    // Start is called before the first frame update
    void Start()
    {
        bm = GetComponent<BattleManager>();
    }

    public void Set()
    {
        for (int i = 1; i < items.Length; i++)
        {
            items[i] = new Item();
        }
        items[1].name = "A";
        items[1].message = "HP��30�񕜂����I";
        items[2].name = "B";
        items[2].message = "HP��90�񕜂����I";
        items[3].name = "�A���i�C��";
        items[3].message = "HP��200�񕜂����I";
        items[4].name = "�v���e�C��";
        items[4].message = "�U���͂�1.5�{�ɂȂ����I";
        items[5].name = "E";
        items[5].message = "�h��͂�1.5�{�ɂȂ����I";
        items[6].name = "F";
        items[6].message = "��Ԉُ킪���ׂĉ񕜂����I";

    }

        public void ItemUse(int skillAct)
    {
        switch (skillAct)
        {
            case 0:

                break;

            case 1:

                break;

            case 2:

                break;

            case 3:

                break;

            case 4:

                break;
            case 5:

                break;
        }
    }
}
public class Item
{
    public string name;
    public string message;
}