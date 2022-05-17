using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ISHHYGDDT : MonoBehaviour
{
    //commit a die stuff
    private Transform trans;
    private Transform gibContainer;
    private Rigidbody[] gibletsRb;
    public Transform explosionCenter;
    private GameObject tardimesh;
    public float power;
    public float radius = 0F; //infinity and beyond
    private Collider c;

    //AI stuff
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        gibContainer = trans.Find("gibs");
        tardimesh = trans.Find("tardimesh").gameObject;
        gibletsRb = gibContainer.GetComponentsInChildren<Rigidbody>();
        c = GetComponent<Collider>();
        agent = GetComponent<NavMeshAgent>();

    }

    void Attack() {
        //player = GameObject.Find("PlayerObj").transform;
    }


    void getDeaded(float destroyAfterSec)
    {
        tardimesh.gameObject.SetActive(false);
        gibContainer.gameObject.SetActive(true);
        GetComponent<Collider>().enabled = false;

        foreach (Rigidbody r in gibletsRb) {
            r.AddExplosionForce(power, explosionCenter.position, radius, 3.0F);
        }
        Destroy(this.gameObject, destroyAfterSec);
    }

    IEnumerator waitasec(float sec)
    {
        yield return new WaitForSeconds(sec);
        getDeaded(10.0f);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.layer == 8 )getDeaded(10f);
    }


    //AI related below
    void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }


    private void Patroling()
    {
        agent.speed = 3.5f;

        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        agent.speed = 20f;
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here
            //Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            ///rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    /*    public void TakeDamage(int damage)
        {
            health -= damage;

            if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
        }
    */
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
