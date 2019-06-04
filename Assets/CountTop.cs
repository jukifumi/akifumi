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
    SelectPlace    playerPosition, CountSquares;
    CollCreate     cardsPosition;
    Turn           turnScript;

    //変数
    int sideCount; //横の残りマス数

    //8方向のポジション
    //とりあえす４方向
    int topPos;
    int downPos;
    int rightPos;
    int leftPos;


    bool isDirectionCount; //数えた値を格納するときに制御するフラグ
    bool isPlusCount;      //正の数を使うとき
    bool isMinusCount;     //負の数を使うとき
    bool isNone;           //フラグを使わないとき

    //静的定数
    private const int MAX_CARDS = 64; //複製するオブジェクトの最大数
    private const int MAX_COLUMN = 8; //列の最大数

    // Start is called before the first frame update
    void Start()
    {
        //初期化
        playerPosition = GetComponent<SelectPlace>();
        CountSquares   = GetComponent<SelectPlace>();
        cardsPosition  = GetComponent<CollCreate>();
        topObjList     = GetComponent<ObjList>();
        downObjList    = GetComponent<ObjList>();
        rightObjList   = GetComponent<ObjList>();
        leftObjList    = GetComponent<ObjList>();


        //変数初期化
        sideCount = 0;

        isDirectionCount = false;
        isMinusCount = true;
        isPlusCount = true;
        isNone = false ;

        //ポジションをとる
        //positionNum = playerPosition.myNumber;
        topPos   = playerPosition.myNumber;
        downPos  = playerPosition.myNumber;
        rightPos = playerPosition.myNumber;
        leftPos  = playerPosition.myNumber;

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
        //CountAround(8,isPlusCount,isNone,topPos, 64, topObjList);//上
        //CountAround(-8,isNone, isMinusCount,downPos, 0, downObjList);//下
        //CountAround(1, isPlusCount,isNone, rightPos, rightPos + ((MAX_COLUMN - 1) - sideCount), rightObjList);//右
        //CountAround(-1,isNone, isMinusCount,leftPos, leftPos-sideCount, leftObjList);//左


        //方向にあるマスを数える
        if (CountSquares.isCountInit == true)
        {
            //初期値
            sideCount = playerPosition.myNumber;
            topPos = playerPosition.myNumber;

            //数えた値を格納できるようにする
            isDirectionCount = false;

            for (int i = 0; i < (MAX_COLUMN - 1); i++)
            {

                //方向に応じた値を足して次のマスに進める
                topPos += 8;

                //その方向の値をListで管理して値を確認しやすいようにする
                if (isPlusCount == true)
                {
                    if (topPos < 64 && isDirectionCount == false)
                    {
                        //List追加
                        topObjList.floatObj.Add(topPos);
                        //Debug.Log(maxValue);
                        //Debug.Log(obj.floatObj[i]);
                    }
                    else
                    {
                        //カウントを止めてforを抜ける
                        isDirectionCount = true;
                        break;

                    }
                }
            }

            //Listに上の表に置いているオブジェクトを格納する
            for (int i = 0; i < topObjList.floatObj.Count; i++)
            {
                for (int j = 0; j < MAX_CARDS; j++)
                {
                    //オブジェクトの情報を変数に格納する
                    var cardPlace = cardsPosition.Cards[j].gameobj.GetComponent<CardsDate>().cardPlace;
                    var cardType = cardsPosition.Cards[j].gameobj.GetComponent<CardsDate>().cardType;

                    if (j == topObjList.floatObj[i])
                    {
                        //黒のターン
                        if (turnScript.blackOrWhit == 1)
                        {
                            if (cardPlace == CardsDate.CARDPLACE.FRONT_CARD &&
                                cardType == CardsDate.CARDTYPE.WHIGHT_CARD)
                            {

                                //オブジェクトを追加する
                                topObjList.upFrontObj.Add(cardsPosition.Cards[j].gameobj);
                                Debug.Log(topObjList.upFrontObj[i]);
                            }
                            else
                            {
                                //挟んでないときは追加したオブジェクトを消す
                                if (cardType == CardsDate.CARDTYPE.WHIGHT_CARD)
                                {
                                    topObjList.upFrontObj.Clear();
                                }
                                //最大値を入れてカウントを強制終了する
                                i = topObjList.floatObj.Count;
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
                                topObjList.upFrontObj.Add(cardsPosition.Cards[j].gameobj);
                                Debug.Log(topObjList.upFrontObj[i]);
                            }
                            else
                            {
                                //挟んでないときは追加したオブジェクトを消す
                                if (cardType == CardsDate.CARDTYPE.BLACK_CARD)
                                {
                                    topObjList.upFrontObj.Clear();
                                }
                                //最大値を入れてカウントを強制終了する
                                i = topObjList.floatObj.Count;
                                j = MAX_CARDS;
                                break;
                            }
                        }

                    }
                }
            }

        //下

            //初期値
            downPos = playerPosition.myNumber;

            //数えた値を格納できるようにする
            isDirectionCount = false;

            for (int i = 0; i < (MAX_COLUMN - 1); i++)
            {

                //方向に応じた値を足して次のマスに進める
                downPos += -8;

                //その方向の値をListで管理して値を確認しやすいようにする

                if (isMinusCount == true)
                {
                    if (downPos > 0 && isDirectionCount == false)
                    {
                        //List追加
                        downObjList.floatObj.Add(downPos);
                        //Debug.Log(downObjList.floatObj[i]);
                    }
                    else
                    {
                        //カウントを止めてforを抜ける
                        isDirectionCount = true;
                        break;

                    }
                }
            }

            //Listに上の表に置いているオブジェクトを格納する
            for (int i = 0; i < downObjList.floatObj.Count; i++)
            {
                for (int j = 0; j < MAX_CARDS; j++)
                {
                    //オブジェクトの情報を変数に格納する
                    var cardPlace = cardsPosition.Cards[j].gameobj.GetComponent<CardsDate>().cardPlace;
                    var cardType = cardsPosition.Cards[j].gameobj.GetComponent<CardsDate>().cardType;

                    if (j == downObjList.floatObj[i])
                    {
                        //黒のターン
                        if (turnScript.blackOrWhit == 1)
                        {
                            if (cardPlace == CardsDate.CARDPLACE.FRONT_CARD &&
                                cardType == CardsDate.CARDTYPE.WHIGHT_CARD)
                            {

                                //オブジェクトを追加する
                                downObjList.upFrontObj.Add(cardsPosition.Cards[j].gameobj);
                                Debug.Log(downObjList.upFrontObj[i]);
                            }
                            else
                            {
                                //挟んでないときは追加したオブジェクトを消す
                                if (cardType == CardsDate.CARDTYPE.WHIGHT_CARD)
                                {
                                    downObjList.upFrontObj.Clear();
                                }
                                //最大値を入れてカウントを強制終了する
                                i = downObjList.floatObj.Count;
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
                                downObjList.upFrontObj.Add(cardsPosition.Cards[j].gameobj);
                                Debug.Log(downObjList.upFrontObj[i]);
                            }
                            else
                            {
                                //挟んでないときは追加したオブジェクトを消す
                                if (cardType == CardsDate.CARDTYPE.BLACK_CARD)
                                {
                                    downObjList.upFrontObj.Clear();
                                }
                                //最大値を入れてカウントを強制終了する
                                i = downObjList.floatObj.Count;
                                j = MAX_CARDS;
                                break;
                            }
                        }

                    }
                }
            }

            //右

            rightPos = playerPosition.myNumber;

            //数えた値を格納できるようにする
            isDirectionCount = false;

            for (int i = 0; i < (MAX_COLUMN - 1); i++)
            {

                //方向に応じた値を足して次のマスに進める
                rightPos += 1;

                //その方向の値をListで管理して値を確認しやすいようにする
                if (isPlusCount == true)
                {
                    if (rightPos < rightPos + ((MAX_COLUMN - 1) - sideCount) && isDirectionCount == false)
                    {
                        //List追加
                        rightObjList.floatObj.Add(rightPos);
                        //Debug.Log(maxValue);
                        //Debug.Log(obj.floatObj[i]);
                    }
                    else
                    {
                        //カウントを止めてforを抜ける
                        isDirectionCount = true;
                        break;

                    }
                }
                
            }

            //Listに上の表に置いているオブジェクトを格納する
            for (int i = 0; i < rightObjList.floatObj.Count; i++)
            {
                for (int j = 0; j < MAX_CARDS; j++)
                {
                    //オブジェクトの情報を変数に格納する
                    var cardPlace = cardsPosition.Cards[j].gameobj.GetComponent<CardsDate>().cardPlace;
                    var cardType = cardsPosition.Cards[j].gameobj.GetComponent<CardsDate>().cardType;

                    if (j == rightObjList.floatObj[i])
                    {
                        //黒のターン
                        if (turnScript.blackOrWhit == 1)
                        {
                            if (cardPlace == CardsDate.CARDPLACE.FRONT_CARD &&
                                cardType == CardsDate.CARDTYPE.WHIGHT_CARD)
                            {

                                //オブジェクトを追加する
                                rightObjList.upFrontObj.Add(cardsPosition.Cards[j].gameobj);
                                Debug.Log(rightObjList.upFrontObj[i]);
                            }
                            else
                            {
                                //挟んでないときは追加したオブジェクトを消す
                                if (cardType == CardsDate.CARDTYPE.WHIGHT_CARD)
                                {
                                    rightObjList.upFrontObj.Clear();
                                }
                                //最大値を入れてカウントを強制終了する
                                i = rightObjList.floatObj.Count;
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
                                rightObjList.upFrontObj.Add(cardsPosition.Cards[j].gameobj);
                                Debug.Log(rightObjList.upFrontObj[i]);
                            }
                            else
                            {
                                //挟んでないときは追加したオブジェクトを消す
                                if (cardType == CardsDate.CARDTYPE.BLACK_CARD)
                                {
                                    rightObjList.upFrontObj.Clear();
                                }
                                //最大値を入れてカウントを強制終了する
                                i = rightObjList.floatObj.Count;
                                j = MAX_CARDS;
                                break;
                            }
                        }

                    }
                }
            }

        //左
        
            leftPos = playerPosition.myNumber;

            //数えた値を格納できるようにする
            isDirectionCount = false;

            for (int i = 0; i < (MAX_COLUMN - 1); i++)
            {

                //方向に応じた値を足して次のマスに進める
                leftPos += -1;

                //その方向の値をListで管理して値を確認しやすいようにする
                if (isMinusCount == true)
                {
                    if (leftPos > leftPos - sideCount && isDirectionCount == false)
                    {
                        //List追加
                        leftObjList.floatObj.Add(leftPos);
                        //Debug.Log(downObjList.floatObj[i]);
                    }
                    else
                    {
                        //カウントを止めてforを抜ける
                        isDirectionCount = true;
                        break;

                    }
                }
            }

            //Listに上の表に置いているオブジェクトを格納する
            for (int i = 0; i < leftObjList.floatObj.Count; i++)
            {
                for (int j = 0; j < MAX_CARDS; j++)
                {
                    //オブジェクトの情報を変数に格納する
                    var cardPlace = cardsPosition.Cards[j].gameobj.GetComponent<CardsDate>().cardPlace;
                    var cardType = cardsPosition.Cards[j].gameobj.GetComponent<CardsDate>().cardType;

                    if (j == leftObjList.floatObj[i])
                    {
                        //黒のターン
                        if (turnScript.blackOrWhit == 1)
                        {
                            if (cardPlace == CardsDate.CARDPLACE.FRONT_CARD &&
                                cardType == CardsDate.CARDTYPE.WHIGHT_CARD)
                            {

                                //オブジェクトを追加する
                                leftObjList.upFrontObj.Add(cardsPosition.Cards[j].gameobj);
                                Debug.Log(leftObjList.upFrontObj[i]);
                            }
                            else
                            {
                                //挟んでないときは追加したオブジェクトを消す
                                if (cardType == CardsDate.CARDTYPE.WHIGHT_CARD)
                                {
                                    leftObjList.upFrontObj.Clear();
                                }
                                //最大値を入れてカウントを強制終了する
                                i = leftObjList.floatObj.Count;
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
                                leftObjList.upFrontObj.Add(cardsPosition.Cards[j].gameobj);
                                Debug.Log(leftObjList.upFrontObj[i]);
                            }
                            else
                            {
                                //挟んでないときは追加したオブジェクトを消す
                                if (cardType == CardsDate.CARDTYPE.BLACK_CARD)
                                {
                                    leftObjList.upFrontObj.Clear();
                                }
                                //最大値を入れてカウントを強制終了する
                                i = leftObjList.floatObj.Count;
                                j = MAX_CARDS;
                                break;
                            }
                        }

                    }
                }
            }

            CountSquares.isCountInit = false;
        }


        //列計算しやすいように一行目まで値を下げる
        if (sideCount - MAX_COLUMN >= 0)
        {
            sideCount -= MAX_COLUMN;
        }
        else
        {
            // Debug.Log(sideCount);
        }
    }

    //8方向のマスを限界まで数える
    //void CountAround(int numByDirection,bool Puls,bool Minus,int positionNum,int maxValue, ObjList obj)
    //{
    //    //方向にあるマスを数える
    //    if (CountSquares.isCountInit == true)
    //    {
    //        //初期値
    //        sideCount = playerPosition.myNumber;
    //        positionNum = playerPosition.myNumber;

    //        //数えた値を格納できるようにする
    //        isDirectionCount = false;

    //        for (int i = 0; i < (MAX_COLUMN - 1); i++)
    //        {

    //            //方向に応じた値を足して次のマスに進める
    //            positionNum += numByDirection;
                
    //            //その方向の値をListで管理して値を確認しやすいようにする
    //            if (Puls == true)
    //            {
    //                if (positionNum < maxValue && isDirectionCount == false)
    //                {
    //                    //List追加
    //                    obj.floatObj.Add(positionNum);
    //                    //Debug.Log(maxValue);
    //                    //Debug.Log(obj.floatObj[i]);
    //                }
    //                else
    //                {
    //                    //カウントを止めてforを抜ける
    //                    isDirectionCount = true;
    //                    break;

    //                }
    //            }
    //            if(Minus == true)
    //            {
    //                if (positionNum > maxValue && isDirectionCount == false)
    //                {
    //                    //List追加
    //                    obj.floatObj.Add(positionNum);
    //                    //Debug.Log(downObjList.floatObj[i]);
    //                }
    //                else
    //                {
    //                    //カウントを止めてforを抜ける
    //                    isDirectionCount = true;
    //                    break;

    //                }
    //            }
    //        }

    //        //Listに上の表に置いているオブジェクトを格納する
    //        for (int i = 0; i < obj.floatObj.Count; i++)
    //        {
    //            for (int j = 0; j < MAX_CARDS; j++)
    //            {
    //                //オブジェクトの情報を変数に格納する
    //                var cardPlace = cardsPosition.Cards[j].gameobj.GetComponent<CardsDate>().cardPlace;
    //                var cardType  = cardsPosition.Cards[j].gameobj.GetComponent<CardsDate>().cardType;

    //                if (j == obj.floatObj[i])
    //                {
    //                    //黒のターン
    //                    if (turnScript.blackOrWhit == 1)
    //                    {
    //                        if(cardPlace == CardsDate.CARDPLACE.FRONT_CARD &&
    //                            cardType == CardsDate.CARDTYPE.WHIGHT_CARD)
    //                        {

    //                            //オブジェクトを追加する
    //                            obj.upFrontObj.Add(cardsPosition.Cards[j].gameobj);
    //                            Debug.Log(obj.upFrontObj[i]);
    //                        }
    //                        else
    //                        {
    //                            //挟んでないときは追加したオブジェクトを消す
    //                            if(cardType == CardsDate.CARDTYPE.WHIGHT_CARD)
    //                            {
    //                                obj.upFrontObj.Clear();
    //                            }
    //                            //最大値を入れてカウントを強制終了する
    //                            i = obj.floatObj.Count;
    //                            j = MAX_CARDS;
    //                            break;
    //                        }
    //                    }

    //                    //白のターン
    //                    if (turnScript.blackOrWhit == 0)
    //                    {
    //                        if (cardPlace == CardsDate.CARDPLACE.FRONT_CARD &&
    //                            cardType == CardsDate.CARDTYPE.BLACK_CARD)
    //                        {
    //                            //オブジェクトを追加する
    //                            obj.upFrontObj.Add(cardsPosition.Cards[j].gameobj);
    //                            Debug.Log(obj.upFrontObj[i]);
    //                        }
    //                        else
    //                        {
    //                            //挟んでないときは追加したオブジェクトを消す
    //                            if (cardType == CardsDate.CARDTYPE.BLACK_CARD)
    //                            {
    //                                obj.upFrontObj.Clear();
    //                            }
    //                            //最大値を入れてカウントを強制終了する
    //                            i = obj.floatObj.Count;
    //                            j = MAX_CARDS;
    //                            break;
    //                        }
    //                    }

    //                }
    //            }
    //        }

    //        CountSquares.isCountInit = false;
    //    }
    //}

}