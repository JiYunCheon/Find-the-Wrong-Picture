using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultBox : MonoBehaviour
{
    [SerializeField] private Sprite[] default_Sprite;

    [HideInInspector] public SpriteRenderer mySpritRenderer = null;
    private int randomIdx = 0;

    void Awake()
    {
        mySpritRenderer = GetComponent<SpriteRenderer>();
        randomIdx = Random.Range(0, default_Sprite.Length);
        mySpritRenderer.sprite = default_Sprite[randomIdx]; 
    }

}
