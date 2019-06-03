using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//////////////////////////////////////
//挟んだカードをひっくり返す処理
//////////////////////////////////////
public class TurnOver : MonoBehaviour
{
    //script
    Turn turnScript;
    ObjList objList;
    PutTheCard putTheCardScript;
    CardsDate cardsDate;
    SelectPlace playerPosition;
    CollCreate cardsPosition;
    CountTop counttop;

    public bool isListAdd;//追加するとき
    // Start is called before the first frame update
    void Start()
    {
        putTheCardScript = GetComponent<PutTheCard>();
        playerPosition   = GetComponent<SelectPlace>();
        cardsPosition    = GetComponent<CollCreate>();
        cardsDate        = GetComponent<CardsDate>();
        objList          = GetComponent<ObjList>();
        counttop = GetComponent<CountTop>();
    }

    // Update is called once per frame
    void Update()
    {
        turnScript = GetComponent<Turn>();

        //ひっくり返る
        if (putTheCardScript.isTurnOverOk == true)
        {
            for (int i = 0; i < objList.upFrontObj.Count; i++)
            {//リストに入っているオブジェクトだけ処理する

                Debug.Log(objList.upFrontObj[i]);
                objRead(i);
            }
            putTheCardScript.isTurnOverOk = false;
        }
    }

    //読み込んで見やすいようにする
    void objRead(int p)
    {
        if (turnScript.blackOrWhit == 0)//偶数のターン
        {//黒色にする

            counttop.topObjList.upFrontObj[p].GetComponent<CardsDate>().cardType = CardsDate.CARDTYPE.BLACK_CARD;
            counttop.downObjList.upFrontObj[p].GetComponent<CardsDate>().cardType = CardsDate.CARDTYPE.BLACK_CARD;
            counttop.rightObjList.upFrontObj[p].GetComponent<CardsDate>().cardType = CardsDate.CARDTYPE.BLACK_CARD;
            counttop.leftObjList.upFrontObj[p].GetComponent<CardsDate>().cardType = CardsDate.CARDTYPE.BLACK_CARD;

        }
        else if (turnScript.blackOrWhit == 1)//奇数のターン
        {//白色にする

            counttop.topObjList.upFrontObj[p].GetComponent<CardsDate>().cardType = CardsDate.CARDTYPE.WHIGHT_CARD;
            counttop.downObjList.upFrontObj[p].GetComponent<CardsDate>().cardType = CardsDate.CARDTYPE.WHIGHT_CARD;
            counttop.rightObjList.upFrontObj[p].GetComponent<CardsDate>().cardType = CardsDate.CARDTYPE.WHIGHT_CARD;
            counttop.leftObjList.upFrontObj[p].GetComponent<CardsDate>().cardType = CardsDate.CARDTYPE.WHIGHT_CARD;
        }
    }
}
