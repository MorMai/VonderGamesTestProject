using UnityEngine;
using UnityEngine.UI; 

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;

    public void UpdateHealthBar(float current, float max)
    {
        float targetFill = current / max;
        healthSlider.value = targetFill;
    }
}