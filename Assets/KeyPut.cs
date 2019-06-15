using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// キーを押した時の処理
/// </summary>
public class KeyPut : MonoBehaviour
{

    PlayerManager player;
    PutTheCard putTheCard;
    ObjList objList;

    bool isInit;//初期化するときのフラグ

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerManager>();
        putTheCard = GetComponent<PutTheCard>();
        objList = GetComponent<ObjList>();

        isInit = false;
    }

    // Update is called once per frame
    void Update()
    {
        //右キー
        if (Input.GetKeyDown(KeyCode.RightArrow) &&
            player.position.pNow_pos.x < 7
            && putTheCard.isCountStart == false)
        {
            isInit = true;
            player.x++;
            //putTheCard.isCountStart = true;
        }
        //左キー
        if (Input.GetKeyDown(KeyCode.LeftArrow) &&
            player.position.pNow_pos.x > 0
            && putTheCard.isCountStart == false)
        {
            isInit = true;
            player.x--;
            //putTheCard.isCountStart = true;
        }
        //上キー
        if (Input.GetKeyDown(KeyCode.UpArrow) &&
            player.position.pNow_pos.y < 7
            && putTheCard.isCountStart == false)
        {
            isInit = true;
            player.y++;
            //putTheCard.isCountStart = true;
        }
        //下キー
        if (Input.GetKeyDown(KeyCode.DownArrow) &&
            player.position.pNow_pos.y > 0
            && putTheCard.isCountStart == false)
        {
            isInit = true;
            player.y--;
            //putTheCard.isCountStart = true;
        }

        //初期化
        if (isInit == true)
        {
            objList.frontObj.Clear();
            isInit = false;
        }
    }
}
