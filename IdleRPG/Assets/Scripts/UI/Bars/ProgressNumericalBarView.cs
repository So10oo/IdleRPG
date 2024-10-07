using TMPro;
using UnityEngine;


public class ProgressNumericalBarView : ProgressBarView
{
    [SerializeField] TextMeshProUGUI textNumericalProgress;

    public void SetProgress(int currentNum, int maxNum)
    {
        SetProgress((float)currentNum / (float)maxNum);
        textNumericalProgress.text = $"{currentNum}/{maxNum}";
    }
}

