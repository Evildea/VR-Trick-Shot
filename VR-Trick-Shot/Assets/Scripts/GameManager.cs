using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float RespawnDelay = 2f;
    public int Score = 0;
    public int StartingSeconds = 30;
    public int StartingMinutes = 1;
    public GameObject Follow;
    public AudioSource Cheer;
    public ScoreBoard Scoreboard;

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
            Cheer.Play();
        }
    }

    public void ResetGame()
    {
        Score = 0;
        m_Multiplier = 1;
        Scoreboard.SetTimer(StartingMinutes, StartingSeconds);
        m_GameHasEnded = false;
        m_Particle.Stop();
        Cheer.Stop();
    }

    public bool HasGameEnded()
    {
        return m_GameHasEnded;
    }

    public void Update()
    {
        m_Particle.transform.position = Follow.transform.position;
    }
}