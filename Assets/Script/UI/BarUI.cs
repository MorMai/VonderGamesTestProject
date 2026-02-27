using UnityEngine;
using UnityEngine.UI; 

public class BarUI : MonoBehaviour
{
    [SerializeField] private Slider Slider;

    public void UpdateBar(float current, float max)
    {
        float targetFill = current / max;
        Slider.value = targetFill;
    }
}