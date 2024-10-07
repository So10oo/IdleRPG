using System;
using UnityEngine;

[Serializable]
public class Modifier
{
    [SerializeField] int _value;
    [SerializeField] ModifierOperation _operation;
    public int value => _value;
    public ModifierOperation operation => _operation;

    public Modifier(int value, ModifierOperation operation = ModifierOperation.SumBase)
    {
        this._value = value;
        this._operation = operation;
    }

}

[Serializable]
public enum ModifierOperation
{
    SumBase,
    SumSupplement,
    PercentageSupplement
}

