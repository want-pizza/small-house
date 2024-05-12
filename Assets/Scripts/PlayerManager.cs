using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Stats stats;
    private StatsServise playerServise;

    private void Start()
    {
        if (stats != null)
        {
            Init(new StatsServise(stats));
        }
    }

    public void Init(StatsServise servise)
    {
        playerServise = servise;
    }
}
