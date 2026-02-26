using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    [SerializeField] private DayPeriod startingPeriod;
    [SerializeField] private WeekDay startingWeekDay;
    public int CurrentDayIndex { get; private set; } = 0;
    private int _currentPeriodIndex = -1;
    public DayPeriod CurrentPeriod => (DayPeriod)_currentPeriodIndex;
    public WeekDay CurrentWeekDay => (WeekDay)(CurrentDayIndex % totalWeekDays);

    public event Action<DayPeriod, WeekDay, int> OnTimeChanged;

    private int totalPeriods;
    private int totalWeekDays;

    private void Awake()
    {
        totalPeriods = Enum.GetValues(typeof(DayPeriod)).Length;
        totalWeekDays = Enum.GetValues(typeof(WeekDay)).Length;

        _currentPeriodIndex = (int)startingPeriod;
        CurrentDayIndex = (int)startingWeekDay;

        OnTimeChanged?.Invoke(CurrentPeriod, CurrentWeekDay, CurrentDayIndex);
    }
    public void AdvanceTime()
    {
        Debug.Log("AdvanceTime called");

        _currentPeriodIndex++;

        if (_currentPeriodIndex >= totalPeriods)
        {
            _currentPeriodIndex = 0;
            CurrentDayIndex++;
        }

        OnTimeChanged?.Invoke(CurrentPeriod, CurrentWeekDay, CurrentDayIndex);
    }
}
