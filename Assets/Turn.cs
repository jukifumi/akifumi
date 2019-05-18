using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/////////////////////////////////////////////////////
//ターンの切り替え処理
//どのプレイヤーのターンなのかのUIの切り替え表示
////////////////////////////////////////////////////
public class Turn : MonoBehaviour
{
    [SerializeField]
    GameObject Even, Odd;//奇数、偶数

    //変数
    public float turn;//ターン数

    public float blackOrWhit;
    bool changeColor;


    // Use this for initialization
    void Start()
    {//初期化

        turn = 1;
        changeColor = false;


        blackOrWhit = Mathf.Floor(Random.Range(0.0f, 1.9f));//黒か白かランダムで決める
    }

    // Update is called once per frame
    void Update()
    {

        //UI切り替え処理
        if (turn % 2 == 0)
        {
            Odd.gameObject.SetActive(false);
            Even.gameObject.SetActive(true);
        }
        else
        {
            Even.gameObject.SetActive(false);
            Odd.gameObject.SetActive(true);
        }

        //ターン切り替え処理
        if (Input.GetKeyDown(KeyCode.A) == true || Input.GetKeyDown(KeyCode.S) == true || Input.GetKeyDown(KeyCode.D) == true)
        {
            changeColor = false;
            turn++;


            //最初に黒側か白側をランダムで決める
            if (blackOrWhit == 0 && changeColor == false)
            {
                blackOrWhit = 1;
                changeColor = true;
            }

            if (blackOrWhit == 1 && changeColor == false)
            {
                blackOrWhit = 0;
                changeColor = true;
            }
        }
    }
}
