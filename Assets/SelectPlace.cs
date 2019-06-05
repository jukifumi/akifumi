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
    CollCreate cardsPosition;
    ObjList    objList;
    Turn       turnScript;

    //変数

    int x;
    int y;
    public int myNumber;

    bool isPut;//置く
    bool isInit;//初期化するときのフラグ
    public bool isCountInit;//数えている周りのマス目を初期化するフラグ

    //構造体の定義
    public Player player ;

    //プレイヤーに二次元のポジションを持たせる
    public struct Player
    {
        public Vector2 pNow_pos;
    }

    //二次元
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
    {
        //初期化
        cardsPosition = GetComponent<CollCreate>();
        objList       = GetComponent<ObjList>();

        //変数初期化
        isCountInit = true ;
        isPut = false;

        x = 0;
        y = 0;
        myNumber = 0;
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
    {
        //自分が選択している場所と同じ場所にあるオブジェクトを選択している状態にする
        for (int i = 0; i < MAX_CARDS; i++)
        {
            if (i==myNumber)
            {
                //選択している
                cardsPosition.Cards[i].select = true;
            }
            else
            {
                //選択していない
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
            isCountInit = true;
        }
        //左キー
        if (Input.GetKeyDown(KeyCode.LeftArrow) &&
            player.pNow_pos.x > 0)
        {
            isInit = true;
            x--;
            isCountInit = true;
        }
        //上キー
        if (Input.GetKeyDown(KeyCode.UpArrow) &&
            player.pNow_pos.y <7)
        {
            isInit = true;
            y++;
            isCountInit = true;
        }
        //下キー
        if (Input.GetKeyDown(KeyCode.DownArrow) &&
            player.pNow_pos.y > 0)
        {
            isInit = true;
            y--;
            isCountInit = true;
        }

        //初期化
        if(isInit == true)
        {
            objList.upFrontObj.Clear();
            objList.floatObj.Clear();
            isInit = false;
        }

        //番号をとる
        myNumber = MyNum(x, y);
        //Debug.Log(myNumber);
    }

    //番号をとる
    int MyNum(int xNum, int yNum)
    {
        int num = 0;

        num = (yNum * 8) + xNum;

        return num;
    }
}
