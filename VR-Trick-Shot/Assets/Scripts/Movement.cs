﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 m_StartPosition;
    private GameManager m_ActiveGameManager = null;
    private bool m_isMovingLeft = false;

    public float MaxMovementDistanceFromStart;
    public float MovementSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        m_StartPosition = transform.position;
        m_ActiveGameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (m_ActiveGameManager.HasGameEnded())
            return;

        float x = transform.position.x;

        if (m_isMovingLeft)
        {
            x -= MovementSpeed * Time.deltaTime;
            if (x < m_StartPosition.x - MaxMovementDistanceFromStart)
            {
                x = m_StartPosition.x - MaxMovementDistanceFromStart;
                m_isMovingLeft = false;
            }
        }
        else 
        {
            x += MovementSpeed * Time.deltaTime;
            if (x > m_StartPosition.x + MaxMovementDistanceFromStart)
            {
                x = m_StartPosition.x + MaxMovementDistanceFromStart;
                m_isMovingLeft = true;
            }
        }

        Vector3 newPosition = transform.position;
        newPosition.x = x;
        transform.position = newPosition;
    }
}
