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
    //オブジェクト
    [SerializeField]
    GameObject[] collBox;

    //スクリプト
    BoardData cardPosition;
    CardsDate cardsDate;
    PutTheCard putTheCard;

    public Card[] Cards = new Card[64];

    //変数
    [SerializeField]
    float interval;//間隔
    int number = 0;
    int col = 0;
    int row = 0;

    //静的定数
    private const int MAX_CARDS = 64;//複製するオブジェクトの最大数
    private const float SIDE_OBJECT = -4.3f;
    private const int MAX_SPUARES = 8;

    //構造体の定義
    public struct Card
    {
        public GameObject gameobj;
        public Vector2 myPos;//そのカードのポジション
        public bool select;
        public CardsDate data;  // そのカードのデータ
    }

    //二次元
    //ポジションを取得するために使う
    Vector2 Vget(int x, int y)
    {
        Vector2 vector;
        vector.x = x;
        vector.y = y;
        return vector;
    }

    // Start is called before the first frame update
    void Start()
    {
        putTheCard = GetComponent<PutTheCard>();

        //オブジェクトを複製する
        for (int i = 0; i < MAX_CARDS; i++)
        {
            Cards[i].gameobj = Instantiate(collBox[0]); //複製
            Cards[i].gameobj.transform.position = new Vector3(SIDE_OBJECT + (i % MAX_SPUARES * interval), 0, SIDE_OBJECT + (i / MAX_SPUARES * interval));//盤面のマスに合うように間隔をあける
            Cards[i].gameobj.GetComponent<MeshRenderer>().enabled = false;  //オブジェクトを見えないようにする
            Cards[i].gameobj.AddComponent<CardsDate>();                     //カードにCardsDateのスクリプトをアタッチする
            Cards[i].gameobj.AddComponent<MaterialProcessing>();            //カードにMaterialProcessingのスクリプトをアタッチする
            Cards[i].myPos = Vget(row, col);                              //カードにポジションを与える
            Cards[i].select = false;

            Cards[i].data = Cards[i].gameobj.GetComponent<CardsDate>();


            //番号をとる
            Cards[i].gameobj.GetComponent<MaterialProcessing>().SetNum(i);
            putTheCard.SetNum(i);


            //与えるためのポジションを決める
            row++;
            if (row >= 8)
            {
                row = 0;
                col++;
            }


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

            Cards[i].gameobj.GetComponent<CardsDate>().cardType = cardType;
            Cards[i].gameobj.GetComponent<CardsDate>().cardPlace = cardPlace;

        }
    }
    // Update is called once per frame
    void Update()
    {
        //特になし
    }
}
