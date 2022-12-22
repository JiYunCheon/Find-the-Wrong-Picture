using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private CreatePicture board = null;

    int[] randomIndex;

    void Start()
    {
        GenerateAnswerBoard();
        GenerateWrongBoard();
    }

    private void GenerateAnswerBoard()
    {
        CreatePicture obj = Instantiate<CreatePicture>(board);
        obj.transform.position = new Vector3(-1.05f, -0.5f, 1);
        obj.CallChangeType();
        randomIndex = obj.randomIndex;

    }

    private void GenerateWrongBoard()
    {
        CreatePicture obj = Instantiate<CreatePicture>(board);
        obj.transform.position = new Vector3(1.05f, -0.5f, 1);
        obj.GenerateWrongObject(randomIndex);
    }

}
