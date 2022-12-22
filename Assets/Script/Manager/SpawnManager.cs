using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //����� ���� �ٸ����� 
    [SerializeField] private int mapWidth;
    [SerializeField] private int mapHight;
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

    //���� ���� ����
    private void GenerateAnswerBoard()
    {
        CreatePicture obj = Instantiate<CreatePicture>(board);
        obj.transform.position = new Vector3(-1.05f, -0.5f, 1);
        obj.CallChangeType();
        randomIndex = obj.randomIndex;

        answerBoard = obj;
    }

    //���� ���� ����
    private void GenerateWrongBoard()
    {
        CreatePicture obj = Instantiate<CreatePicture>(board);
        obj.transform.position = new Vector3(1.05f, -0.5f, 1);
        obj.GenerateWrongObject(randomIndex);

        wrongBoard = obj;
    }

    //��� ������Ʈ ����
    private void GenerateResultObject()
    {
        for (int i = 0; i < mapHight; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                GameObject obj = Instantiate<GameObject>(resultObjet, new Vector3(0,0.62f,0),Quaternion.identity);
                obj.transform.localPosition =
                    new Vector3((j * 0.5f) + -0.75f, (i * 0.3f) + 0.4f, 0f);

                resultObjetList.Add(obj);
            }
        }
    }
}
