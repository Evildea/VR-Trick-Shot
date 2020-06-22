using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    private float m_GameTime;
    public TextMesh Timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_GameTime += Time.deltaTime;
        float TempTime = m_GameTime / 1000f;
        string TempText = TempTime.ToString("#.00");
        TempText = TempText.Replace(".", ":");
        Timer.text = TempText;
    }
}
