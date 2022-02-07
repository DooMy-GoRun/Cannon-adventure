using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Untagged" || collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
