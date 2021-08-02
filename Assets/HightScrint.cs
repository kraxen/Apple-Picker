using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HightScrint : MonoBehaviour
{
    static public int score = 0;

    private void Awake()
    {
        // Если значение HightScore уже существует в PlayerPrefs, прочитать его
        if (PlayerPrefs.HasKey("HightScore"))
        {
            score = PlayerPrefs.GetInt("HightScore");
        }
        //Сохранить высшее достижение HightScore в хранилище
        PlayerPrefs.SetInt("HightScore", score);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "Hight Score: " + score;
        if(score > PlayerPrefs.GetInt("HightScore"))
        {
            PlayerPrefs.SetInt("HightScore", score);
        }
    }
}
