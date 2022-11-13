using UnityEngine;
using UnityEngine.SceneManagement;
public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]

    public GameObject basketPrefab;

    public float basketBottomY = -14f;

    public static int basketLife;

    AudioSource audioS;
    public AudioClip appleDestroyed;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
        basketLife = 3;
        GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
        Vector3 pos = Vector3.zero;
        pos.y = basketBottomY;
        tBasketGO.transform.position = pos;


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
