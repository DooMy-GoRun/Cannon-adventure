using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameplayController log;

    [Header("Enemy basic position")]
    [SerializeField] Transform enemyTransform;

    [Header("Enemy speed")]
    [SerializeField] private float m_Speed = 5f;

    [Header("Enemy max move position")]
    [SerializeField] private float maxRightPosition = -2f;
    [SerializeField] private float maxLeftPosition = 2f;

    [Header("Player position")]
    [SerializeField] private Transform playerTransform;

    [Header("Enemy weapon position")]
    [SerializeField] private Transform weaponTransform;

    [Header("Enemy bullet speed")]
    [SerializeField] private float enemyBulletSpeed = 40f;

    [Header("Enemy bullet Prefab")]
    [SerializeField] private GameObject enemyBullet;

    [Header("Time to shoot")]
    [SerializeField] private float timeToShoot = 0.5f;

    [Header("Number of hits before death")]
    [SerializeField] private int numberOfDeath = 4;

    private float waitShoot;

    private float randomSpot;
    private Vector3 m_Position;

    private float waitTime;
    private float randomTime;

    void Start()
    {
        waitShoot = timeToShoot;
        RandomizePosition();
    }

    void Update()
    {
        EnemyMove();

        if (waitShoot <= 0)
        {
            EnemyShoot();
            waitShoot = timeToShoot;
        }
        else
        {
            waitShoot -= Time.deltaTime;
        }
    }

    private void RandomizePosition()
    {
        randomSpot = Random.Range(maxRightPosition, maxLeftPosition);
        m_Position = new Vector3(randomSpot, enemyTransform.position.y, enemyTransform.position.z);

        randomTime = Random.Range(0, 2f);
        waitTime = randomTime;
    }

    private void EnemyMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, m_Position, m_Speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, m_Position) <= 0f)
        {
            if (waitTime <= 0)
            {
                RandomizePosition();
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void EnemyShoot()
    {
        weaponTransform.LookAt(playerTransform.position);

        RaycastHit hit;
        
        if(Physics.Raycast(weaponTransform.transform.position, weaponTransform.forward, out hit))
        {
            if(hit.transform.CompareTag("Player"))
            {
                Vector3 spawnPoint = weaponTransform.position;
                Quaternion spawnRoot = weaponTransform.rotation;
                GameObject enemyBall = Instantiate(enemyBullet, spawnPoint, spawnRoot);

                Rigidbody bodyBall = enemyBall.GetComponent<Rigidbody>();
                bodyBall.AddForce(weaponTransform.forward * enemyBulletSpeed, ForceMode.Impulse);

                Destroy(enemyBall, 3f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            log.WriteToLogFile("The projectile hit the enemy");
            numberOfDeath--;

            if (numberOfDeath <= 0)
            {
                ++log.enemyChecker;
                log.WriteToLogFile($"Enemy{log.enemyChecker} is dead");
                Destroy(gameObject);
            }
        }
            
    }
}
