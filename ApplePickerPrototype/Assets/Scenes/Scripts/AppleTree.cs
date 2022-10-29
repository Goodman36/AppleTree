using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]

    // Шаблон для создания яблок
    public GameObject applePrefab;
    public GameObject goldenApplePrefab;
    public GameObject rottenApplePrefab;

    // Скорость движения яблони
    //public float speed = 1f;

    // Расстояние, на котором должно изменяться направление движения яблони
    //public float leftAndRightEdge = 10f;

    //Вероятность случайного изменения направления
    //public float chanceToChangeDirections = 0.1f;

    //Вероятность случайного падения золотого яблока
    public float  chanceToGoldenApple = 0.05f;

    //Вероятность случайного падения золотого яблока
    public float chanceToRottenApple = 0.1f;

    // Частота создания экземпляров яблок
    public float secondsBetweenAppleDrops = 1f;

    float posX;
    float posY;

    void Start()
    {
        Invoke("DropApple", 1f);
    }
    void DropApple()
    {
        if(Random.value <= chanceToGoldenApple)
        {
            
            GameObject goldenApple = Instantiate<GameObject>(goldenApplePrefab);
            goldenApple.transform.position = transform.position;
            Invoke("DropApple", secondsBetweenAppleDrops);
        }
        else if (Random.value <= chanceToRottenApple)
        {
            GameObject rottenApple = Instantiate<GameObject>(rottenApplePrefab);
            rottenApple.transform.position = transform.position;
            Invoke("DropApple", secondsBetweenAppleDrops);
        }
        else
        {
            GameObject apple = Instantiate<GameObject>(applePrefab);
            apple.transform.position = transform.position;
            Invoke("DropApple", secondsBetweenAppleDrops);
        }

        //GameObject apple = Instantiate<GameObject>(applePrefab);
        //apple.transform.position = transform.position;
        //Invoke("DropApple", secondsBetweenAppleDrops);
    }

    void Update()
    {
        posX = Random.Range(-27, 27);
        posY = Random.Range(6, 12);
        Vector3 pos = transform.position;
        pos.x = posX;
        //pos.x += speed * Time.deltaTime;
        pos.y = posY;
        transform.position = pos;

        /*if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }*/
    }
    void FixedUpdate()
    {

        /*if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }*/
    }
}
