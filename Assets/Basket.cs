using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamicly")]
    public static Text scoreGT;
    public int deltaScore = 100;
    // Start is called before the first frame update
    void Start()
    {
        // Получить ссылку на игровой объект ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Получить компонент Text этого игрового объекта
        scoreGT = scoreGO.GetComponent<Text>();
        // Установить начальное число равным 0
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        // Получить текущие координаты указателя мыши на экране из Input
        Vector3 mousePos2D = Input.mousePosition;

        // Координата Z камеры определяет, как далеко в трехмерном пространстве находится указатель мыши
        mousePos2D.z = -Camera.main.transform.position.z;

        // Преобразовать точку на двумерной плоскости экрана в трехмерные координаты игры
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Переместить корзину вдоль оси X в координату X указателя мыши
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            AddScore(deltaScore);
        }
    }
    /// <summary>
    /// Метод добавления очков при столкновении с яблоком
    /// </summary>
    private void AddScore(int deltaScore)
    {
        // Преобразовать текст в scoreGT в целове число
        int score = int.Parse(scoreGT.text);
        // Добавить очки за пойманное яблоко
        score += deltaScore;
        // Преобразовать число очков обратно в строку и вывести её на экран
        scoreGT.text = score.ToString();

        //Запомнить высшее достижение
        if (score > HightScrint.score)
        {
            HightScrint.score = score;
        }
    }
}
