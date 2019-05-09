using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOver : MonoBehaviour
{
    //ターン用アタッチするためのオブジェ
    GameObject turnCube;
    Turn turnScript;


    public bool isListAdd;//追加するとき
    GameObject listCube;
    ObjList objList;
    PutTheCard putTheCardScript;

    IamCard iamCard;
    // Start is called before the first frame update
    void Start()
    {
        turnCube = GameObject.Find("turnControl");
        listCube = GameObject.Find("ListCube");
        iamCard = GetComponent<IamCard>();
        objList = listCube.GetComponent<ObjList>();
        putTheCardScript = GetComponent<PutTheCard>();
    }

    // Update is called once per frame
    void Update()
    {
        turnScript = turnCube.GetComponent<Turn>();

        //Listに上の表に置いているオブジェクトを格納する
        if (isListAdd == false)
        {
            foreach (var item in objList.floatObj)
            {
                if (item == iamCard.cardNumber && iamCard.cardPlace == IamCard.CARDPLACE.FRONT_CARD)
                {//オブジェクトを控える
                    objList.upFrontObj.Add(this.gameObject);
                    isListAdd = true;
                }
            }
        }

        //ひっくり返る
        if (putTheCardScript.isTurnOverOk == true)
        {
            for (int i = 0; i < objList.upFrontObj.Count; i++)
            {
                if (turnScript.blackOrWhit==0)//偶数のターン
                {//黒色にする
                    objList.upFrontObj[i].GetComponent<IamCard>().cardType = IamCard.CARDTYPE.BLACK_CARD;
                }
                else if(turnScript.blackOrWhit == 1)
                {//白色にする
                    objList.upFrontObj[i].GetComponent<IamCard>().cardType = IamCard.CARDTYPE.WHIGHT_CARD;
                }
            }
        }
    }
}
