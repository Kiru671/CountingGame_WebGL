using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    private Light pointLight;
    private Rigidbody rb;
    private int bleepCount = 0;
    [SerializeField] private float bleepInterval = 1f;
    private float nextBleepTime = 0f;
    private bool startCountdown;

    void Start()
    {
        pointLight = GetComponentInChildren<Light>();
        rb = GetComponent<Rigidbody>();
        nextBleepTime = Time.time + bleepInterval;
        
        GiveBox.OnBoxDropped += OnBoxDropped;
    }

    void Update()
    {
        if (Time.time >= nextBleepTime)
        {
            Bleep();
            nextBleepTime += bleepInterval;
        }
    }

    private void Bleep()
    {
        pointLight.enabled = !pointLight.enabled;
        if(startCountdown)
            bleepCount++;

        if (bleepCount == 4)
        {
            ExplodeRigidbody();
        }
    }

    private void ExplodeRigidbody()
    {
        float explosionRadius = 15f;
        float explosionForce = 1500f;
        Vector3 explosionPosition = transform.position;

        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
            }
        }

        ParticleSystem ps = GetComponent<ParticleSystem>();
        if (ps != null)
        {
            ps.Play();
        }
        Debug.Log("Boom");
        GetComponentInChildren<MeshRenderer>().enabled = false;
        Destroy(gameObject,3f);
    }

    private void OnBoxDropped()
    {
        startCountdown = true;
    }
}
