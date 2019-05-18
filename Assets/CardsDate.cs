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

    public CARDPLACE cardPlace;
    public CARDTYPE cardType,playerCardType;

    //カードの番号
    public int cardNumber;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MaterialChange();

        if(cardPlace != CardsDate.CARDPLACE.HAND_CARD)
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
    }
    //色を変える処理
    void MaterialChange()
    {
        ////駒を置く場所を選んでいるときその場所を赤色にする
        //if (select == true)
        //{
        //    GetComponent<MeshRenderer>().enabled = true;
        //    GetComponent<Renderer>().material.color = Color.red;
        //    if (isLiftObj == false)
        //    {//選択しているオブジェを少し上に浮かす
        //        gameObject.transform.position += new Vector3(0, 0.5f, 0);
        //        isLiftObj = true;
        //    }
        //}
        //else
        //{
        //    isLiftObj = false;
        //    //浮かしたオブジェを元の位置に戻す
        //    gameObject.transform.position = initPosition;
        //}

        //マテリアルの色を変える
        if (cardPlace == CardsDate.CARDPLACE.FRONT_CARD)
        {
            if (cardType == CardsDate.CARDTYPE.BLACK_CARD)
            {

                    GetComponent<Renderer>().material.color = Color.black;
                
            }
            else if (cardType == CardsDate.CARDTYPE.WHIGHT_CARD)
            {

                    GetComponent<Renderer>().material.color = Color.white;
                
            }
        }
    }
}
