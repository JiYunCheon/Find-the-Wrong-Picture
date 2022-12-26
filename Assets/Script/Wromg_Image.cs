using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    OnOcean,
    Default
}

[RequireComponent(typeof(BoxCollider2D))]
public class Wromg_Image : MonoBehaviour, Click_Interactable
{
    [Header("========Sprite Box========")]
    [SerializeField] private Sprite[] default_Sprite;
    [SerializeField] private Sprite[] wromg_Sprite;
    [SerializeField] private Sprite onOcean = null;

    [HideInInspector] public SpriteRenderer mySpritRenderer = null;

    public bool check { get; set; }
    private int randomIdx = 0;
    public Type type = Type.Default;

    [HideInInspector] public CreatePicture answerPiture = null;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        mySpritRenderer = GetComponent<SpriteRenderer>();
        randomIdx = Random.Range(0, default_Sprite.Length);
        mySpritRenderer.sprite = default_Sprite[randomIdx];
    }

    public void ChangeOnOcean()
    {
        mySpritRenderer.sprite = onOcean;
    }

    public void Interact()
    {
        ComparePicture(this);
    }

    public void On_Change_Image()
    {

        randomIdx = Random.Range(0, wromg_Sprite.Length);
        mySpritRenderer.sprite = wromg_Sprite[randomIdx];

        this.gameObject.layer = 9;
    }

    public void Off_Image()
    {
        this.gameObject.SetActive(false);
    }

    private void ComparePicture(Wromg_Image obj)
    {
        if (check) return;

        for (int i = 0; i < GameManager.Inst.GetSpawnManager.wrongBoard.check_ImageList.Count; i++)
        {
            if (GameManager.Inst.GetSpawnManager.wrongBoard.check_ImageList[i] == obj)
            {
                if(GameManager.Inst.GetSpawnManager.answerBoard.check_ImageList[i].mySpritRenderer.sprite.name !=
                    obj.mySpritRenderer.sprite.name)
                {
                    Debug.Log("고래 뱃속으로");
                    FindWrongObject();
                }
            }
        }
    }

    private void MoveResult()
    {
        if (GameManager.Inst.GetSpawnManager.resultCount > GameManager.Inst.GetSpawnManager.resultObjetList.Count)
            return;

        SpriteRenderer sprite = null;

        if (GameManager.Inst.GetSpawnManager.resultObjetList[GameManager.Inst.GetSpawnManager.resultCount]
            .TryGetComponent<SpriteRenderer>(out sprite))
        {
            sprite.sprite= mySpritRenderer.sprite;
            GameManager.Inst.GetSpawnManager.resultCount++;
            check = true;

            GameManager.Inst.Score_UpDate(); ;
            GameManager.Inst.GetUiManager.CallAddFindCount();
        }
    }

    private void FindWrongObject()
    {
        if (GameManager.Inst.GetSpawnManager.resultCount > GameManager.Inst.GetSpawnManager.resultObjetList.Count)
            return;

        SpriteRenderer sprite = null;

        if (GameManager.Inst.GetSpawnManager.resultObjetList[GameManager.Inst.GetSpawnManager.resultCount]
            .TryGetComponent<SpriteRenderer>(out sprite))
        {
            sprite.sprite = null;
            GameManager.Inst.GetSpawnManager.resultCount++;
            check = true;
            GameManager.Inst.Score_UpDate(); ;

            //GameManager.Inst.GetUiManager.CallAddScore(GameManager.Inst.GetScore);
            GameManager.Inst.GetUiManager.CallAddFindCount();
        }
    }




}
