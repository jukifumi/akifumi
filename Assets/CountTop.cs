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
    SelectPlace playerPosition;
    CollCreate cardsPosition;
    ObjList objList;

    //変数
    int loopframe;
    bool flg;

    // Start is called before the first frame update
    void Start()
    {//初期化
        cardsDate      = GetComponent<CardsDate>();
        playerPosition = GetComponent<SelectPlace>();
        cardsPosition  = GetComponent<CollCreate>();
        objList        = GetComponent<ObjList>();

        //変数初期化
        loopframe = 8;
        flg = false;
    }

    // Update is called once per frame
    void Update()
    {
        /////////////////////////
        //途中
        /////////////////////////
        //上を数える
        for (int i = 0; i < 64; i++)
        {
            if (i == playerPosition.myNumber)
            {

                objList.floatObj.Add(i);
            }
        }

        /////////////////////////////////////////////////////
        //前のバージョン：参考にするために残している
        ////////////////////////////////////////////////////////
        //turnScript = GetComponent<Turn>();

        //上の残りの列を数える
        //int nowRow = (int)(selectPlace.selectPosition / 8 - 0.1f) + 1;

        //flg = false;
        //for (int i = 0; i < 8; i++)
        //{
        //    int num = selectPlace.selectPosition + (8 * (i + 1));
        //    if (cardsDate.cardNumber == num && flg == false)
        //    {
        //        if (cardsDate.cardPlace == CardsDate.CARDPLACE.FRONT_CARD)
        //        {

        //            objList.floatObj.Add(num);

        //        }
        //        else
        //        {
        //            flg = true;
        //        }
        //        if (cardsDate.playerCardType == cardsDate.cardType)
        //        {
        //            break;
        //        }
        //    }

        //}
    }
}