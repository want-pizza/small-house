using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : IBuff
{
    public List<IStat> keys { get; set; }

    public SpeedBuff(List<IStat> _keys)
    {
        keys = _keys;
    }

    public void ApplyBuff(Dictionary<IStat, float> stats)
    {
        foreach (IStat i in keys)
        {
            float stat = stats.GetValueOrDefault(i);
            
            stats[i] = stat * 2;
        }
    }
}
