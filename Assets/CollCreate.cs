using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////////////////////
//盤上に存在するためのカードを全部複製する
//複製したカードをマス目に合うように幅を空けて配置する
//複製したカードに初期情報を入れる
////////////////////////////////////////////////////
public class CollCreate : MonoBehaviour
{

    [SerializeField]
    float interval;//間隔

    [SerializeField]
    GameObject[] collBox;

    GameObject[] Cards=new GameObject[64];

    CardsDate cardsDate;

    //静的定数
    private const int MAX_CARDS = 64;//複製するオブジェクトの最大数

    // Start is called before the first frame update
    void Start()
    {
        cardsDate = GetComponent<CardsDate>();
        //オブジェクトを複製する
        for(var i=0; i < MAX_CARDS; i++)
        {
            Cards[i] = Instantiate(collBox[0]);
            Cards[i].transform.position = new Vector3(-4.3f + (i % 8 * interval), 0, -4.3f + (i / 8 * interval));//盤面のマスに合うように間隔をあける
            Cards[i].GetComponent<MeshRenderer>().enabled = false;//オブジェクトを見えないようにする
            Cards[i].AddComponent<CardsDate>();
            
            //複製したオブジェクトに初期情報を入れる
            var cardType = CardsDate.CARDTYPE.WHIGHT_CARD;
            var cardPlace = CardsDate.CARDPLACE.HAND_CARD;

            if (i == 27)
            {
                cardType = CardsDate.CARDTYPE.WHIGHT_CARD;
                cardPlace = CardsDate.CARDPLACE.FRONT_CARD;
            }
            if (i == 28)
            {
                cardType = CardsDate.CARDTYPE.BLACK_CARD;
                cardPlace = CardsDate.CARDPLACE.FRONT_CARD;
            }
            if (i == 35)
            {
                cardType = CardsDate.CARDTYPE.BLACK_CARD;
                cardPlace = CardsDate.CARDPLACE.FRONT_CARD;
            }
            if (i == 36)
            {
                cardType = CardsDate.CARDTYPE.WHIGHT_CARD;
                cardPlace = CardsDate.CARDPLACE.FRONT_CARD;
            }

            Cards[i].GetComponent<CardsDate>().cardType = cardType;
            Cards[i].GetComponent<CardsDate>().cardPlace = cardPlace;
            //もしかしたら使うかも
            ////cardNumberの値を変える
            //Cards[i].GetComponent<IamCard>().cardNumber = i + 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
