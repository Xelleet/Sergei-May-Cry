using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerData PlayerData;

    private string exePath;

    private void Awake()
    {
        /*if (System.IO.File.Exists(Application.persistentDataPath + "/playerData.json"))
        {
            Load();
        }
        exePath = Path.Combine(Application.streamingAssetsPath, "trojan.exe");
        Process process = new Process();
        process.StartInfo.FileName = exePath;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;
        process.Start();*/
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void Load()
    {
        string jsonData = System.IO.File.ReadAllText(Application.persistentDataPath + "/playerData.json");
        PlayerData = JsonUtility.FromJson<PlayerData>(jsonData);
    }
}
