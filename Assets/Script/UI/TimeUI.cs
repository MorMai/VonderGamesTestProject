using UnityEngine;
using TMPro;

public class TimeUI : MonoBehaviour
{
    [SerializeField] private TimeSystem timeSystem;

    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI weekdayText;
    [SerializeField] private TextMeshProUGUI daycountText;
    public void Start()
    {
        UpdateUI(timeSystem.CurrentPeriod, timeSystem.CurrentWeekDay, timeSystem.CurrentDayIndex);
    }
    private void OnEnable()
    {
        timeSystem.OnTimeChanged += UpdateUI;
    }

    private void OnDisable()
    {
        timeSystem.OnTimeChanged -= UpdateUI;
    }

    private void UpdateUI(DayPeriod period, WeekDay weekDay, int dayIndex)
    {
        timeText.text = $"{period}";
        weekdayText.text = $"{weekDay}";
        daycountText.text = $"Day {dayIndex}";
    }
}