using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カードを置いた位置から8方向数えてひっくり返すカードを見つける
/// </summary>
public class CountTop : MonoBehaviour
{
    //script
    public ObjList topObjList, downObjList, rightObjList, leftObjList;
    PlayerManager player, lendVariable;
    KeyPut keyPut;
    PutTheCard putTheCard;
    CollCreate cardsPosition;
    Turn turnScript;

    //変数
    public bool isTurnOverStart;

    //8方向のポジション
    //とりあえす４方向
    Vector2 topPos;
    Vector2 downPos;
    Vector2 rightPos;
    Vector2 leftPos;


    //静的定数
    private const int MAX_CARDS = 64; //複製するオブジェクトの最大数
    private const int MAX_COLUMN = 8; //列の最大数
    private const int MAX_LINE = 8;

    // Start is called before the first frame update
    void Start()
    {
        //初期化
        player = GetComponent<PlayerManager>();//プレイヤー情報
        lendVariable = GetComponent<PlayerManager>(); //変数を貸すだけ
        keyPut = GetComponent<KeyPut>();
        putTheCard = GetComponent<PutTheCard>();
        cardsPosition = GetComponent<CollCreate>();
        topObjList = GetComponent<ObjList>();
        downObjList = GetComponent<ObjList>();
        rightObjList = GetComponent<ObjList>();
        leftObjList = GetComponent<ObjList>();


        //変数初期化
        isTurnOverStart = false;

        //ポジションをとる
        //positionNum = playerPosition.myNumber;
        topPos   = lendVariable.Vget(0, 0);
        downPos  = lendVariable.Vget(0, 0);
        rightPos = lendVariable.Vget(0, 0);
        leftPos  = lendVariable.Vget(0, 0);

    }


    // Update is called once per frame
    void Update()
    {
        //毎フレームターン呼び出し
        //毎フレームしないとターンが変わらない
        turnScript = GetComponent<Turn>();


        //関数呼び出し

        //バグ
        //なぜか一個だけしか実装できない
        //右は完全にできない（maxValueの引数の値が違うかも）
        CountAround(topPos,   lendVariable.Vget(0, 1), topObjList);//上
        //CountAround(downPos,  lendVariable.Vget(0,-1), downObjList);//下
        //CountAround(rightPos, lendVariable.Vget(1, 0), rightObjList);//右
        //CountAround(leftPos,  lendVariable.Vget(-1,0), leftObjList);//左
        isTurnOverStart = true;
        //putTheCard.isCountStart = false;
    }

    /// <summary>
    /// 8方向のマスを限界まで数える
    /// </summary>
    /// <param name="positionNum">ポジションのコピー</param>
    /// <param name="numByDirection">その方向に足す値</param>
    /// <param name="obj">オブジェクトの情報を持ってくる</param>
    void CountAround(Vector2 positionNum, Vector2 numByDirection, ObjList obj)
    {
        //各方向にあるマスを数える
        if (putTheCard.isCountStart == true)
        {
            //初期値
            positionNum = player.position.pNow_pos;
            for (int i = 0; i < MAX_COLUMN; i++)
            {
                //方向に合わせた次のマスを見る
                if (positionNum.x + numByDirection.x <= (MAX_COLUMN - 1) && 
                    0 <= positionNum.x + numByDirection.x &&
                    positionNum.y + numByDirection.y <= (MAX_LINE - 1) &&
                    0 <= positionNum.y + numByDirection.y)
                {
                    Debug.Log("aaaaaaaa");
                    positionNum += numByDirection;
                }

                //Listに上の表に置いているオブジェクトを格納する
                for (int j = 0; j < MAX_CARDS; j++)
                {
                    if (cardsPosition.Cards[j].myPos == positionNum)
                    {

                        //オブジェクトの情報を変数に格納する
                        var cardPlace = cardsPosition.Cards[j].data.cardPlace;
                        var cardType = cardsPosition.Cards[j].data.cardType;

                        //黒のターン
                        if (turnScript.blackOrWhit == 1)
                        {
                            if (cardPlace == CardsDate.CARDPLACE.FRONT_CARD &&
                                cardType == CardsDate.CARDTYPE.WHIGHT_CARD)
                            {
                                //オブジェクトを追加する
                                obj.frontObj.Add(cardsPosition.Cards[j].gameobj);
                                //Debug.Log(obj.frontObj[i]);
                            }
                            else
                            {
                                //挟んでないときは追加したオブジェクトを消す
                                if (cardPlace == CardsDate.CARDPLACE.HAND_CARD)
                                {
                                    //Listに追加した値を消す
                                    obj.frontObj.Clear();
                                }
                                //最大値を入れてカウントを強制終了する
                                i = 8;
                                j = MAX_CARDS;
                                break;
                            }
                        }

                        //白のターン
                        if (turnScript.blackOrWhit == 0)
                        {
                            if (cardPlace == CardsDate.CARDPLACE.FRONT_CARD &&
                                cardType == CardsDate.CARDTYPE.BLACK_CARD)
                            {
                                //オブジェクトを追加する
                                obj.frontObj.Add(cardsPosition.Cards[j].gameobj);
                            }
                            else
                            {
                                //挟んでないときは追加したオブジェクトを消す
                                if (cardPlace == CardsDate.CARDPLACE.HAND_CARD)
                                {
                                    //Listに追加した値を消す
                                    obj.frontObj.Clear();
                                }
                                //最大値を入れてカウントを強制終了する
                                i = 8;
                                j = MAX_CARDS;
                                break;
                            }
                        }

                    }
                }
            }
        }
    }
}