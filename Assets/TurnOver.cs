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

    public bool isListAdd;//追加するとき
    // Start is called before the first frame update
    void Start()
    {
        putTheCardScript = GetComponent<PutTheCard>();
        playerPosition   = GetComponent<SelectPlace>();
        cardsPosition    = GetComponent<CollCreate>();
        cardsDate        = GetComponent<CardsDate>();
        objList          = GetComponent<ObjList>();
    }

    // Update is called once per frame
    void Update()
    {
        turnScript = GetComponent<Turn>();

        ////////////////////////////////////////////////
        //前のバージョン：参考にするために残している
        ////////////////////////////////////////////////
        //Listに上の表に置いているオブジェクトを格納する
        //if (isListAdd == false)
        //{
        //    {//オブジェクトを控える
        //        objList.upFrontObj.Add(cardsPosition.Cards[i].gameObj);
        //        isListAdd = true;
        //    }
        //}
 

        //ひっくり返る
        if (putTheCardScript.isTurnOverOk == true)
        {
            for (int i = 0; i < objList.upFrontObj.Count; i++)
            {//リストに入っているオブジェクトだけ処理する

                if (turnScript.blackOrWhit==0)//偶数のターン
                {//黒色にする

                    objList.upFrontObj[i].GetComponent<CardsDate>().cardType = CardsDate.CARDTYPE.BLACK_CARD;

                }
                else if(turnScript.blackOrWhit == 1)//奇数のターン
                {//白色にする

                    objList.upFrontObj[i].GetComponent<CardsDate>().cardType = CardsDate.CARDTYPE.WHIGHT_CARD;

                }
            }
        }
    }
}
