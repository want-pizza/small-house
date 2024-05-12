using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "BodyStats", menuName = "Stats")]
public class Stats : ScriptableObject
{
    public Dictionary<IStat, float> stats { get; set; }
}
