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

    public Carb[] Cards=new Carb[64];

    //変数
    [SerializeField]
    float interval;//間隔
    int number = 0;
    int col=0;
    int row=0;

    //静的定数
    private const int MAX_CARDS = 64;//複製するオブジェクトの最大数

    //
    public struct Carb
    {
        public GameObject gameobj;
        public Vector2 myPos;//そのカードのポジション
        public bool select;

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
        cardsDate = GetComponent<CardsDate>();

        //オブジェクトを複製する
        for (int i = 0; i < MAX_CARDS; i++)
        {
            Cards[i].gameobj = Instantiate(collBox[0]); //複製
            Cards[i].gameobj.transform.position = new Vector3(-4.3f + (i % 8 * interval), 0, -4.3f + (i / 8 * interval));//盤面のマスに合うように間隔をあける
            Cards[i].gameobj.GetComponent<MeshRenderer>().enabled = false;  //オブジェクトを見えないようにする
            Cards[i].gameobj.AddComponent<CardsDate>();                     //カードにCardsDateのスクリプトをアタッチする
            Cards[i].gameobj.AddComponent<MaterialProcessing>();            //カードにMaterialProcessingのスクリプトをアタッチする
            Cards[i].gameobj.AddComponent<PutTheCard>();
            Cards[i].myPos = Vget(row, col);                              //カードにポジションを与える
            Cards[i].select = false;

            //
            Cards[i].gameobj.GetComponent<MaterialProcessing>().SetNum(i);

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
        //
    }
}
