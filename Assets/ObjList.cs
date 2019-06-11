using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjList : MonoBehaviour
{
    //List
    public List<GameObject> upFrontObj = new List<GameObject>();
    public List<GameObject> downFrontObj = new List<GameObject>();
    public List<GameObject> rightFrontObj = new List<GameObject>();
    public List<GameObject> leftFrontObj = new List<GameObject>();
    public List<int> upCountInt = new List<int>();
    public List<int> downCountInt = new List<int>();
    public List<int> rightCountInt = new List<int>();
    public List<int> leftCountInt = new List<int>();
    //public List<int> floatObj = new List<int>();

    //変数
    public bool isEnd;

    // Start is called before the first frame update
    void Start()
    {
        //初期化
        isEnd = false;
        upFrontObj.Clear();
        downFrontObj.Clear();
        rightFrontObj.Clear();
        leftFrontObj.Clear();
        upCountInt.Clear();
        downCountInt.Clear();
        rightCountInt.Clear();
        leftCountInt.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        //特になし
    }
}
