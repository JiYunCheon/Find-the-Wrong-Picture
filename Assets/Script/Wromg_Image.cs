using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wromg_Image : MonoBehaviour, Click_Interactable
{
    public bool background = false;
    public bool check { get; set; }
    int a = 0;

    public void Interact()
    {
        Debug.Log("½ÇÇà");
        check = true;
    }
}
