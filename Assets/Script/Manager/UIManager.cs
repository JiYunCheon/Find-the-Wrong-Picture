using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("========Ui Box========")]
    [SerializeField] private GameObject gameOverUi = null;
    [Header("")]
    [SerializeField] private TextMeshProUGUI timerText = null;
    [SerializeField] private TextMeshProUGUI scoreText = null;
    [SerializeField] private TextMeshProUGUI findCountText = null;

    public TextMeshProUGUI GetScoreText { get { return scoreText; } private set { } }

    public GameObject GameOverUi { get { return gameOverUi; } private set { } }

    private int curScore = 0;
    private int findCount = 0;

    public void SetTimerText(float curTime)
    {
        timerText.text = Mathf.RoundToInt(curTime).ToString();
    }

    public void CallTimeOverUi(bool active = true)
    {
        GameOverUi.SetActive(active);
    }

    public void CallAddScore(int score)
    {
        curScore += score;

        GetScoreText.text = curScore.ToString();
    }

    public void CallAddFindCount()
    {
        findCount++;
        GameManager.Inst.findCount = findCount;
        findCountText.text = findCount + "/" + GameManager.Inst.GetTotalCount;
    }
}
