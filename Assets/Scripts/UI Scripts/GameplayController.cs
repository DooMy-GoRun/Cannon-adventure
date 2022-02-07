using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class GameplayController : MonoBehaviour
{
    public int enemyChecker;

    private string filePath;

    [Header("Player position")]
    [SerializeField] private Transform player;

    [SerializeField] private Text winText;
    [SerializeField] private Text loseText;

    void Start()
    {
        CreateFile();

        enemyChecker = 0;
        Time.timeScale = 1f;

        WriteToLogFile($"Start Game {DateTime.Now}");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //do work only this test
        if (player.position.y < 0.97f && player.position.y > 0.47)
        {
            player.position = new Vector3(player.position.x, player.position.y - 0.5f, player.position.z);
            loseText.gameObject.SetActive(true);
            WriteToLogFile($"You lose {DateTime.Now}\n");
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        if (player.position.z > 36 && enemyChecker == 4)
        {
            winText.gameObject.SetActive(true);
            WriteToLogFile($"You win {DateTime.Now}\n");
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            ++enemyChecker;
        }
        if (player.position.y > 1)
            player.transform.position = new Vector3(player.position.x, 1f, player.position.z);
    }

    private void CreateFile()
    {
        filePath = Application.dataPath + "/LogCannonAdventure.txt";
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void WriteToLogFile(string message)
    {
        using (StreamWriter logFile = new StreamWriter(filePath, true))
        {
            logFile.WriteLine(message);
        }
    }
}
 
    

