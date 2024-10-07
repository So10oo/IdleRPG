using UnityEngine;
using System;

public class ExhaustibleStat : Stat
{
    Action<int> _onCurrentValueChange;
    public event Action<int> OnCurrentValueChange
    {
        add
        { 
            _onCurrentValueChange += value;
            value.Invoke(_currentValue);
        }
        remove
        {
            _onCurrentValueChange -= value;
        }
    }

    int _currentValue;

    public int CurrentValue
    {
        get
        {
            return _currentValue;
        }
        private set
        {
            _currentValue = value;
            _onCurrentValueChange?.Invoke(_currentValue);
        }
    }

    public void SubCurrentValue(int value)
    {
        CurrentValue = Mathf.Clamp(CurrentValue - value, 0, Value);
    }

    public void AddCurrentValue(int value)
    {
        CurrentValue = Mathf.Clamp(CurrentValue + value, 0, Value);
    }

    public void Recover()
    {
        CurrentValue = Value;
    }
}

