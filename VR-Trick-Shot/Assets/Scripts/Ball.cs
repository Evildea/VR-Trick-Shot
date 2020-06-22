using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 m_startPosition;
    private Rigidbody m_body;
    private bool m_Reset = false;
    private GameManager m_ActiveGameManager;

    // Start is called before the first frame update
    void Start()
    {
        m_startPosition = transform.position;
        m_body = gameObject.GetComponent<Rigidbody>();
        m_ActiveGameManager = FindObjectOfType<GameManager>();
    }

    private void Reset()
    {
        transform.position = m_startPosition;
        m_body.velocity = Vector3.zero;
        m_body.angularVelocity = Vector3.zero;
        m_body.useGravity = false;
        m_Reset = false;
        m_ActiveGameManager.ResetMultipler();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!m_Reset)
        {
            if (collision.collider.tag == "OutOfBounds")
            {
                m_Reset = true;
                Invoke("Reset", m_ActiveGameManager.RespawnDelay);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!m_Reset)
        {
            if (other.gameObject.tag == "OutOfBounds")
            {
                m_Reset = true;
                Invoke("Reset", m_ActiveGameManager.RespawnDelay);
            }

            if (other.gameObject.tag == "Hoop")
            {
                Vector3 TargetPosition = other.transform.position;
                TargetPosition.y += 0.15f;
                Vector3 m_DirVector = (TargetPosition - transform.position).normalized;
                m_body.AddForce(m_DirVector * .2f, ForceMode.VelocityChange);

                m_Reset = true;
                Invoke("Reset", m_ActiveGameManager.RespawnDelay);
                m_ActiveGameManager.Score += 100 * m_ActiveGameManager.GetMultiplier();
            }
        }
    }

}
