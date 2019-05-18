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

    public bool isListAdd;//追加するとき
    // Start is called before the first frame update
    void Start()
    {
        cardsDate = GetComponent<CardsDate>();
        objList = GetComponent<ObjList>();
        putTheCardScript = GetComponent<PutTheCard>();
    }

    // Update is called once per frame
    void Update()
    {
        turnScript = GetComponent<Turn>();

        //Listに上の表に置いているオブジェクトを格納する
        if (isListAdd == false)
        {
            foreach (var item in objList.floatObj)
            {
                if (item == cardsDate.cardNumber && cardsDate.cardPlace == CardsDate.CARDPLACE.FRONT_CARD)
                {//オブジェクトを控える
                    objList.upFrontObj.Add(this.gameObject);
                    isListAdd = true;
                }
            }
        }

        //ひっくり返る
        if (putTheCardScript.isTurnOverOk == true)
        {
            for (int i = 0; i < objList.upFrontObj.Count; i++)
            {
                if (turnScript.blackOrWhit==0)//偶数のターン
                {//黒色にする
                    objList.upFrontObj[i].GetComponent<CardsDate>().cardType = CardsDate.CARDTYPE.BLACK_CARD;
                }
                else if(turnScript.blackOrWhit == 1)
                {//白色にする
                    objList.upFrontObj[i].GetComponent<CardsDate>().cardType = CardsDate.CARDTYPE.WHIGHT_CARD;
                }
            }
        }
    }
}
