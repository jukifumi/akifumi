using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTop : MonoBehaviour
{
    //ターン用アタッチするためのオブジェ
    GameObject turnCube;
    Turn turnScript;

    IamCard iamCard;
    SelectPlace selectPlace;

    //リスト用アタッチするためのオブジェ
    GameObject listCube;
    ObjList objList;



    int loopframe;
    bool flg;
    // Start is called before the first frame update
    void Start()
    {
        turnCube = GameObject.Find("turnControl");
        listCube = GameObject.Find("ListCube");
        iamCard = GetComponent<IamCard>();
        selectPlace = GetComponent<SelectPlace>();
        objList = listCube.GetComponent<ObjList>();
        loopframe = 8;
        flg = false;
    }

    // Update is called once per frame
    void Update()
    {
        turnScript = turnCube.GetComponent<Turn>();

        //上の残りの列を数える
        int nowRow = (int)(selectPlace.selectPosition / 8 - 0.1f) + 1;
        //Debug.Log(nowRow);
        //int selectUpUp = selectPosition += 8;

        flg = false;
        for (int i = 0; i < 8; i++)
        {
        int num = selectPlace.selectPosition + (8 * (i + 1));
        if (iamCard.cardNumber == num && flg == false)
        {
            if (iamCard.cardPlace == IamCard.CARDPLACE.FRONT_CARD)
            {

                objList.floatObj.Add(num);
                //Debug.Log(num);
                //if (cardType == 1)
                //{
                //    isListAdd = true;
                //}
            }
            else
            {
                flg = true;
            }
                if (iamCard.playerCardType == iamCard.cardType)
                {
                    break;
                }
            }
        
    }

        //}
        //while (true)
        //{
        //    for (int i = 0; i < 8; i++)
        //    {

        //    }
                
        //}
    }
}