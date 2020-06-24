using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager m_ActiveGameManager;
    public GameObject target;
    public float power = 10f;
    public float upOffset = 0f;

    public AudioClip sound01;
    public AudioClip sound02;
    public AudioClip sound03;
    public AudioClip sound04;
    public AudioClip sound05;
    public AudioClip sound06;
    public AudioClip sound07;
    public AudioClip sound08;
    public AudioClip sound09;
    public AudioClip sound10;
    public AudioClip sound11;
    public AudioClip sound12;
    public ParticleSystem particle;

    private AudioSource m_AudioSource;

    void Start()
    {
        m_ActiveGameManager = FindObjectOfType<GameManager>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            var body = other.gameObject.GetComponent<Rigidbody>();
            Vector3 bounceTarget = target.transform.position + new Vector3(0f, upOffset, 0f);

            Vector3 m_DirVector = (bounceTarget - transform.position).normalized;
            body.velocity = Vector3.zero;
            body.angularVelocity = Vector3.zero;
            body.AddForce(m_DirVector * power, ForceMode.VelocityChange);

            if (!m_ActiveGameManager.HasGameEnded())
                m_ActiveGameManager.TapMultiplier();

            PlaySound();
            particle.Stop();
            particle.transform.position = other.ClosestPoint(other.gameObject.transform.position);
            particle.Play();
        }
    }

    private void PlaySound()
    {
        AudioClip temp;
        int Rand = (int)Random.Range(1, 12);
        switch (Rand)
        {
            case 1: temp = sound01; break;
            case 2: temp = sound02; break;
            case 3: temp = sound03; break;
            case 4: temp = sound04; break;
            case 5: temp = sound05; break;
            case 6: temp = sound06; break;
            case 7: temp = sound07; break;
            case 8: temp = sound08; break;
            case 9: temp = sound09; break;
            case 10: temp = sound10; break;
            case 11: temp = sound11; break;
            case 12: temp = sound12; break;
            default: temp = sound01; break;
        }

        m_AudioSource.clip = temp;
        m_AudioSource.Play();
    }

}
