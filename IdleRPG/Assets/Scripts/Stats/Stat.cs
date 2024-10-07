using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat
{
    private int _value;
    public int Value
    {
        get
        {
            return _value;
        }
        protected set
        {
            _value = value;
            _onValueChange?.Invoke(value);
        }
    }

    Action<int> _onValueChange;
    public event Action<int> OnValueChange
    {
        add
        {
            _onValueChange += value;
            value.Invoke(Value);
        }
        remove
        {
            _onValueChange -= value;
        }
    }

    private int value;
    private readonly List<Modifier> _modifiers = new List<Modifier>();
    private Modifier _baseModifier;

    public void AddModified(Modifier modifier)
    {
        _modifiers.Add(modifier);
        CalculatedValue();
    }

    public void RemoveModified(Modifier modifier)
    {
        _modifiers.Remove(modifier);
        CalculatedValue();
    }

    public void SetBaseModified(Modifier baseModifier)
    {
        if (_baseModifier!=null)
            RemoveModified(_baseModifier);
        _baseModifier = baseModifier;
        AddModified(_baseModifier);
    }

    void CalculatedValue()
    {
        float totalModifier_SumBase = default;
        float totalModifier_SumSupplement = default;
        float totalModifier_PercentageSupplement = default;
        foreach (Modifier modifier in _modifiers)
        {

            switch (modifier.operation)
            {
                case ModifierOperation.SumBase:
                    totalModifier_SumBase += modifier.value;
                    break;
                case ModifierOperation.SumSupplement:
                    totalModifier_SumSupplement += modifier.value;
                    break;
                case ModifierOperation.PercentageSupplement:
                    totalModifier_PercentageSupplement += modifier.value;
                    break;
            }
        }
        Value = Mathf.RoundToInt(totalModifier_SumBase + totalModifier_SumSupplement * totalModifier_PercentageSupplement);
    }

    public Stat(Modifier initModifier)
    {
        AddModified(initModifier);
    }

    public Stat()
    {
    }


}
