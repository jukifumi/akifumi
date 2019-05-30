﻿using System.Collections;
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
    CollCreate cardsPosition;

    //変数
    [SerializeField]
    float selectUp, selectDown, selectRight, selectLeft;//選択している場所の周り

    int x;
    int y;
    public int myNumber;

    bool isPut;//置く
    bool countTop;//選択中の場所の上のマス番号を数える
    bool isInit;//初期化するときのフラグ
    public bool countInit;

    //構造体の定義
    public Player player ;

    //プレイヤーに二次元のポジションを持たせる
    public struct Player
    {
        public Vector2 pNow_pos;
    }


    Vector2 Vget(int x, int y)
    {
        Vector2 vector;
        vector.x = x;
        vector.y = y;
        return vector;
    }


//静的定数
private const int MAX_CARDS = 64;//複製するオブジェクトの最大数

    // Start is called before the first frame update
    void Start()
    {//初期化
        cardsDate     = GetComponent<CardsDate>();
        objList       = GetComponent<ObjList>();
        turnOver      = GetComponent<TurnOver>();
        cardsPosition = GetComponent<CollCreate>();

        //変数初期化
        countTop = false;
        countInit = true ;
        isPut = false;
        x = 0;
        y = 0;
        myNumber = 0;
        selectUp = 0;
        selectDown = 0;
        selectRight = 0;
        selectLeft = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //ターンスクリプトコンポーネント
        turnScript = GetComponent<Turn>();

        //関数読み込み
        SelectState();
        ChooseALocation();

        //自分の選んでいる場所を決める
        player.pNow_pos = Vget(x, y);

    }

    //選択状態を切り替える
    void SelectState()
    {//自分が選択している場所と同じ場所にあるオブジェクトを選択している状態にする
        for (int i = 0; i < MAX_CARDS; i++)
        {
            if (i==myNumber)
            {//選択している
                cardsPosition.Cards[i].select = true;
            }
            else
            {//選択していない
                cardsPosition.Cards[i].select = false;
            }
        }
    }

    //場所を選択する処理
    void ChooseALocation()
    {
        //置く場所を選ぶ
        //右キー
        if (Input.GetKeyDown(KeyCode.RightArrow) &&
            player.pNow_pos.x < 7 )
        {
            isInit = true;
            x++;
            countInit = true;
        }
        //左キー
        if (Input.GetKeyDown(KeyCode.LeftArrow) &&
            player.pNow_pos.x > 0)
        {
            isInit = true;
            x--;
            countInit = true;
        }
        //上キー
        if (Input.GetKeyDown(KeyCode.UpArrow) &&
            player.pNow_pos.y <7)
        {
            isInit = true;
            y++;
            countInit = true;
        }
        //下キー
        if (Input.GetKeyDown(KeyCode.DownArrow) &&
            player.pNow_pos.y > 0)
        {
            isInit = true;
            y--;
            countInit = true;
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

        //番号をとる
        myNumber = MyNum(x, y);
        //Debug.Log(myNumber);
    }
    int MyNum(int xNum, int yNum)
    {
        int num = 0;

        num = xNum + yNum * 8;

        return num;
    }
}
