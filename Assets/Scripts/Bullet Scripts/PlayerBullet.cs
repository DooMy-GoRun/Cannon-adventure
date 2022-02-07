using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("The projectile hit the enemy");
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Untagged" || collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "BulletEnemy")
        {
            Destroy(gameObject);
        }
    }
}
