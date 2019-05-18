using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///////////////////////////////////////////////////////
//ボタンを押したときにカードを置く処理
//////////////////////////////////////////////////////////
public class PutTheCard : MonoBehaviour
{
    //script
    CardsDate cardsDate;
    SelectPlace selectPlace;
    Turn turnScript;

    //変数
    public bool isTurnOverOk;

    // Start is called before the first frame update
    void Start()
    {
        cardsDate = GetComponent<CardsDate>();
        selectPlace = GetComponent<SelectPlace>();

        isTurnOverOk = false;
    }

    // Update is called once per frame
    void Update()
    {
        turnScript = GetComponent<Turn>();

        //カードを置く
        //Aキーを押したとき
        if (Input.GetKeyDown(KeyCode.A) == true)
        {//選択している場所が
            if (cardsDate.cardNumber == selectPlace.selectPosition)
            {//手札だったら
                    //Debug.Log("aaaaaaaa");
                if (cardsDate.cardPlace == CardsDate.CARDPLACE.HAND_CARD)
                {
                    cardsDate.cardPlace = CardsDate.CARDPLACE.FRONT_CARD;//表において
                    if (turnScript.blackOrWhit==0)//偶数のターン
                    {//黒色にする
                        cardsDate.cardType = CardsDate.CARDTYPE.BLACK_CARD;
                        isTurnOverOk = true;
                    }
                    else//奇数のターン
                    {//白色にする
                        cardsDate.cardType = CardsDate.CARDTYPE.WHIGHT_CARD;
                        isTurnOverOk = true;
                    }
                }
            }
        }
    }
}
