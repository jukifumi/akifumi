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

        //カードを置く
        if (Input.GetKeyDown(KeyCode.A) == true)
        {
            //Aキーを押したとき
            for (int i = 0; i < number; i++)
            {
                //選択している場所が
                if (i== playerPosition.myNumber)
                {
                    //手札だったら
                    //オブジェクトの情報を変数に格納する
                    var cardType = cardsPosition.Cards[i].gameobj.GetComponent<CardsDate>().cardType;
                    var cardPlace = cardsPosition.Cards[i].gameobj.GetComponent<CardsDate>().cardPlace;
                    
                    //手札にあるカードを置く処理
                    if (cardPlace == CardsDate.CARDPLACE.HAND_CARD)
                    {

                        cardPlace = CardsDate.CARDPLACE.FRONT_CARD;//表において

                        if (turnScript.blackOrWhit == 0)//偶数のターン
                        {
                            //黒色にする
                            cardType = CardsDate.CARDTYPE.BLACK_CARD;
                            isTurnOverOk = true;

                        }
                        else//奇数のターン
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
    //番号を持ってくる
    public void SetNum(int n)
    {
        number = n;
    }
}
