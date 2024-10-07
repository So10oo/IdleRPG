using UnityEngine;
using UnityEngine.UI;

public class ProgressBarView : MonoBehaviour
{
    [SerializeField] Image _bar;

    public void SetProgress(float progress)
    {
        _bar.fillAmount = Mathf.Clamp(progress, 0f, 1f);
    }

    public void SetColor(Color color)
    {
        _bar.color = color;
    }

    public void SetActive(bool active, float? progress = null)
    {
        gameObject.SetActive(active);
        if (progress is float p)
            SetProgress(p);
    }
}
