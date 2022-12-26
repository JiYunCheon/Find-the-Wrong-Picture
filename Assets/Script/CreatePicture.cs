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
    [HideInInspector] public List<Wromg_Image> check_ImageList;

    [HideInInspector] public int[] randomIndex;

    Wromg_Image onOceanObject = null;

    private void Awake()
    {
        wromg_Images = new List<Wromg_Image>();

        GenerateObject();
    }

    private void GenerateObject()
    {
        Wromg_Image obj = null;

        for (int i = 0; i < mapHight; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                obj = Instantiate<Wromg_Image>(defalt_obj,this.transform);
                obj.transform.localPosition = 
                    new Vector3((j* objectInertval_X) + objectPivot_X, (i* objectInertval_Y) +objectPivot_Y,-1f);

                wromg_Images.Add(obj);

                check_ImageList.Add(obj);
            }
        }

        onOceanObject = Instantiate<Wromg_Image>(defalt_obj, this.transform);
        onOceanObject.name = "wawe";
        onOceanObject.transform.localPosition =
                    new Vector3(-2f, -2.5f, -1f);
        onOceanObject.ChangeOnOcean();
        check_ImageList.Add(onOceanObject);
    }

    public void CallChangeType()
    {
        randomIndex=new int[(mapWidth * mapHight) - ativeObjectCount];

        for (int i = 0; i < (mapWidth* mapHight) - ativeObjectCount; i++)
        {
            int select = Random.Range(0, wromg_Images.Count);
            randomIndex[i] = select;

            //비활성화 되는 함수 실행
            wromg_Images[select].Off_Image();

            wromg_Images.Remove(wromg_Images[select]);
        }
    }

    public void GenerateWrongObject(int[] randomIndex)
    {
        for (int i = 0; i < randomIndex.Length; i++)
        {
            wromg_Images[randomIndex[i]].Off_Image();
            wromg_Images.Remove(wromg_Images[randomIndex[i]]);
        }

        int count = wromg_Images.Count;

        for (int i = 0; i < count - defaltObjectCount; i++)
        {
            int select = Random.Range(0, wromg_Images.Count);

            //틀린그림 변환 함수 실행
            wromg_Images[select].On_Change_Image();

            wromg_Images.Remove(wromg_Images[select]);
        }
        onOceanObject.On_Change_Image();

    }

}
