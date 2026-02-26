using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeHealthReset : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private TimeSystem timeSystem;

    private void OnEnable()
    {
        timeSystem.OnTimeChanged += HandleTimeChanged;
    }

    private void OnDisable()
    {
        timeSystem.OnTimeChanged -= HandleTimeChanged;
    }

    private void HandleTimeChanged(DayPeriod period, WeekDay day, int dayIndex)
    {
        health.ResetHealth();
    }
}
