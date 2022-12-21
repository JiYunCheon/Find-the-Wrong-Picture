using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour, Click_Interactable
{
    bool chack = false;

    [SerializeField] Transform can = null;
    [SerializeField] GameObject okObj = null;
    GameObject ok = null;

    private void Awake()
    {
        ok = Instantiate(okObj, can);
        ok.SetActive(false);
    }

    public void Interact()
    {
        if (!chack)
        {
            ok.transform.position = this.transform.position;
            ok.SetActive(true);

            Debug.Log("asdfasdfasfd");
            chack = true;
        }
    }
}
