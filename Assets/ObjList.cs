using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjList : MonoBehaviour
{
    public List<GameObject> upFrontObj = new List<GameObject>();
    public List<float> floatObj = new List<float>();
    public bool isEnd;
    // Start is called before the first frame update
    void Start()
    {
        isEnd = false;
        upFrontObj.Clear();
        floatObj.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
