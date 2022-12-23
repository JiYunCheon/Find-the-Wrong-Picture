using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //여기로 변수 다모으기 
    [SerializeField] private int mapWidth;
    [SerializeField] private int mapHight;
    [SerializeField] private Transform ResultWindow;
    [SerializeField] private GameObject resultObjet = null;

    [HideInInspector] public List<GameObject> resultObjetList = null;
    [HideInInspector] public int resultCount = 0;

    [SerializeField] private CreatePicture board = null;
    [HideInInspector] public CreatePicture answerBoard = null;
    [HideInInspector] public CreatePicture wrongBoard = null;

    int[] randomIndex;

    void Start()
    {
        GenerateAnswerBoard();

        GenerateWrongBoard();

        GenerateResultObject();
    }

    //정답 보드 생성
    private void GenerateAnswerBoard()
    {
        CreatePicture obj = Instantiate<CreatePicture>(board);
        obj.transform.position = new Vector3(-35.5f, -16f, 0);
        obj.CallChangeType();
        randomIndex = obj.randomIndex;

        answerBoard = obj;
    }

    //문제 보드 생성
    private void GenerateWrongBoard()
    {
        CreatePicture obj = Instantiate<CreatePicture>(board);
        obj.transform.position = new Vector3(35.5f, -16f, 0);
        wrongBoard = obj;

        for (int i = 0; i < answerBoard.check_ImageList.Count; i++)
        {
            wrongBoard.check_ImageList[i].mySpritRenderer.sprite = answerBoard.check_ImageList[i].mySpritRenderer.sprite;
        }

        obj.GenerateWrongObject(randomIndex);
    }


    //결과 오브젝트 생성
    private void GenerateResultObject()
    {
        for (int i = 0; i < mapHight; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                GameObject obj = Instantiate<GameObject>(resultObjet,ResultWindow);
                obj.transform.localPosition =
                    new Vector3((j * 2f) + -3.5f, (i*3f)-6f, 0f);
                
                resultObjetList.Add(obj);
            }
        }
    }
}
