using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///////////////////////////////////////////////////////
//ボタンを押したときにカードを置く処理
//選択移動処理
//////////////////////////////////////////////////////////
public class PutTheCard : MonoBehaviour
{
    //script
    SelectPlace playerPosition;
    CollCreate  cardsPosition;
    Turn        turnScript;

    //変数
    int number;

    //周りが置けるか判断する
    bool canTop;
    bool canDown;
    bool canRight;
    bool canLeft;

    bool putOk;//置けるとき
    public bool isTurnOverOk;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition  = GetComponent<SelectPlace>();
        cardsPosition   = GetComponent<CollCreate>();

        isTurnOverOk    = false;
    }

    // Update is called once per frame
    void Update()
    {
        //毎フレームターン呼び出し
        //毎フレームしないとターンが変わらない
        turnScript = GetComponent<Turn>();

        //関数呼び出し
        //後で使う
        //AroundStateTheCanLeave(canTop, 8);
        //AroundStateTheCanLeave(canDown, -8);
        //AroundStateTheCanLeave(canRight, 1);
        //AroundStateTheCanLeave(canLeft, -1);

        //フラグを立てて置けるようにする
        if (canTop == true || canDown == true || canRight == true || canLeft == true)
        {
            putOk = true;
        }

        //カードを置く
        if (Input.GetKeyDown(KeyCode.A) == true)
        {
            //Aキーを押したとき
            for (int i = 0; i < number; i++)
            {
                //選択している場所が
                if (i== playerPosition.myNumber )
                {//&& putOk == true　後で使う

                    //手札だったら
                    //オブジェクトの情報を変数に格納する
                    var cardType = cardsPosition.Cards[i].gameobj.GetComponent<CardsDate>().cardType;
                    var cardPlace = cardsPosition.Cards[i].gameobj.GetComponent<CardsDate>().cardPlace;
                    
                    //手札にあるカードを置く処理
                    if (cardPlace == CardsDate.CARDPLACE.HAND_CARD)
                    {
                        //表において
                        cardPlace = CardsDate.CARDPLACE.FRONT_CARD;

                        if (turnScript.blackOrWhit == 0)
                        {
                            //黒色にする
                            cardType = CardsDate.CARDTYPE.BLACK_CARD;
                            isTurnOverOk = true;

                        }
                        else
                        {
                            //白色にする
                            cardType = CardsDate.CARDTYPE.WHIGHT_CARD;
                            isTurnOverOk = true;

                        }
                    }

                    //書き換えた値をオブジェクトに返す
                    cardsPosition.Cards[i].gameobj.GetComponent<CardsDate>().cardType = cardType;
                    cardsPosition.Cards[i].gameobj.GetComponent<CardsDate>().cardPlace = cardPlace;
                }
            }
        }
    }

    //周りの状態から置いていいか決める
    //後で使う
    //void AroundStateTheCanLeave(bool canPut,int ShiftedPos)
    //{
    //    canPut = false;

    //    for (int i = 0; i < number; i++)
    //    {
    //        //選択している場所が
    //        if (i == playerPosition.myNumber + ShiftedPos)
    //        {
    //            //手札だったら
    //            //オブジェクトの情報を変数に格納する
    //            var cardType  = cardsPosition.Cards[i].gameobj.GetComponent<CardsDate>().cardType;
    //            var cardPlace = cardsPosition.Cards[i].gameobj.GetComponent<CardsDate>().cardPlace;

    //            //手札にあるカードを置く処理
    //            if (cardPlace == CardsDate.CARDPLACE.FRONT_CARD)
    //            {
    //                if (turnScript.blackOrWhit == 0 &&
    //                cardType == CardsDate.CARDTYPE.BLACK_CARD)
    //                {
    //                    Debug.Log("aaaaaaaaa");
    //                    canPut = true;

    //                }
    //                else if (turnScript.blackOrWhit == 1 &&
    //                    cardType == CardsDate.CARDTYPE.WHIGHT_CARD)
    //                {
    //                    canPut = true;
    //                }
    //            }
    //        }
    //    }
    //}

    //番号を持ってくる
    public void SetNum(int n)
    {
        number = n;
    }
}
