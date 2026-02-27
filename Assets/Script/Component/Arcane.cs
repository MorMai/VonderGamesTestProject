using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Arcane : MonoBehaviour, IRequireStats
{
    private float _currentArcane;
    private float _maxArcane;
    private float _regenRate;

    public UnityEvent<float, float> OnArcaneChanged;

    public void Initialize(EntityData stats)
    {
        _maxArcane = stats.arcane;   
        _currentArcane = _maxArcane;
        _regenRate = stats.arcaneRegenRate;

        OnArcaneChanged?.Invoke(_currentArcane, _maxArcane);
    }

    private void Update()
    {
        if (_currentArcane < _maxArcane) //if not full, regenerate
        {
            RestoreArcane(_regenRate * Time.deltaTime);
        }
    }

    public bool TrySpendArcane(float amount)
    {

        if (_currentArcane < amount)
            return false;

        _currentArcane -= amount;
        _currentArcane = Mathf.Clamp(_currentArcane, 0, _maxArcane);

        OnArcaneChanged?.Invoke(_currentArcane, _maxArcane);
        return true;
    }

    public void RestoreArcane(float amount)
    {
        _currentArcane += amount;
        _currentArcane = Mathf.Clamp(_currentArcane, 0, _maxArcane);

        OnArcaneChanged?.Invoke(_currentArcane, _maxArcane);
    }

    public void ResetArcane()
    {
        _currentArcane = _maxArcane;
        OnArcaneChanged?.Invoke(_currentArcane, _maxArcane);
    }

    public float GetCurrentArcane() => _currentArcane;
}
