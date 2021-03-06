﻿using System.Collections;
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
    int topPos;
    int downPos;
    int rightPos;
    int leftPos;


    //bool isDirectionCount; //数えた値を格納するときに制御するフラグ
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
        CountSquares = GetComponent<SelectPlace>();
        cardsPosition = GetComponent<CollCreate>();
        topObjList = GetComponent<ObjList>();
        downObjList = GetComponent<ObjList>();
        rightObjList = GetComponent<ObjList>();
        leftObjList = GetComponent<ObjList>();


        //変数初期化
        sideCount = 0;

        //isDirectionCount = false;
        isMinusCount = true;
        isPlusCount = true;
        isNone = false;

        //ポジションをとる
        //positionNum = playerPosition.myNumber;
        topPos = playerPosition.myNumber;
        downPos = playerPosition.myNumber;
        rightPos = playerPosition.myNumber;
        leftPos = playerPosition.myNumber;

    }


    // Update is called once per frame
    void Update()
    {
        //毎フレームターン呼び出し
        //毎フレームしないとターンが変わらない
        turnScript = GetComponent<Turn>();


        //関数呼び出し
        //InsertList();
        //cardTypeJudgment();
        //バグ
        //なぜか一個だけしか実装できない
        //右は完全にできない（maxValueの引数の値が違うかも）
        CountAround(8,isPlusCount,isNone,topPos, 64, topObjList);//上
        CountAround(-8,isNone, isMinusCount,downPos, 0, downObjList);//下
        //CountAround(1, isPlusCount,isNone, rightPos, rightPos + ((MAX_COLUMN - 1) - sideCount), rightObjList);//右
        CountAround(-1,isNone, isMinusCount,leftPos, leftPos-sideCount, leftObjList);//左
        CountSquares.isCountInit = false;


        
    }

    //8方向のマスを限界まで数える
    void CountAround(int numByDirection, bool Puls, bool Minus, int positionNum, int maxValue, ObjList obj)
    {
        //方向にあるマスを数える
        if (CountSquares.isCountInit == true)
        {
            //Debug.Log("aaaa");
            //初期値
            sideCount = playerPosition.myNumber;
            
            positionNum = playerPosition.myNumber;

            //数えた値を格納できるようにする
            bool isDirectionCount = false;

            for (int i = 0; i < (MAX_COLUMN - 1); i++)
            {

                //    //列計算しやすいように一行目まで値を下げる
                if (sideCount - MAX_COLUMN >= 0)
                {
                    sideCount -= MAX_COLUMN;
                }
                else
                {
                    // Debug.Log(sideCount);
                }
                //Debug.Log(sideCount);

                //方向に応じた値を足して次のマスに進める
                positionNum += numByDirection;

                //その方向の値をListで管理して値を確認しやすいようにする
                if (Puls == true)
                {
                    if (positionNum < maxValue && isDirectionCount == false)
                    {
                            //List追加
                            obj.floatObj.Add(positionNum);
                    }
                    else
                    {
                        //カウントを止めてforを抜ける
                        isDirectionCount = true;
                        break;
                    }
                }
                if (Minus == true)
                {
                    if (positionNum > maxValue && isDirectionCount == false)
                    {
                        //List追加
                        obj.floatObj.Add(positionNum);

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
            for (int i = 0; i < obj.floatObj.Count; i++)
            {
                for (int j = 0; j < MAX_CARDS; j++)
                {
                    //オブジェクトの情報を変数に格納する
                    var cardPlace = cardsPosition.Cards[j].gameobj.GetComponent<CardsDate>().cardPlace;
                    var cardType = cardsPosition.Cards[j].gameobj.GetComponent<CardsDate>().cardType;

                    if (j == obj.floatObj[i])
                    {
                        //黒のターン
                        if (turnScript.blackOrWhit == 1)
                        {
                            if (cardPlace == CardsDate.CARDPLACE.FRONT_CARD &&
                                cardType == CardsDate.CARDTYPE.WHIGHT_CARD)
                            {

                                //オブジェクトを追加する
                                ListAdd(obj, j);
                                //Debug.Log(obj.upFrontObj[i]);
                            }
                            else
                            {
                                //挟んでないときは追加したオブジェクトを消す
                                if (cardType == CardsDate.CARDTYPE.WHIGHT_CARD)
                                {
                                    //Listに追加した値を消す
                                    ListClear(obj);
                                }
                                //最大値を入れてカウントを強制終了する
                                i = obj.floatObj.Count;
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
                                ListAdd(obj, j);
                                //Debug.Log(downObjList.upFrontObj[i]);
                                //Debug.Log(obj.upFrontObj[i]);
                            }
                            else
                            {
                                //挟んでないときは追加したオブジェクトを消す
                                if (cardType == CardsDate.CARDTYPE.BLACK_CARD)
                                {
                                    //Listに追加した値を消す
                                    ListClear(obj);
                                }
                                //最大値を入れてカウントを強制終了する
                                i = obj.floatObj.Count;
                                j = MAX_CARDS;
                                break;
                            }
                        }

                    }
                }
                
            }
        }
    }

    void ListAdd(ObjList obj,int number)
    {
        //オブジェクトを追加する
        if (obj == topObjList)
        {
            obj.upFrontObj.Add(cardsPosition.Cards[number].gameobj);
        }
        if (obj == downObjList)
        {
            obj.downFrontObj.Add(cardsPosition.Cards[number].gameobj);
        }
        if (obj == rightObjList)
        {
            obj.rightFrontObj.Add(cardsPosition.Cards[number].gameobj);
        }
        if (obj == leftObjList)
        {
            obj.leftFrontObj.Add(cardsPosition.Cards[number].gameobj);
        }
    }

    void ListClear(ObjList obj)
    {
        //Listに追加した値を消す
        if (obj == topObjList)
        {
            obj.upFrontObj.Clear();
        }
        if (obj == downObjList)
        {
            obj.downFrontObj.Clear();
        }
        if (obj == rightObjList)
        {
            obj.rightFrontObj.Clear();
        }
        if (obj == leftObjList)
        {
            obj.leftFrontObj.Clear();
        }
    }

}