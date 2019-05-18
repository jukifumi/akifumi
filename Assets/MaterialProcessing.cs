using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialProcessing : MonoBehaviour {

    GameObject master;
    SelectPlace selectMode;
    CardsDate cardsDate;
    CollCreate cards;

    //ベクトル
    Vector3 initPosition;//初期位置
    bool isLiftObj;//オブジェクトを選択しているとわかりやすいように持ち上げるとき

    // Use this for initialization
    void Start () {
        master=GameObject.Find("MasterCube");
        selectMode = master.GetComponent<SelectPlace>();
        cardsDate = GetComponent<CardsDate>();
        cards = master.GetComponent<CollCreate>();
        initPosition = transform.position;
        isLiftObj = false;
    }
	
	// Update is called once per frame
	void Update () {
        MaterialChange();
    }

    //色を変える処理
    void MaterialChange()
    {
        for (int i = 0; i < 64; i++)
        {
            if (cards.Cards[i].myPos == selectMode.player.pNow_pos)
            {
                //駒を置く場所を選んでいるときその場所を赤色にする
                if (cards.Cards[i].select == true)
                {
                    GetComponent<MeshRenderer>().enabled = true;
                    GetComponent<Renderer>().material.color = Color.red;
                    if (isLiftObj == false)
                    {//選択しているオブジェを少し上に浮かす
                        gameObject.transform.position += new Vector3(0, 0.5f, 0);
                        isLiftObj = true;
                    }
                }
                else
                {
                    isLiftObj = false;
                    //浮かしたオブジェを元の位置に戻す
                    gameObject.transform.position = initPosition;

                    //選択していない
                    //カードの状態
                    if (cardsDate.cardPlace == CardsDate.CARDPLACE.HAND_CARD)
                    {//手札にあったら
                        GetComponent<MeshRenderer>().enabled = false;
                    }
                    else if (cardsDate.cardPlace == CardsDate.CARDPLACE.FRONT_CARD)
                    {//表に出ていたら
                        GetComponent<MeshRenderer>().enabled = true;
                    }
                }
            }
        }


        //手札にあるカードは場にないので非表示にする
        if (cardsDate.cardPlace != CardsDate.CARDPLACE.HAND_CARD)
        {
            GetComponent<MeshRenderer>().enabled = true;
        }


        //マテリアルの色を変える
        if (cardsDate.cardPlace == CardsDate.CARDPLACE.FRONT_CARD)
        {
            if (cardsDate.cardType == CardsDate.CARDTYPE.BLACK_CARD)
            {

                GetComponent<Renderer>().material.color = Color.black;

            }
            else if (cardsDate.cardType == CardsDate.CARDTYPE.WHIGHT_CARD)
            {

                GetComponent<Renderer>().material.color = Color.white;

            }
        }
    }
}
