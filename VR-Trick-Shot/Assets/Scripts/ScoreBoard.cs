using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    private int m_Seconds = 0;
    private int m_Minutes = 0;
    private GameManager m_ActiveGameManager;
    public TextMesh Timer;
    public TextMesh Score;
    public TextMesh Multiplier;

    // Start is called before the first frame update
    void Start()
    {
        m_ActiveGameManager = FindObjectOfType<GameManager>();
        Invoke("SecondCounter", 1);   
    }

    // Count How Many Seconds and Minutes have passed
    void SecondCounter()
    {
        m_Seconds += 1;
        if (m_Seconds > 59)
        {
            m_Seconds = 0;
            m_Minutes += 1;
        }
        Invoke("SecondCounter", 1);
    }

    // Update is called once per frame
    void Update()
    {
        // Don't proceed if the Game Manager is assigned
        if (m_ActiveGameManager == null)
            return;

        // Generate Second Text String
        string SecondText;
        if (m_Seconds < 10)
            SecondText = "0" + m_Seconds.ToString();
        else
            SecondText = m_Seconds.ToString();

        // Generate Minute Text String
        string MinuteText;
        if (m_Minutes < 10)
            MinuteText = "0" + m_Minutes.ToString();
        else
            MinuteText = m_Minutes.ToString();

        // Generate Text for Timer
        Timer.text = MinuteText + ":" + SecondText;

        // Generate Text for the Score
        Score.text = m_ActiveGameManager.Score.ToString();

        // Generate Text for the Multiplier
        int MultiplierAmount = m_ActiveGameManager.GetMultiplier();
        if (MultiplierAmount != 0)
            Multiplier.text = "x" + m_ActiveGameManager.GetMultiplier().ToString();
        else
            Multiplier.text = "x0";


    }
}
