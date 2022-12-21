using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClickManager : MonoBehaviour
{
    Camera cam;

    float maxDistance = 15f;
    Vector3 mousePos;
    int layerMask;

    [SerializeField] GameObject errorObj = null;
    [SerializeField] GameObject okObj = null;

    [SerializeField] Transform singPerent = null;

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

            if (hit)
            {
                if (hit.transform.TryGetComponent<Click_Interactable>(out Click_Interactable obj))
                {
                    Debug.Log("들어간놈 찾았다");
                    if (!hit.transform.GetComponent<Wromg_Image>().check)
                    {
                        Test(okObj, hit.transform.position);
                    }
                    obj.Interact();
                }
                else if(hit.transform.gameObject.name == "BackGround" || hit.transform.gameObject.name == "Image_Center")
                {
                    Debug.Log("그림이 없어요");
                }
                else
                {
                    GameObject test = Test(errorObj, mousePos);
                    Destroy(test, 1f);
                }    

            }
            else
            {
            }
        }
    }

    private GameObject Test(GameObject obj, Vector3 pos)
    {
        GameObject test = Instantiate(obj, singPerent);
        test.transform.position = new Vector3(pos.x, pos.y, 0);

        test.SetActive(true);

        return test;
    }
}
