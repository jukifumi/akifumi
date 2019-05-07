using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollCreate : MonoBehaviour
{

    [SerializeField]
    float interval;//間隔

    [SerializeField]
    GameObject[] collBox;

    GameObject[] Cards=new GameObject[64];

    //静的定数
    private const int MAX_CARDS = 64;//複製するオブジェクトの最大数

    // Start is called before the first frame update
    void Start()
    {
        //オブジェクトを複製する
        for(var i=0; i < MAX_CARDS; i++)
        {
            Cards[i] = Instantiate(collBox[0]);
            Cards[i].transform.position = new Vector3(-4.3f + (i % 8 * interval), 0, -4.3f + (i / 8 * interval));//盤面のマスに合うように間隔をあける
            Cards[i].GetComponent<MeshRenderer>().enabled = false;//オブジェクトを見えないようにする

            ////スクリプトをアタッチする
            //Cards[i].AddComponent<SelectPlace>();
            //Cards[i].AddComponent<PutTheCard>();
            //Cards[i].AddComponent<IamCard>();
            //Cards[i].AddComponent<TurnOver>();
            //Cards[i].AddComponent<CountTop>();



            ////cardNumberの値を変える
            //Cards[i].GetComponent<IamCard>().cardNumber = i + 1;
        }




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
