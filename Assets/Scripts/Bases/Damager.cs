using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private float damageValue = 1f;
    [SerializeField] private float pushForce = 2f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            MakeDamage(health);
        }
    }

    private void MakeDamage(Health health)
    {
        if (damageValue > 0) // чтобы потенциальные весельчаки не могли хилиться через этот метод
        {
            health.HealthValue -= damageValue;
        }

        var rigidbody2D = health.gameObject.GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(Vector2.up * pushForce, ForceMode2D.Impulse);
    }
}