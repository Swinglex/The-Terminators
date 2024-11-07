using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform attackTransform;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private LayerMask attackableLayer;
    [SerializeField] private float damageAmout = 1f;

    private RaycastHit2D[] hits;
    private void Update()
    {
        
       
        if (UserInput.instance.controls.Attack.Attack.WasPressedThisFrame())
        { Attack(); }
        else
        {
            return;
        }

    }

    private void Attack()
    {
        hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attackableLayer);

        for (int i = 0; i< hits.Length; i++)
        {
           IDamageable damageable = hits[i].collider.gameObject.GetComponent<IDamageable>();

            if (damageable != null) 
            {
                damageable.Damage(damageAmout);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }
}
