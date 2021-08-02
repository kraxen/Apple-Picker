using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]

    // Шаблон создания яблок
    public GameObject applePerfab;

    // Скорость движения яблони
    public float speed = 10f;

    // Расстояние, на котором должно измениться направление движения яблони
    public float leftAndRightEdge = 20f;

    // Вероятность случайного изменения движения яблони
    public float changeToChangeDirections = 0.02f;

    // Частота сознания экземпляров яблок
    public float secondsBetweenAppleDrops = 1f;

    int addiferent = 1000;


    // Start is called before the first frame update
    void Start()
    {
        // Сбрасывать яблоки раз в секунду
        Invoke("DropApple", 2f);
    }
    /// <summary>
    /// Метод сбрасывания яблок
    /// </summary>
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePerfab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        // Простое перемещение
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        // Изменение направления
        if(pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // Начать движение вправо
        } else
        if(pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Начать движение влево
        }
    }
    private void FixedUpdate()
    {
        if(int.Parse(Basket.scoreGT.text) >= addiferent)
        {
            if(speed > 0)
            {
                speed += 1f;
            }
            else
            {
                speed -= 1f;
            }
            secondsBetweenAppleDrops -= 0.01f;
            addiferent+= 1000;
        }
        if (UnityEngine.Random.value < changeToChangeDirections)
        {
            speed *= -1; // Изменить направление
        }
    }
}
