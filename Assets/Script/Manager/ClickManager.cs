using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClickManager : MonoBehaviour
{
    [Header("=====Prefab=====")]
    [SerializeField] private GameObject errorObj = null;
    [SerializeField] private GameObject okObj = null;
    [Header("=====Parent=====")]
    [SerializeField] private Transform singPerent = null;

    private Camera cam;
    private float maxDistance = 15f;
    private Vector3 mousePos;
    private int layerMask;

    private float click_Time = 0f;

    private void Start()
    {
        maxDistance=float.MaxValue;
        cam = Camera.main;
        layerMask = 1 << LayerMask.NameToLayer("Interactable");
        click_Time = 10f;
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                if (touch.phase == TouchPhase.Began)
                {
                    SoundManager.Inst.PlaySFX("ClickSound");

                    mousePos = cam.ScreenToWorldPoint(touch.position);

                    RaycastHit2D[] hit = new RaycastHit2D[10];

                    hit[i] = Physics2D.Raycast(mousePos, transform.forward, maxDistance, layerMask);
                    Debug.DrawRay(mousePos, transform.forward * 10, Color.red, 0.3f);

                    if (hit[i].collider!=null)
                    {
                        Debug.Log(hit[i].transform.name);

                        if (hit[i].transform.TryGetComponent<Click_Interactable>(out Click_Interactable obj))
                        {
                            Debug.Log("들어간놈 찾았다");
                            if (!hit[i].transform.GetComponent<Wromg_Image>().check)
                            {
                                Debug.Log("transform : " + hit[i].transform.position);
                                CheckInst(okObj, hit[i].transform.position);
                            }
                            obj.Interact();
                        }
                        else if (hit[i].transform.gameObject.name == "BackGround" || hit[i].transform.gameObject.name == "Image_Center")
                        {
                            Debug.Log("그림이 없어요");
                        }
                        else
                        {
                            GameObject test = CheckInst(errorObj, mousePos);
                            Destroy(test, 1f);
                        }    
                    }
                }
            }
        }


    }

    private GameObject CheckInst(GameObject obj, Vector3 pos)
    {
        GameObject test = Instantiate(obj, singPerent);
        test.transform.position = new Vector3(pos.x, pos.y, 0);

        test.SetActive(true);

        return test;
    }
}
