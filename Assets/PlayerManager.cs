using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// プレイヤーの情報
/// </summary>
public class PlayerManager : MonoBehaviour
{

    //プレイヤーに二次元のポジションを持たせる
    public struct Position
    {
        public Vector2 pNow_pos;
    }

    //二次元
    public Vector2 Vget(int x, int y)
    {
        Vector2 vector;
        vector.x = x;
        vector.y = y;
        return vector;
    }

    //構造体の定義
    public Position position;

    public int x;
    public int y;


    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        y = 0;

        //プレイヤーのポジション
        position.pNow_pos = Vget(x, y);
    }

    // Update is called once per frame
    void Update()
    {
        //自分の選んでいる場所を決める
        position.pNow_pos = Vget(x, y);
        //Debug.Log(position.pNow_pos);
    }
}
