using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public int enemyChecker;

    [Header("Player position")]
    [SerializeField] private Transform player;

    [SerializeField] private Text winText;
    [SerializeField] private Text loseText;

    void Start()
    {
        enemyChecker = 0;
        Time.timeScale = 1f;

        Debug.Log("Start Game");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //do work only this test
        if(player.position.y < 0.97f && player.position.y > 0.47)
        {
            player.position = new Vector3(player.position.x, player.position.y - 0.5f, player.position.z);
            loseText.gameObject.SetActive(true);
            Debug.Log("You lose");
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        if(player.position.z > 36 && enemyChecker == 4)
        {
            winText.gameObject.SetActive(true);
            Debug.Log("You win");
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            ++enemyChecker;
        }
        if(player.position.y > 1)
            player.transform.position = new Vector3(player.position.x, 1f, player.position.z);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
