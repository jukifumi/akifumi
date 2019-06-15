using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////////////////////////
//個別のカード情報
//ゲームを始めた時に最初に置かれているカードのセット
//////////////////////////////////////////////////////////
public class CardsDate : MonoBehaviour
{
    ////script
    //BoardData boardData;
    ////objct
    //GameObject board;

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

    //public enum CARDCONDITION
    //{
    //    NONE_CARD,    // 0 = 何もない
    //    SELECT_CARD,  // 1 = 選んでいるところ
    //    CHOICE_CARD,  // 3 = 置けるところ
    //}

    public CARDPLACE cardPlace;
    public CARDTYPE cardType;
    //public CARDCONDITION cardCondition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
