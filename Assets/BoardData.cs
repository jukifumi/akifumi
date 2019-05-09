using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//盤のデータの取得と設定（すべてのカードの配置場所と種類を持っている）
public class BoardData : MonoBehaviour {
    int[,] board;//盤
    //int column;//列
    //int line;//行
    // Use this for initialization
    void Start () {
        board = new int[8, 8];//8x8の盤を作る

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetBoardDate(int column, int line,int cardState)
    {
        board[column, line]=cardState;
    }

    int GetBoardDate(int column,int line)
    {
        return board[column, line];
    }
}
