using UnityEngine;

public class DurableBox : MonoBehaviour
{
    public float durability = 100f; // Starting durability of the box

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(rb == null)
            return;
        
        // Calculate the momentum of the collision
        // momentum = mass * velocity
        float momentum = collision.relativeVelocity.magnitude * rb.mass;

        // Reduce durability using a formula based on momentum
        float damage = CalculateDamage(momentum);
        durability -= damage;

        Debug.Log($"Collision! Momentum: {momentum}, Damage: {damage}, Remaining Durability: {durability}");

        // Check if durability is depleted
        if (durability <= 0)
        {
            DestroyBox();
        }
    }

    private float CalculateDamage(float momentum)
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        if (ps != null)
        {

            ps.Play();
        }
        // Example formula: Damage is proportional to momentum
        // Adjust the multiplier for tuning the damage system
        float damageMultiplier = 5f;
        return momentum * damageMultiplier;
    }

    private void DestroyBox()
    {
        // Perform destruction logic, e.g., play particle effects, sounds, etc.
        Debug.Log("Box destroyed!");
        Destroy(gameObject);
    }
}