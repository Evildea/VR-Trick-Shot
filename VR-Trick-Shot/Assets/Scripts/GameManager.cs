using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float RespawnDelay = 2f;
    public int Score = 0;
    public int StartingSeconds = 30;
    public int StartingMinutes = 1;
    public GameObject Follow;

    private int m_Multiplier = 1;
    private ParticleSystem m_Particle = null;
    private bool m_GameHasEnded = false;

    private void Start()
    {
        m_Particle = GetComponentInChildren<ParticleSystem>();
    }

    public void TapMultiplier()
    {
        m_Multiplier += 1;
    }

    public int GetMultiplier()
    {
        return m_Multiplier;
    }

    public void ResetMultipler()
    {
        m_Multiplier = 1;
    }

    public void GameHasEnded()
    {
        if (!m_GameHasEnded)
        {
            m_GameHasEnded = true;
            m_Particle.Play();
        }
    }

    public void Update()
    {
        m_Particle.transform.position = Follow.transform.position;
    }
}