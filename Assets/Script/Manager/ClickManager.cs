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

    private void Start()
    {
        cam = Camera.main;
        layerMask = 1 << LayerMask.NameToLayer("Interactable");
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
            mousePos = cam.ScreenToWorldPoint(mousePos);

            RaycastHit2D hit = Physics2D.Raycast(mousePos, transform.forward, maxDistance, layerMask);
            Debug.DrawRay(mousePos, transform.forward * 10, Color.red, 0.3f);

            if (hit.collider!=null)
            {
                Debug.Log(hit.transform.name);

                if (hit.transform.TryGetComponent<Click_Interactable>(out Click_Interactable obj))
                {
                    Debug.Log("들어간놈 찾았다");
                    if (!hit.transform.GetComponent<Wromg_Image>().check)
                    {
                        CheckInst(okObj, hit.transform.position);
                    }
                    obj.Interact();
                }
                else if(hit.transform.gameObject.name == "BackGround" || hit.transform.gameObject.name == "Image_Center")
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

    private GameObject CheckInst(GameObject obj, Vector3 pos)
    {
        GameObject test = Instantiate(obj, singPerent);
        test.transform.position = new Vector3(pos.x, pos.y, 0);

        test.SetActive(true);

        return test;
    }
}
