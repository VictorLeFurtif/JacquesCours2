using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AiBehaviorData : ScriptableObject
{
    [field: Header("Ratio for loosing"), SerializeField]
    public float ratioForLoosing { get; private set; }

    [field: Header("Ratio for Run if Loosing"), SerializeField]
    public float ratioRunLoosing { get; private set; }

    [field: Header("Ratio for Run if Winning"), SerializeField]
    public float ratioRunWinning { get; private set; }

    [field: Header("Ratio for Heal if Loosing"), SerializeField]
    public float ratioHealLoosing { get; private set; }

    [field: Header("Ratio for Heal if Winning"), SerializeField]
    public float ratioHealWinning { get; private set; }
}