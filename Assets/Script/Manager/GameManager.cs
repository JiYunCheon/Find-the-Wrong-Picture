using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameStart = false;
    float gameTime = 0;
    int difficulty = 0;     // 난이도 설정

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();    
    }

    void Init()
    {
        gameStart = false;
        gameTime = 0;
        difficulty = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
