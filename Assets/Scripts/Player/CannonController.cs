using UnityEngine;

public class CannonController : MonoBehaviour
{
    [Header("Player rigidbody")]
    [SerializeField] private Rigidbody body;

    [Header("Player speed")]
    [SerializeField] private float speed = 70f;

    [Header("Bullet Prefab")]
    [Space(10)]
    [SerializeField] private GameObject Bullet;

    [Header("FX to start shoot")]
    [SerializeField] private GameObject FireFX; 

    [Header("Cannon's shot position")]
    [SerializeField] private Transform startPointCannon;

    [Header("Camera position")]
    [SerializeField] private Transform cameraCannon;

    [Header("Bullet speed")]
    [SerializeField] private float bulletSpeed = 35f;

    private Vector2 moveInput;

    private void FixedUpdate()
    {
        Movement();
        //startPointCannon.LookAt(cameraCannon);
    }

    public void ReceiveInput (Vector2 _moveInput)
    {
        moveInput = _moveInput;
    }

    public void Shoot()
    {
        if (Time.timeScale == 1)
        {
            Debug.Log("Shoot");


            //Instantiate(FireFX, startPointCannon.position + Vector3.forward, Quaternion.identity);

            Vector3 spawnPoint = startPointCannon.transform.position;
            Quaternion spawnRoot = startPointCannon.transform.rotation;
            GameObject cannonBall = Instantiate(Bullet, spawnPoint, spawnRoot);

            Rigidbody bodyBall = cannonBall.GetComponent<Rigidbody>();
            bodyBall.AddForce(cameraCannon.transform.forward * bulletSpeed, ForceMode.Impulse);

            if (cannonBall != null)
                Destroy(cannonBall, 3f);
        }
    }

    private void Movement()
    {
        //Vector3 horizontalVelocity = (transform.right * moveInput.x + transform.forward * moveInput.y) * speed;
        Vector3 horizontalVelocity = new Vector3(moveInput.x, transform.position.y, moveInput.y);
        //body.velocity = horizontalVelocity;
        body.AddForce(horizontalVelocity * speed);
    }
}
