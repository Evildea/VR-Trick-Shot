using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private enum State { None, PullToCenter, Falling }
    private enum HoldState { None, Pickup, Hold, Release }

    private Vector3     m_OriginalPosition;
    private Quaternion  m_OriginalRotation;
    private Rigidbody   m_Ball                  = null;
    private GameManager m_ActiveGameManager     = null;
    private bool        m_Reset                 = false;
    private State       m_BallState             = State.None;
    private HoldState   m_HoldState             = HoldState.None;
    private float       m_SnapToCenterHoopTimer = 0f;
    private Collider    m_HoopCollider          = null;


    // Start is called before the first frame update
    void Start()
    {
        m_OriginalPosition  = transform.position;
        m_OriginalRotation  = transform.rotation;
        m_Ball              = gameObject.GetComponent<Rigidbody>();
        m_ActiveGameManager = FindObjectOfType<GameManager>();
    }

    private void Reset()
    {
        m_BallState             = State.None;
        transform.position      = m_OriginalPosition;
        transform.rotation      = m_OriginalRotation;
        m_Ball.velocity         = Vector3.zero;
        m_Ball.angularVelocity  = Vector3.zero;
        m_Ball.useGravity       = false;
        m_Reset                 = false;
        m_ActiveGameManager.ResetMultipler();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!m_Reset)
        {
            if (collision.collider.tag == "OutOfBounds")
            {
                m_Ball.useGravity = true;
                Invoke("Reset", m_ActiveGameManager.RespawnDelay);
                m_Reset = true;
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
                m_Ball.AddForce(m_DirVector * .2f, ForceMode.VelocityChange);

                m_BallState = State.PullToCenter;
                m_SnapToCenterHoopTimer = 0f;
                m_Ball.useGravity = false;
                m_HoopCollider = other;
                m_Ball.velocity = Vector3.zero;
                m_Ball.angularVelocity = Vector3.zero;

                m_ActiveGameManager.Score += 100 * m_ActiveGameManager.GetMultiplier();
            }
        }
    }

    private void Update()
    {
        if (m_BallState == State.PullToCenter)
        {
            m_SnapToCenterHoopTimer += Time.deltaTime;
            if (m_SnapToCenterHoopTimer > 1f)
                m_SnapToCenterHoopTimer = 1f;

            transform.position = Vector3.Lerp(transform.position, m_HoopCollider.transform.position, m_SnapToCenterHoopTimer);

            if (m_SnapToCenterHoopTimer == 1f)
            {
                m_BallState = State.Falling;
                m_Ball.useGravity = true;
            }

            if (m_BallState == State.Falling)
            {
                Vector3 NewPosition = transform.position;
                NewPosition.x = m_HoopCollider.transform.position.x;
                NewPosition.z = m_HoopCollider.transform.position.z;
                transform.position = NewPosition;
            }
        }

        if (m_HoldState == HoldState.Release)
        {
            m_Ball.useGravity = true;
            m_HoldState = HoldState.None;
            m_Ball.AddForce(transform.forward * 400f);
        }
    }

    public void SetRelease()
    {
    m_HoldState = HoldState.Release;
    }

}
