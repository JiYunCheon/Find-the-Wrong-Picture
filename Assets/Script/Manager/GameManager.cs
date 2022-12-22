using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("=========Get Manager========")]
    [SerializeField] private UIManager uiManager       = null;
    [SerializeField] private ClickManager clickManager = null;
    [Header("GameControl Member")]
    [SerializeField] private float maxTime = 0;

    public UIManager GetUiManager       { get { return uiManager; }    private set { } }
    public ClickManager GetClickManager { get { return clickManager; } private set { } }

    #region Members

    private bool TimeOver = false;
    public bool GameClear { get; set; } = false;
    public int Difficulty { get; set; } = 0;
    public int Score      { get; set; } = 0;
    public float CurGameTime { get; set; } = 0;

    #endregion

    private void Start()
    {
        Init();    
    }
    private void Update()
    {
        if (TimeOver) return;

        TimeControl();
    }

    private void TimeControl()
    {
        CurGameTime = Time.time;
        GetUiManager.SetTimerText(CurGameTime);

        if (CurGameTime > maxTime)
        {
            TimeOver = true;
            GetUiManager.CallTimeOverUi();
        }
    }

    private void AddScore()
    {

    }

    void Init()
    {
        TimeOver = false;
        CurGameTime = 0;
    }

 
}
