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
    [Header("")]
    [SerializeField] private TextMeshProUGUI scoreText = null;

    public TextMeshProUGUI GetScoreText { get { return scoreText; } private set { } }

    public GameObject GameOverUi { get { return gameOverUi; } private set { } }

    public void SetTimerText(float curTime)
    {
        timerText.text = Mathf.RoundToInt(curTime).ToString();
    }
    public void CallTimeOverUi(bool active = true)
    {
        GameOverUi.SetActive(active);
    }
}
