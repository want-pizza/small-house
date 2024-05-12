using System.Collections.Generic;
using UnityEngine;

public class StatsServise : IBuffable
{
    public Stats BaseStats { get; }
    public Stats CurrentStats { get; private set; }
    private readonly List<IBuff> buffs = new List<IBuff>();

    public StatsServise(Stats stats)
    {
        BaseStats = stats;
        CurrentStats = stats;
    }
    public void AddBuff(IBuff buff)
    {
        buffs.Add(buff);

        ApplyBuff();
        Debug.Log($"buffAdded = {buff}");
    }

    public void RemoveBuff(IBuff buff)
    {
        buffs.Remove(buff);
        ApplyBuff();

        Debug.Log($"buffRemoved = {buff}");
    }

    private void ApplyBuff()
    {
        CurrentStats = BaseStats;

        foreach(IBuff buff in buffs)
        {
            buff.ApplyBuff(CurrentStats.stats);
        }
    }
}
