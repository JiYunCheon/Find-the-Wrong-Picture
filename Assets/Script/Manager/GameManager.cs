using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("=========Get Manager========")]
    [SerializeField] private UIManager uiManager       = null;
    [SerializeField] private ClickManager clickManager = null;
    [SerializeField] private SpawnManager spawnManager = null;
    [SerializeField] private SelectLevel selectLevelManager = null;

    [Header("GameControl Member")]
    [SerializeField] private float maxTime = 0;
    [SerializeField] private int score = 0;
    [SerializeField] private int curScore = 0;
    [SerializeField] private int totalCount = 0;

    public UIManager GetUiManager       { get { return uiManager; }    private set { } }
    public ClickManager GetClickManager { get { return clickManager; } private set { } }
    public SpawnManager GetSpawnManager { get { return spawnManager; } private set { } }
    public int GetScore { get { return score; } private set { } }
    public int GetTotalCount { get { return totalCount; } private set { } }

    #region Members

    public int findCount = 0;

    private bool gameClear = false;
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
        if (!gameClear)
            TimeControl();

        Debug.Log("score : " + score);
    }

    private void Init()
    {
        gameClear = false;
        CurGameTime = 0;
    }

    private void TimeControl()
    {
        CurGameTime += Time.deltaTime;
        GetUiManager.SetTimerText(CurGameTime);

        if (findCount >= 5)
        {
            gameClear = true;
            GameClear_SceneCheng();
        }
    }

    private void GameClear_SceneCheng()
    {
        selectLevelManager.GameClear();
        uiManager.Off_UI();
    }

    private void GameScore()
    {

    }
}
