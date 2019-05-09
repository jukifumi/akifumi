using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlace : MonoBehaviour
{
    //ターン用アタッチするためのオブジェ
    GameObject turnCube;
    Turn turnScript;
    //リスト用アタッチするためのオブジェ
    GameObject listCube;
    ObjList objList;

    IamCard iamCard;
    TurnOver turnOver;
    //変数
    [SerializeField]
    float selectUp, selectDown, selectRight, selectLeft;//選択している場所の周り

    public int selectPosition;//選んでいる場所
    public bool select;//その場所を選択しているかどうか

    bool isPut;//置く

    bool isLiftObj;//オブジェクトを選択しているとわかりやすいように持ち上げるとき
    bool countTop;//選択中の場所の上のマス番号を数える
    bool isInit;//初期化するときのフラグ

    //ベクトル
    Vector3 initPosition;//初期位置


    //静的定数
    private const int MAX_CARDS = 64;//複製するオブジェクトの最大数

    // Start is called before the first frame update
    void Start()
    {
        turnCube = GameObject.Find("turnControl");
        listCube = GameObject.Find("ListCube");
        iamCard = GetComponent<IamCard>();
        objList = listCube.GetComponent<ObjList>();
        turnOver = GetComponent<TurnOver>();

        countTop = false;
        select = false;
        isPut = false;
        isLiftObj = false;
        selectPosition = 0;
        selectUp = 0;
        selectDown = 0;
        selectRight = 0;
        selectLeft = 0;
        initPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        turnScript = turnCube.GetComponent<Turn>();

        MaterialChange();
        SelectState();
        ChooseALocation();
    }

    //色を変える処理
    void MaterialChange()
    {
        //駒を置く場所を選んでいるときその場所を赤色にする
        if (select == true)
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
        }

        //マテリアルの色を変える
        if (iamCard.cardPlace == IamCard.CARDPLACE.FRONT_CARD)
        {
            if (iamCard.cardType == IamCard.CARDTYPE.BLACK_CARD)
            {
                if (select == false)
                {//黒
                    GetComponent<Renderer>().material.color = Color.black;
                }
            }
            else if (iamCard.cardType == IamCard.CARDTYPE.WHIGHT_CARD)
            {
                if (select == false)
                {//白
                    GetComponent<Renderer>().material.color = Color.white;
                }
            }
        }
    }

    //選択状態を切り替える
    void SelectState()
    {
        if (iamCard.cardNumber == selectPosition)
        {//選択している
            select = true;
        }
        else
        {//選択していない
            //カードの状態
            if (iamCard.cardPlace == IamCard.CARDPLACE.HAND_CARD)
            {//手札にあったら
                GetComponent<MeshRenderer>().enabled = false;
            }
            else if (iamCard.cardPlace == IamCard.CARDPLACE.FRONT_CARD)
            {//表に出ていたら
                GetComponent<MeshRenderer>().enabled = true;
            }
            select = false;
        }
    }



    //場所を選択する処理
    void ChooseALocation()
    {
        //置く場所を選ぶ
        //右キー
        if (Input.GetKeyDown(KeyCode.RightArrow) &&
            selectPosition < MAX_CARDS)
        {
            isInit = true;
            selectPosition++;
            LookAround();
        }
        //左キー
        if (Input.GetKeyDown(KeyCode.LeftArrow) &&
            selectPosition > 1)
        {
            isInit = true;
            selectPosition--;
            LookAround();
        }
        //上キー
        if (Input.GetKeyDown(KeyCode.UpArrow) &&
            selectPosition + 8 <= MAX_CARDS)
        {
            isInit = true;
            selectPosition += 8;
            LookAround();
        }
        //下キー
        if (Input.GetKeyDown(KeyCode.DownArrow) &&
            selectPosition - 8 >= 0)
        {
            isInit = true;
            selectPosition -= 8;
            LookAround();
        }

        //初期化
        if(isInit == true)
        {
            turnOver.isListAdd = false;
            countTop = false;
            objList.upFrontObj.Clear();
            objList.floatObj.Clear();
            isInit = false;
        }

    }

    //選択している箇所の周りを確認する
    void LookAround()
    {
        //選んでいる位置の上下左右の値を代入する
        selectUp = selectPosition + 8;
        selectDown = selectPosition - 8;
        selectRight = selectPosition + 1;
        selectLeft = selectPosition - 1;
    }
}
