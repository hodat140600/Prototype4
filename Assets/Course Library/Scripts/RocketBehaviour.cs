using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
    public Transform target;
    private float speed = 15.0f;
    private float rocketStrength = 15.0f;
    private float aliveTimer = 5.0f;

    private bool homing;

    // Update is called once per frame
    void Update()
    {
        if (homing && target != null) {
            Vector3 moveDirection = (target.transform.position - transform.position).normalized;
            transform.position += moveDirection * speed * Time.deltaTime;
            transform.LookAt(target);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (target != null) {
            if (collision.gameObject.CompareTag(target.tag)) { 
                Rigidbody targetRb = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 away = -collision.contacts[0].normal;
                targetRb.AddForce(away * rocketStrength, ForceMode.Impulse);
                Destroy(gameObject);
            }
        }
    }
    public void Fire(Transform homingTarget) {
        target = homingTarget;
        homing = true;
        Destroy(gameObject, aliveTimer);
    }
}
