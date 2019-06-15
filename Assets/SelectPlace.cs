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
    PlayerManager player;
    CollCreate cardsPosition;

    //変数

    bool isPut;//置く
    public bool isCountInit;//数えている周りのマス目を初期化するフラグ


    //静的定数
    private const int MAX_CARDS = 64;//複製するオブジェクトの最大数

    // Start is called before the first frame update
    void Start()
    {
        //初期化
        player = GetComponent<PlayerManager>();
        cardsPosition = GetComponent<CollCreate>();

        //変数初期化
        isCountInit = true ;
        isPut = false;

    }

    // Update is called once per frame
    void Update()
    {

        //関数読み込み
        SelectState();

    }

    //選択状態を切り替える
    void SelectState()
    {
        //自分が選択している場所と同じ場所にあるオブジェクトを選択している状態にする
        for (int i = 0; i < MAX_CARDS; i++)
        {
            if (player.position.pNow_pos == cardsPosition.Cards[i].myPos)
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

}
