using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialProcessing : MonoBehaviour {

    //script
    GameObject master;
    SelectPlace selectMode;
    CardsDate cardsDate;
    CollCreate cards;

    //ベクトル
    Vector3 initPosition;//初期位置

    //変数
    int number;//番号
    bool isLiftObj;//オブジェクトを選択しているとわかりやすいように持ち上げて表示するとき

    // Use this for initialization
    void Start ()
    {
        master     = GameObject.Find("MasterCube");
        selectMode = master.GetComponent<SelectPlace>();
        cardsDate  = GetComponent<CardsDate>();
        cards      = master.GetComponent<CollCreate>();

        initPosition = transform.position;
        isLiftObj = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        MaterialChange();
    }

    //色を変える処理
    void MaterialChange()
    {
        GetComponent<MeshRenderer>().enabled = false;

            //駒を置く場所を選んでいるときその場所を赤色にする
            if (cards.Cards[number].select == true)
            {
                GetComponent<MeshRenderer>().enabled = true;//オブジェクトを表示する
                GetComponent<Renderer>().material.color = Color.red;//赤色
                if (isLiftObj == false)
                {//選択しているオブジェをわかりやすいように少し上に浮かす
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

        //手札にあるカードは場にないので非表示にする
        if (cardsDate.cardPlace != CardsDate.CARDPLACE.HAND_CARD)
        {
            GetComponent<MeshRenderer>().enabled = true;//表示する
        }


        //マテリアルの色を変える
        if (cardsDate.cardPlace == CardsDate.CARDPLACE.FRONT_CARD)
        {
            if (cardsDate.cardType == CardsDate.CARDTYPE.BLACK_CARD)
            {
                //黒色
                GetComponent<Renderer>().material.color = Color.black;

            }
            else if (cardsDate.cardType == CardsDate.CARDTYPE.WHIGHT_CARD)
            {
                //白色
                GetComponent<Renderer>().material.color = Color.white;

            }

        }
    }
    //番号を持ってくる
    public void SetNum(int n)
    {
        number = n;
    }
}
