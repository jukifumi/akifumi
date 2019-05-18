using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///////////////////////////////////////////////////////
//置く場所を選ぶ処理
//選んだ場所の周りのマスの番号をとる処理
//カードの色を変える処理
//////////////////////////////////////////////////////////
public class SelectPlace : MonoBehaviour
{
    //script
    Turn turnScript;
    ObjList objList;
    CardsDate cardsDate;
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
        cardsDate = GetComponent<CardsDate>();
        objList = GetComponent<ObjList>();
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
        turnScript = GetComponent<Turn>();

        SelectState();
        ChooseALocation();
    }

    //選択状態を切り替える
    void SelectState()
    {
        if (cardsDate.cardNumber == selectPosition)
        {//選択している
            select = true;
        }
        else
        {//選択していない
            //カードの状態
            if (cardsDate.cardPlace == CardsDate.CARDPLACE.HAND_CARD)
            {//手札にあったら
                GetComponent<MeshRenderer>().enabled = false;
            }
            else if (cardsDate.cardPlace == CardsDate.CARDPLACE.FRONT_CARD)
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
