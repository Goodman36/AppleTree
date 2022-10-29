using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]

    //public static int basketindex;

    public GameObject basketPrefab;

    //public static int numBaskets = 1;

    public float basketBottomY = -14f;

    //public float basketSpacingY = 3f;
    //public static List<GameObject> basketList;

    public static int basketLife;

    AudioSource audioS;
    public AudioClip appleDestroyed;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
        basketLife = 3;
        //basketList = new List<GameObject>();
        //for (int i = 0; i < numBaskets; i++)
       // {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY/* + (basketSpacingY * i)*/;
            tBasketGO.transform.position = pos;
            //basketList.Add(tBasketGO);
       // }
       
    }
    public void AppleDestroyed()
    {
        audioS.PlayOneShot(appleDestroyed);
        // Удалить все упавшие яблоки
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        GameObject[] goldenAppleArray = GameObject.FindGameObjectsWithTag("GoldenApple");
        foreach (GameObject tGO in goldenAppleArray)
        {
            Destroy(tGO);
        }
        GameObject[] rottenAppleArray = GameObject.FindGameObjectsWithTag("RottenApple");
        foreach (GameObject tGO in rottenAppleArray)
        {
            Destroy(tGO);
        }
        basketLife--;
        // Удалить одну корзину 
        // Получить индекс последней корзины в basketList
        //basketindex = basketList.Count - 1;
        // Получить ссылку на этот игровой объект Basket
        //GameObject tBasketGO = basketList[basketindex];
        // Исключить корзину из списка и удалить сам игровой объект
        //basketList.RemoveAt(basketindex);
        //Destroy(tBasketGO);
        // Если корзин не осталось перезапустить игру
        if (basketLife <= 0)
        {
            SceneManager.LoadScene("EndGame");
        }
    }
    public void GoldenAppleBonus()
    {
        if (basketLife < 3)
        {
            basketLife++;
        }
    }
}
