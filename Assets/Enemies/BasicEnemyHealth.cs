using UnityEngine;

public class BasicEnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float m_Health = 3f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = m_Health;
    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth < 0) 
        {
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
    }
}
