using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 m_startPosition;
    private Rigidbody m_body;
    private bool m_Reset = false;

    // Start is called before the first frame update
    void Start()
    {
        m_startPosition = transform.position;
        m_body = gameObject.GetComponent<Rigidbody>();
    }

    private void Reset()
    {
        transform.position = m_startPosition;
        m_body.velocity = Vector3.zero;
        m_body.useGravity = false;
        m_Reset = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!m_Reset)
        {
            if (collision.collider.tag == "OutOfBounds")
            {
                m_Reset = true;
                Invoke("Reset", 2f);
            }
        }
    }

}
