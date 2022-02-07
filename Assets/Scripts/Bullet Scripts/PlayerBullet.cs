using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private GameObject playerBoom;

    private void Start()
    {
        playerBoom = Resources.Load<GameObject>("PlayerHitFX");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Untagged" || collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "BulletEnemy")
        {
            GameObject booms = Instantiate(playerBoom, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(booms, 1.5f);
        }
    }
}
