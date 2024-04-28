using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class LoadGameRank : MonoBehaviour
{
    public TextMeshProUGUI bestPlayerName;
    private static string bestPlayer;
    private static int bestScore;

    private void Awake()
    {
        LoadRank();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    [System.Serializable]
    class SaveData 
    {
        public int highiestScore;
        public string theBestPlayer;
    }


    private void SetBestPlayer()
    {
        if(bestPlayer == null && bestScore == 0) 
        {
            bestPlayerName.text = "";
        }
        else
        {
            bestPlayerName.text = $"BestScore - {bestPlayer}: {bestScore}";
        }
    }

    public void LoadRank()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayer = data.theBestPlayer;
            bestScore = data.highiestScore;
            SetBestPlayer();
        }
    } 
}
