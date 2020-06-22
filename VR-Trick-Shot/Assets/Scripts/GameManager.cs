using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float RespawnDelay = 2f;
    public int Score = 0;
    private int Multiplier = 1;

    public void TapMultiplier()
    {
        Multiplier += 1;
    }

    public int GetMultiplier()
    {
        return Multiplier;
    }

    public void ResetMultipler()
    {
        Multiplier = 1;
    }
}
