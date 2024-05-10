public class SpeedBuff : IBuff
{
    public Stats ApplyBuff(Stats stats)
    {
        stats.speed *= 2;
        return stats;
    }
}
