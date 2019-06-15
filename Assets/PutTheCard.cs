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
    PlayerManager player;
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
    public bool isCountStart;



    // Start is called before the first frame update
    void Start()
    {
        player  = GetComponent<PlayerManager>();
        cardsPosition   = GetComponent<CollCreate>();

        isCountStart = false;

        canTop = false;
        canDown=false;
        canRight=false;
        canLeft=false;
    }

    // Update is called once per frame
    void Update()
    {
        //毎フレームターン呼び出し
        //毎フレームしないとターンが変わらない
        turnScript = GetComponent<Turn>();

        //カードを置く
        if (Input.GetKeyDown(KeyCode.A) == true)
        {
            //canTop   = AroundCanLeave(canTop, player.Vget(0, 1));
            //canDown  = AroundCanLeave(canDown, player.Vget(0, -1));
            //canRight = AroundCanLeave(canRight, player.Vget(1, 0));
            //canLeft  = AroundCanLeave(canLeft, player.Vget(-1, 0));

            //フラグを立てて置けるようにする
            //if (canTop == true || canDown == true || canRight == true || canLeft == true)
            //{
            //    putOk = true;
            //    Debug.Log("aaaaa");
            //}

            //if (putOk == true)
            //{
                //Debug.Log("aaaaaaaaa");
                //Aキーを押したとき
                for (int i = 0; i < number; i++)
                {
                    Vector2 cardPos = cardsPosition.Cards[i].myPos;
                    //選択している場所が

                    if (cardPos == player.position.pNow_pos)
                    {//&& putOk == true　後で使う

                        //手札だったら
                        //オブジェクトの情報を変数に格納する
                        var cardType = cardsPosition.Cards[i].data.cardType;
                        var cardPlace = cardsPosition.Cards[i].data.cardPlace;

                        //手札にあるカードを置く処理
                        if (cardPlace == CardsDate.CARDPLACE.HAND_CARD)
                        {
                            //表において
                            cardPlace = CardsDate.CARDPLACE.FRONT_CARD;

                            if (turnScript.blackOrWhit == 0)
                            {
                                //黒色にする
                                cardType = CardsDate.CARDTYPE.BLACK_CARD;
                                isCountStart = true;

                            }
                            else
                            {
                                //白色にする
                                cardType = CardsDate.CARDTYPE.WHIGHT_CARD;
                                isCountStart = true;

                            }
                        }

                        //書き換えた値をオブジェクトに返す
                        cardsPosition.Cards[i].data.cardType = cardType;
                        cardsPosition.Cards[i].data.cardPlace = cardPlace;
                    }
               // }
            }
        }
    }

    //周りの状態から置いていいか決める
    //後で使う
    //bool AroundCanLeave( bool canPut, Vector2 ShiftedPos)
    //{
    //    canPut = false;

    //    //選択している場所が
    //        for (int i = 0; i < number; i++)
    //        {
    //            if(player.position.pNow_pos + ShiftedPos == cardsPosition.Cards[i].myPos)
    //        {
    //            //手札だったら
    //            //オブジェクトの情報を変数に格納する
    //            var cardType = cardsPosition.Cards[i].data.cardType;
    //            var cardPlace = cardsPosition.Cards[i].data.cardPlace;

    //            //手札にあるカードを置く処理
    //            if (cardPlace == CardsDate.CARDPLACE.FRONT_CARD)
    //            {
    //                if (turnScript.blackOrWhit == 0 &&
    //                cardType == CardsDate.CARDTYPE.BLACK_CARD)
    //                {
    //                    //Debug.Log("aaaaaaaaa");
    //                    canPut = true;
    //                }
    //                else
    //                {
    //                    canPut = false;
    //                }
    //                if (turnScript.blackOrWhit == 1 &&
    //                    cardType == CardsDate.CARDTYPE.WHIGHT_CARD)
    //                {
    //                    //Debug.Log("aaaaaaaaa");
    //                    canPut = true;
    //                }
    //                else
    //                {
    //                    canPut = false;
    //                }
    //            }
    //        }
    //    }
    //    return canPut;
    //}

    //番号を持ってくる
    public void SetNum(int n)
    {
        number = n;
    }
}
