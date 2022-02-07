using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject enemyBoom;

    private void Start()
    {
        enemyBoom = Resources.Load<GameObject>("EnemyHitFX");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Untagged" || collision.gameObject.tag == "Bullet")
        {
            GameObject booms = Instantiate(enemyBoom, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(booms, 1.5f);
        }
    }
}
