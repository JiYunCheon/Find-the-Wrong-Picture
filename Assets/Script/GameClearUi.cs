using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameClearUi : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText = null;
    [SerializeField] TextMeshProUGUI scoreText = null;

    private void Awake()
    {
        timeText.text = GameManager.Inst.GetCurTime.ToString("F1");
        scoreText.text = GameManager.Inst.GetCurScore.ToString();
    }
}
