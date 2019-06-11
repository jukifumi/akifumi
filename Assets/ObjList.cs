using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjList : MonoBehaviour
{
    //List
    public List<GameObject> frontObj = new List<GameObject>();
    //public List<float> floatCount = new List<float>();

    //変数
    public bool isEnd;

    // Start is called before the first frame update
    void Start()
    {
        //初期化
        isEnd = false;
        frontObj.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        //特になし
    }
}
