using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 挟んだカードをひっくり返す処理
/// </summary>
public class TurnOver : MonoBehaviour
{
    //script
    SelectPlace playerPosition;
    PutTheCard putTheCard;
    CollCreate cardsPosition;
    CardsDate cardsDate;
    CountTop countTop;
    ObjList objList;
    Turn turnScript;

    public bool isListAdd;//追加するとき
    // Start is called before the first frame update
    void Start()
    {
        putTheCard = GetComponent<PutTheCard>();
        playerPosition = GetComponent<SelectPlace>();
        cardsPosition = GetComponent<CollCreate>();
        cardsDate = GetComponent<CardsDate>();
        countTop = GetComponent<CountTop>();
        objList = GetComponent<ObjList>();
    }

    // Update is called once per frame
    void Update()
    {
        turnScript = GetComponent<Turn>();
        //Debug.Log(objList.frontObj.Count);
        //ひっくり返る
        if (countTop.isTurnOverStart == true)
        {
            objRead(countTop.topObjList);
            objRead(countTop.downObjList);
            objRead(countTop.rightObjList);
            objRead(countTop.leftObjList);
            putTheCard.isCountStart = false;
            countTop.isTurnOverStart = false;

        }
    }

    //読み込んで見やすいようにする
    void objRead(ObjList objList)
    {
        for (int i = 0; i < objList.frontObj.Count; i++)
        {//リストに入っているオブジェクトだけ処理する
            if (turnScript.blackOrWhit == 0)//偶数のターン
            {//黒色にする

                objList.frontObj[i].GetComponent<CardsDate>().cardType = CardsDate.CARDTYPE.BLACK_CARD;

            }
            else if (turnScript.blackOrWhit == 1)//奇数のターン
            {//白色にする

                objList.frontObj[i].GetComponent<CardsDate>().cardType = CardsDate.CARDTYPE.WHIGHT_CARD;
            }
        }
    }
}
