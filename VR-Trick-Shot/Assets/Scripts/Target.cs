using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject target;
    public float power = 10f;
    public float upOffset = 0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            var body = other.gameObject.GetComponent<Rigidbody>();
            Vector3 bounceTarget = target.transform.position + new Vector3(0f, upOffset, 0f);

            Vector3 m_DirVector = (bounceTarget - transform.position).normalized;
            body.AddForce(m_DirVector * power, ForceMode.VelocityChange);
        }
    }

}
