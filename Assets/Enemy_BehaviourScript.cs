using UnityEngine;

public class Enemy_BehaviourScript : MonoBehaviour
{
    public Transform rayCast;
    public LayerMask rayCastMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;

    public RaycastHit2D hit;         
    public GameObject target;        
    public Animator animator; 
    public float distance;           
    public bool attackMode;          
    public bool inRange;             
    public bool cooling;             
    public float intTimer;      

    private void Awake()
    {
        intTimer = timer;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, rayCastMask);
            RaycastDebugger();
        }
        if (hit.collider != null) {
            EnemyLogic();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }
        if (!inRange)
        {
            animator.SetBool("canWalk", false);
            StopAttack();
        }
    }

    public void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if (attackDistance >= distance && !cooling) {
            Attack();
        }
        if (cooling) {
            Cooldown();
            animator.SetBool("Attack", false);
        }
    }

    public void Move()
    {
        animator.SetBool("canWalk", true);
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("EnemyAttak"))
        {
            Vector2 tatgetPosition = new Vector2(target.transform.position.x, target.transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, tatgetPosition, moveSpeed * Time.deltaTime);
        }
    }

    public void Attack()
    {
        timer = intTimer;
        attackMode = true;
        animator.SetBool("canWalk", false);
        animator.SetBool("Attack", true);
    }

    public void Cooldown()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode) { 
            cooling = false;
            timer = intTimer;
        }
    }

    public void StopAttack()
    {
        cooling = false;
        attackMode= false;
        animator.SetBool("Attack", false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target = collision.gameObject;
            inRange = true;
        }
    }

    public void RaycastDebugger()
    {
        if (distance > attackDistance) {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
        }
        else if (attackDistance > distance){ 
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }
}
