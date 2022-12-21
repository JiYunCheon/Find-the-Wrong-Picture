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
    [SerializeField] Transform can = null;

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
                    obj.Interact();
                }
            }
            else
            {
                GameObject test = Test(errorObj, mousePos);
                Destroy(test, 1f);
            }
        }
    }

    private GameObject Test(GameObject obj, Vector3 _mousePos)
    {
        GameObject test = Instantiate(obj, can);
        //test.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        test.transform.position = cam.WorldToScreenPoint(mousePos);

        test.SetActive(true);

        return test;
    }
}
