using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour {
    public float turn;//ターン数
    float time;
    public bool onePush;//

    public float blackOrWhit;
    bool changeColor;

    [SerializeField]
    GameObject Even, Odd;//奇数、偶数
    // Use this for initialization
    void Start()
    {//初期化
        time = 0;
        turn = 1;
        onePush = false;
        changeColor = false;
        blackOrWhit = Mathf.Floor(Random.Range(0.0f, 1.9f));//黒か白かランダムで決める
    }

    // Update is called once per frame
    void Update()
    {
       if(turn%2==0)
        {
            Odd.gameObject.SetActive(false);
            Even.gameObject.SetActive(true);
        }
        else
        {
            Even.gameObject.SetActive(false);
            Odd.gameObject.SetActive(true);
        }
        Debug.Log(blackOrWhit);
        if (Input.GetKeyDown(KeyCode.A)==true || Input.GetKeyDown(KeyCode.S) == true || Input.GetKeyDown(KeyCode.D) == true)
        {
            changeColor = false;
            turn++;

            if(blackOrWhit==0&& changeColor==false)
            {
                blackOrWhit = 1;
                changeColor = true;
            }
            if(blackOrWhit==1 && changeColor == false)
            {
                blackOrWhit = 0;
                changeColor = true;
            }
            //}
             //changeColor = true;
        }

    }
    private void FixedUpdate()
    {
        
        
    }
}
