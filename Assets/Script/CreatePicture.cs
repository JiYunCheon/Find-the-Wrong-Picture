using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using Unity.VisualScripting;
using UnityEngine;

public class CreatePicture : MonoBehaviour
{
    [Header("=====Inst Size=====")]
    [SerializeField] private int mapWidth;
    [SerializeField] private int mapHight;

    [Header("=====Prefab=====")]
    [SerializeField] Wromg_Image defalt_obj = null;

    [Header("=====Object Inst Position=====")]
    [SerializeField] private float objectInertval_X;
    [SerializeField] private float objectInertval_Y;
    [SerializeField] private float objectPivot_X;
    [SerializeField] private float objectPivot_Y;

    [SerializeField] private int ativeObjectCount;
    [SerializeField] private int defaltObjectCount;

    private List<Wromg_Image> wromg_Images;
    [HideInInspector] public int[] randomIndex;

    private void Awake()
    {
        wromg_Images = new List<Wromg_Image>();

        GenerateObject();
    }

    private void GenerateObject()
    {
        for (int i = 0; i < mapHight; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                Wromg_Image obj = Instantiate<Wromg_Image>(defalt_obj,this.transform);
                obj.transform.localPosition = 
                    new Vector3((j* objectInertval_X) + objectPivot_X, (i* objectInertval_Y) +objectPivot_Y,0f);
                wromg_Images.Add(obj);
            }
        }
    }

    public void CallChangeType()
    {
        randomIndex=new int[(mapWidth * mapHight) - ativeObjectCount];

        for (int i = 0; i < (mapWidth* mapHight) - ativeObjectCount; i++)
        {
            int select = Random.Range(0, wromg_Images.Count);
            randomIndex[i] = select;

            //��Ȱ��ȭ �Ǵ� �Լ� ����
            wromg_Images[select].gameObject.SetActive(false);

            wromg_Images.Remove(wromg_Images[select]);
        }

       
    }

    public void GenerateWrongObject(int[] randomIndex)
    {
        for (int i = 0; i < randomIndex.Length; i++)
        {
            wromg_Images[randomIndex[i]].gameObject.SetActive(false);
            wromg_Images.Remove(wromg_Images[randomIndex[i]]);
        }

        int count = wromg_Images.Count;

        for (int i = 0; i < count - defaltObjectCount; i++)
        {
            int select = Random.Range(0, wromg_Images.Count);

            //Ʋ���׸� ��ȯ �Լ� ����
            wromg_Images[select].gameObject.GetComponent<SpriteRenderer>().material.color = Color.red;

            wromg_Images.Remove(wromg_Images[select]);
        }
    }

}