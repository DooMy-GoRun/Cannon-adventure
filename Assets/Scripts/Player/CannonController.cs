using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Rigidbody body;
    [SerializeField] private float speed = 0.7f;

    [Header("For Bullets")]
    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject FireFX; 
    [SerializeField] private Transform startPointCannon;
    [SerializeField] private Transform cameraCannon;
    [SerializeField] private float bulletSpeed = 30f;

    private Vector2 moveInput;

    private void Start()
    {
        Debug.Log("Start Game");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        Movement();
        startPointCannon.LookAt(cameraCannon);
    }

    public void ReceiveInput (Vector2 _moveInput)
    {
        moveInput = _moveInput;
    }

    public void Shoot()
    {
        Debug.Log("Shoot");


        //Instantiate(FireFX, startPointCannon.position + Vector3.forward, Quaternion.identity);

        Vector3 spawnPoint = startPointCannon.transform.position;
        Quaternion spawnRoot = startPointCannon.transform.rotation;
        GameObject cannonBall = Instantiate(Bullet, spawnPoint, spawnRoot);

        Rigidbody bodyBall = cannonBall.GetComponent<Rigidbody>();
        bodyBall.AddForce(cameraCannon.transform.forward * bulletSpeed, ForceMode.Impulse);

        Destroy(cannonBall, 3f);
    }

    private void Movement()
    {
        Vector3 horizontalVelocity = (transform.right * moveInput.x + transform.forward * moveInput.y) * speed;
        body.velocity = horizontalVelocity;
    }
}
