using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//////////////////////////////////////////////////////////
//カードを置いた位置から上を数えてひっくり返すカードを見つける
////////////////////////////////////////////////////////////
public class CountTop : MonoBehaviour
{
    //script
    Turn turnScript;
    CardsDate cardsDate;
    SelectPlace playerPosition,isCountSet;
    CollCreate cardsPosition;
    public ObjList topObjList, downObjList, rightObjList, leftObjList;

    //変数
    int positionNum;//上向きに存在するカードの番号
    int sideCount;//横の残りマス数

    //8方向のポジション
    int topPos;
    int downPos;
    int rightPos;
    int leftPos;


    bool isDirectionCount;//数えた値を格納するときに制御するフラグ




    // Start is called before the first frame update
    void Start()
    {//初期化
        cardsDate      = GetComponent<CardsDate>();
        playerPosition = GetComponent<SelectPlace>();
        isCountSet     = GetComponent<SelectPlace>();
        cardsPosition  = GetComponent<CollCreate>();
        topObjList     = GetComponent<ObjList>();
        downObjList    = GetComponent<ObjList>();
        rightObjList   = GetComponent<ObjList>();
        leftObjList    = GetComponent<ObjList>();


        //変数初期化
        sideCount = 0;
        isDirectionCount = false;

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


        //列計算しやすいように一行目まで値を下げる
        if(sideCount - 7 > 0)
        {
            sideCount -= 8;
        }
        else
        {
            //Debug.Log(playerPosition.myNumber-sideCount);
        }


        //関数呼び出し
        CountAround(8,topPos, 64, topObjList);//上
        CountAround(-8,downPos, 0, downObjList);//下
        CountAround(1,rightPos, rightPos + (7 - sideCount), rightObjList);//右
        CountAround(-1,leftPos, leftPos-sideCount, leftObjList);//左
    }

    //8方向のマスを限界まで数える
    void CountAround(int numByDirection,int positionNum,int maxValue, ObjList obj)
    {
        //方向にあるマスを数える
        if (isCountSet.isCountSquaresInit == true)
        {
            //初期値
            sideCount = playerPosition.myNumber;
            positionNum = playerPosition.myNumber;

            //数えた値を格納できるようにする
            isDirectionCount = false;

            for (int i = 0; i < 7; i++)
            {
                //方向に応じた値を足して次のマスに進める
                positionNum += numByDirection;

                //その方向の値をListで管理して値を確認しやすいようにする
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

            //Listに上の表に置いているオブジェクトを格納する
            for (int i = 0; i < obj.floatObj.Count; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    //オブジェクトの情報を変数に格納する
                    var cardType = cardsPosition.Cards[j].gameobj.GetComponent<CardsDate>().cardType;
                    var cardPlace = cardsPosition.Cards[j].gameobj.GetComponent<CardsDate>().cardPlace;

                    if (j == obj.floatObj[i])
                    {
                        if (turnScript.blackOrWhit == 1)
                        {
                            if(cardPlace == CardsDate.CARDPLACE.FRONT_CARD &&
                                cardType == CardsDate.CARDTYPE.WHIGHT_CARD)
                            {


                                //オブジェクトを控える
                                obj.upFrontObj.Add(cardsPosition.Cards[j].gameobj);
                                //Debug.Log("iiiiiiiiiiiiiiiiiiiiii");
                                //isListAdd = true;
                                //Debug.Log(objList.upFrontObj[i]);

                            }
                            else
                            {
                                //最大値を入れてカウントを強制終了する
                                i = obj.floatObj.Count;
                                j = 64;
                            }
                        }

                        if (turnScript.blackOrWhit == 0)
                        {
                            if (cardPlace == CardsDate.CARDPLACE.FRONT_CARD &&
                                cardType == CardsDate.CARDTYPE.BLACK_CARD)
                            {
                                //オブジェクトを控える
                                obj.upFrontObj.Add(cardsPosition.Cards[j].gameobj);
                                //Debug.Log("aaaaaaaaaaaaaaaaaa");
                                //isListAdd = true;
                                //Debug.Log(objList.upFrontObj[i]);
                            }
                            else
                            {
                                //最大値を入れてカウントを強制終了する
                                i = obj.floatObj.Count;
                                j = 64;
                            }
                        }

                    }
                }
            }

            isCountSet.isCountSquaresInit = false;
        }
    }

}