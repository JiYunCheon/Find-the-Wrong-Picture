using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wromg_Image : MonoBehaviour, Click_Interactable
{
    public bool check { get; set; }
    private bool background = false;

    SpriteRenderer sp = null;
    [SerializeField] private Sprite[] default_Sprite;
    [SerializeField] private Sprite[] wromg_Sprite;

    int randomIdx = 0;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        randomIdx = Random.Range(0, default_Sprite.Length);
        Init();
    }

    private void Init()
    {
        sp.sprite = default_Sprite[randomIdx];
    }

    public void Interact()
    {
        Debug.Log("½ÇÇà");
        check = true;
    }

    public void On_Change_Image()
    {
        randomIdx = Random.Range(0, wromg_Sprite.Length);
        sp.sprite = wromg_Sprite[randomIdx];
        this.gameObject.layer = 9;
    }

    public void Off_Image()
    {
        this.gameObject.SetActive(false);
    }
}
