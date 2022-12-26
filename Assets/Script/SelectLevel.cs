using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{

    public void Click_Easy()
    {
        //Debug.Log("Easy");
        //GameDatas.Inst.difficulty = DIFFICULTY.EASY;
        //SceneManager.LoadScene("2.GameScene");
    }

    public void Click_Normal()
    {
        Debug.Log("Normal");
        SceneManager.LoadScene("Find_the_Wrong_Picture _1");
    }

    public void Click_Hard()
    {
        //Debug.Log("Hard");
        //GameDatas.Inst.difficulty = DIFFICULTY.HARD;
        //SceneManager.LoadScene("2.GameScene");
    }

    public void Click_Master()
    {
        //Debug.Log("Master");
        //GameDatas.Inst.difficulty = DIFFICULTY.MASTER;
        //SceneManager.LoadScene("2.GameScene");
    }

    public void GameClear()
    {
        SceneManager.LoadScene("3.EndScenes", LoadSceneMode.Additive);
    }
}
