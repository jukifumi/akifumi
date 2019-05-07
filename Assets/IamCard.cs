using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//個別のカード情報
public class IamCard : MonoBehaviour
{
    //ターン用アタッチするためのオブジェ
    GameObject turnCube;
    Turn turnScript;

    //カードの場所
    public enum CARDPLACE
    {
        HAND_CARD,    // 0 =　手札
        FRONT_CARD,    // 1 =　表
        BACK_CARD,    // 2 =　裏
    }

    //カードの種類
    public enum CARDTYPE
    {
        BLACK_CARD,    // 0 = 黒
        WHIGHT_CARD,    // 1 = 白
        JOKER_CARD,    // 2 = ジョーカー
    }

    public CARDPLACE cardPlace;
    public CARDTYPE cardType,playerCardType;

    //カードの番号
    public int cardNumber;

    // Start is called before the first frame update
    void Start()
    {
        turnCube = GameObject.Find("turnControl");

        //初期配置
        if (cardNumber == 28)
        {
            cardType = CARDTYPE.WHIGHT_CARD;
            cardPlace = CARDPLACE.FRONT_CARD;
        }
        if (cardNumber == 29)
        {
            cardType = CARDTYPE.BLACK_CARD;
            cardPlace = CARDPLACE.FRONT_CARD;
        }
        if (cardNumber == 36)
        {
            cardType = CARDTYPE.BLACK_CARD;
            cardPlace = CARDPLACE.FRONT_CARD;
        }
        if (cardNumber == 37)
        {
            cardType = CARDTYPE.WHIGHT_CARD;
            cardPlace = CARDPLACE.FRONT_CARD;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
