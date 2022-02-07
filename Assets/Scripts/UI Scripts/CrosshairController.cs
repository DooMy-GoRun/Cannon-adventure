using UnityEngine;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour
{
    [SerializeField] private Image crosshair;
    [SerializeField] private Transform cannonCamera;

    void Update()
    {
        CrosshairChanger();
    }

    private void CrosshairChanger()
    {
        RaycastHit hit;

        if(Physics.Raycast(cannonCamera.position, cannonCamera.forward, out hit))
        {
            if (hit.transform.CompareTag("Enemy"))
                crosshair.color = new Color32(219, 199, 69, 150);
            else
            {
                if (hit.transform.CompareTag("Bullet"))
                    return;

                crosshair.color = new Color32(202, 51, 51, 150);
            }
        }
    }
}
