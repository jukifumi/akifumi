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
    SelectPlace playerPosition,flgSet;
    CollCreate cardsPosition;
    ObjList objList;

    //変数
    int topNum;//上向きに存在するカードの番号
    bool countflg;//数えた値を格納するときに制御するフラグ
    bool countStop;

    // Start is called before the first frame update
    void Start()
    {//初期化
        cardsDate      = GetComponent<CardsDate>();
        playerPosition = GetComponent<SelectPlace>();
        flgSet = GetComponent<SelectPlace>();
        cardsPosition  = GetComponent<CollCreate>();
        objList        = GetComponent<ObjList>();

        
        //変数初期化
        topNum = playerPosition.myNumber;
        countflg = false;
        countStop = false;
    }

    // Update is called once per frame
    void Update()
    {

        turnScript = GetComponent<Turn>();

        //上を数える
        if (flgSet.countInit == true)
        {
            topNum = playerPosition.myNumber;
            countflg = false;
            for (int q = 0; q < 8; q++)
            {
                topNum += 8;
                if (topNum < 64 && countflg == false)
                {
                    objList.floatObj.Add(topNum);

                }
                else
                {
                    countflg = true;
                    break;
                }
                //Debug.Log(objList.floatObj[q]);
            }

            //Listに上の表に置いているオブジェクトを格納する
            for (int i = 0; i < objList.floatObj.Count; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    //オブジェクトの情報を変数に格納する

                    //バグが治ったら試すため残している
                    //var cardType = cardsPosition.Cards[j].gameobj.GetComponent<CardsDate>().cardType;
                    //var cardPlace = cardsPosition.Cards[j].gameobj.GetComponent<CardsDate>().cardPlace;

                    if (j == objList.floatObj[i])
                    {
                        if (turnScript.blackOrWhit == 0)
                        {
                            if (cardsPosition.Cards[j].gameobj.GetComponent<CardsDate>().cardPlace == CardsDate.CARDPLACE.FRONT_CARD&&
                              cardsPosition.Cards[j].gameobj.GetComponent<CardsDate>().cardType == CardsDate.CARDTYPE.WHIGHT_CARD&&
                              countStop==false)
                            {
                                //オブジェクトを控える
                                objList.upFrontObj.Add(cardsPosition.Cards[j].gameobj);
                                //Debug.Log("iiiiiiiiiiiiiiiiiiiiii");
                                //isListAdd = true;
                                //Debug.Log(objList.upFrontObj[i]);
                              
                            }
                            else
                            {
                                countStop = true;
                            }
                        }
                        ////////////////////////////////////////////////////
                        //使う
                        //デバッグするために隠している
                        /////////////////////////////////////////////////
                        
                        //if (turnScript.blackOrWhit == 1)
                        //{
                        //    if (cardsPosition.Cards[j].gameobj.GetComponent<CardsDate>().cardPlace == CardsDate.CARDPLACE.FRONT_CARD &&
                        //        cardsPosition.Cards[j].gameobj.GetComponent<CardsDate>().cardType == CardsDate.CARDTYPE.BLACK_CARD)
                        //    {
                        //        オブジェクトを控える
                        //        objList.upFrontObj.Add(cardsPosition.Cards[j].gameobj);
                        //        Debug.Log("aaaaaaaaaaaaaaaaaa");
                        //        isListAdd = true;
                        //        Debug.Log(objList.upFrontObj[i]);
                        //    }
                        //}

                    }
                }
            }

            flgSet.countInit = false;
        }

    }
}