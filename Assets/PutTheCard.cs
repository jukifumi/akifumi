using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ボタンを押したときにカードを置く処理
public class PutTheCard : MonoBehaviour
{
    IamCard iamCard;

    public bool isTurnOverOk;

    //ターン用アタッチするためのオブジェ
    GameObject turnCube;
    Turn turnScript;

    SelectPlace selectPlace;

    // Start is called before the first frame update
    void Start()
    {
        turnCube = GameObject.Find("turnControl");
        iamCard = GetComponent<IamCard>();
        selectPlace = GetComponent<SelectPlace>();

        isTurnOverOk = false;
    }

    // Update is called once per frame
    void Update()
    {
        turnScript = turnCube.GetComponent<Turn>();

        //カードを置く
        //Aキーを押したとき
        if (Input.GetKeyDown(KeyCode.A) == true)
        {//選択している場所が
            if (iamCard.cardNumber == selectPlace.selectPosition)
            {//手札だったら
                    //Debug.Log("aaaaaaaa");
                if (iamCard.cardPlace == IamCard.CARDPLACE.HAND_CARD)
                {
                    iamCard.cardPlace = IamCard.CARDPLACE.FRONT_CARD;//表において
                    if (turnScript.blackOrWhit==0)//偶数のターン
                    {//黒色にする
                        iamCard.cardType = IamCard.CARDTYPE.BLACK_CARD;
                        isTurnOverOk = true;
                    }
                    else//奇数のターン
                    {//白色にする
                        iamCard.cardType = IamCard.CARDTYPE.WHIGHT_CARD;
                        isTurnOverOk = true;
                    }
                }
            }
        }
    }
}
