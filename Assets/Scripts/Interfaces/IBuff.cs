using System.Collections.Generic;
public interface IBuff
{
    List<IStat> keys { get; set; }
    void ApplyBuff(Dictionary<IStat, float> stats);

}
