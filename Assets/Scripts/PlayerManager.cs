using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private StatsServise playerServise;

    private void Start()
    {
        Stats stats = new Stats
        {
            health = 100,
            speed = 2,
            clearDamage = 4
        };

        Init(new StatsServise(stats));
    }

    public void Init(StatsServise servise)
    {
        playerServise = servise;
    }
}
