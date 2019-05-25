using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///////////////////////////////////////////////////////
//ボタンを押したときにカードを置く処理
//選択移動処理
//////////////////////////////////////////////////////////
public class PutTheCard : MonoBehaviour
{
    //script
    CardsDate cardsDate;
    SelectPlace playerPosition;
    Turn turnScript;
    CollCreate cardsPosition;

    //変数
    public bool isTurnOverOk;

    // Start is called before the first frame update
    void Start()
    {
        cardsDate = GetComponent<CardsDate>();
        playerPosition = GetComponent<SelectPlace>();
        cardsPosition = GetComponent<CollCreate>();
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
            for (int i = 0; i < 64; i++)
            {
                if (cardsPosition.Cards[i].myPos == playerPosition.player.pNow_pos)
                {//手札だったら
                    Debug.Log("aaaaaa");
                    if (cardsDate.cardPlace == CardsDate.CARDPLACE.HAND_CARD)
                    {
                        cardsDate.cardPlace = CardsDate.CARDPLACE.FRONT_CARD;//表において
                        if (turnScript.blackOrWhit == 0)//偶数のターン
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
}
