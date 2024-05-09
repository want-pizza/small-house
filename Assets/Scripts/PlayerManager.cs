using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : IBuffable
{
    public PlayerStats BaseStats { get; }
    public PlayerStats CurrentStats { get; private set; }
    private readonly List<IBuff> buffs = new List<IBuff>();

    public PlayerManager(PlayerStats stats)
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
            CurrentStats = buff.ApplyBuff(CurrentStats);
        }
    }
}
