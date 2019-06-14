using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//////////////////////////////////////////////////////////
//カードを置いた位置から8方向数えてひっくり返すカードを見つける
////////////////////////////////////////////////////////////
public class CountTop : MonoBehaviour
{
    //script
    public ObjList topObjList, downObjList, rightObjList, leftObjList;
    SelectPlace playerPosition, CountSquares;
    CollCreate cardsPosition;
    Turn turnScript;

    //変数
    int sideCount; //横の残りマス数

    //8方向のポジション
    //とりあえす４方向
    Vector2 topPos;
    Vector2 downPos;
    Vector2 rightPos;
    Vector2 leftPos;

    //二次元
    Vector2 Vget(int x, int y)
    {
        Vector2 vector;
        vector.x = x;
        vector.y = y;
        return vector;
    }


    //静的定数
    private const int MAX_CARDS = 64; //複製するオブジェクトの最大数
    private const int MAX_COLUMN = 8; //列の最大数
    private const int MAX_LINE = 8;

    // Start is called before the first frame update
    void Start()
    {
        //初期化
        playerPosition = GetComponent<SelectPlace>();
        CountSquares = GetComponent<SelectPlace>();
        cardsPosition = GetComponent<CollCreate>();
        topObjList = GetComponent<ObjList>();
        downObjList = GetComponent<ObjList>();
        rightObjList = GetComponent<ObjList>();
        leftObjList = GetComponent<ObjList>();


        //変数初期化
        sideCount = 0;


        //ポジションをとる
        //positionNum = playerPosition.myNumber;
        topPos = Vget(0, 0);
        downPos = Vget(0, 0);
        rightPos = Vget(0, 0);
        leftPos = Vget(0, 0);

    }


    // Update is called once per frame
    void Update()
    {
        //毎フレームターン呼び出し
        //毎フレームしないとターンが変わらない
        turnScript = GetComponent<Turn>();


        //関数呼び出し

        //バグ
        //なぜか一個だけしか実装できない
        //右は完全にできない（maxValueの引数の値が違うかも）
        CountAround(topPos,Vget(0,1), topObjList);//上
        CountAround(downPos, Vget(0,-1), downObjList);//下
        CountAround(rightPos, Vget(1, 0), rightObjList);//右
        CountAround(leftPos, Vget(-1,0), leftObjList);//左
        CountSquares.isCountInit = false;



    }

    /// <summary>
    /// 8方向のマスを限界まで数える
    /// </summary>
    /// <param name="positionNum">ポジションのコピー</param>
    /// <param name="x">ｘに足す値</param>
    /// <param name="y">ｙに足す値</param>
    /// <param name="numByDirection">その方向に足す値</param>
    /// <param name="obj">オブジェクトの情報を持ってくる</param>
    void CountAround(Vector2 positionNum, Vector2 numByDirection, ObjList obj)
    {
        //方向にあるマスを数える
        if (CountSquares.isCountInit == true)
        {

            //初期値
            // sideCount = playerPosition.myNumber;

            positionNum = playerPosition.player.pNow_pos;
            for (int i = 0; i < MAX_COLUMN; i++)
            {

                //方向に合わせた次のマスを見る
                if (positionNum.x + numByDirection.x <= (MAX_COLUMN - 1) && 
                    0 <= positionNum.x &&
                    positionNum.y + numByDirection.y <= (MAX_LINE - 1) &&
                    0 <= positionNum.y)
                {
                    positionNum += numByDirection;
                }

                //Listに上の表に置いているオブジェクトを格納する
                for (int j = 0; j < MAX_CARDS; j++)
                {
                    if (cardsPosition.Cards[j].myPos == positionNum)
                    {

                        //オブジェクトの情報を変数に格納する
                        var cardPlace = cardsPosition.Cards[j].data.cardPlace;
                        var cardType = cardsPosition.Cards[j].data.cardType;

                        //黒のターン
                        if (turnScript.blackOrWhit == 1)
                        {
                            if (cardPlace == CardsDate.CARDPLACE.FRONT_CARD &&
                                cardType == CardsDate.CARDTYPE.WHIGHT_CARD)
                            {
                                //オブジェクトを追加する
                                obj.frontObj.Add(cardsPosition.Cards[j].gameobj);
                            }
                            else
                            {
                                //挟んでないときは追加したオブジェクトを消す
                                if (cardPlace == CardsDate.CARDPLACE.HAND_CARD)
                                {
                                    //Listに追加した値を消す
                                    obj.frontObj.Clear();
                                }
                                //最大値を入れてカウントを強制終了する
                                i = 8;
                                j = MAX_CARDS;
                                break;
                            }
                        }

                        //白のターン
                        if (turnScript.blackOrWhit == 0)
                        {
                            if (cardPlace == CardsDate.CARDPLACE.FRONT_CARD &&
                                cardType == CardsDate.CARDTYPE.BLACK_CARD)
                            {
                                //オブジェクトを追加する
                                obj.frontObj.Add(cardsPosition.Cards[j].gameobj);
                            }
                            else
                            {
                                //挟んでないときは追加したオブジェクトを消す
                                if (cardPlace == CardsDate.CARDPLACE.HAND_CARD)
                                {
                                    //Listに追加した値を消す
                                    obj.frontObj.Clear();
                                }
                                //最大値を入れてカウントを強制終了する
                                i = 8;
                                j = MAX_CARDS;
                                break;
                            }
                        }

                    }
                }
            }
        }
    }
}