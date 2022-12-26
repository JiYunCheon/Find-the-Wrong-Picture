using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("========Ui Box========")]
    [Header("")]
    [SerializeField] private TextMeshProUGUI timerText = null;
    [SerializeField] private TextMeshProUGUI findCountText = null;

    private int curScore = 0;
    private int findCount = 0;

    public void SetTimerText(float curTime)
    {
        timerText.text = curTime.ToString("F1");
    }

    public void CallAddFindCount()
    {
        findCount++;
        GameManager.Inst.findCount = findCount;
        findCountText.text = findCount + "/" + GameManager.Inst.GetTotalCount;
    }

    public void Off_Ui()
    {
        timerText.gameObject.SetActive(false);
        findCountText.gameObject.SetActive(false);
    }
}
