using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]

    // ������ ��� �������� �����
    public GameObject applePrefab;
    public GameObject goldenApplePrefab;
    public GameObject rottenApplePrefab;

    //����������� ���������� ������� �������� ������
    public float chanceToGoldenApple = 0.05f;

    //����������� ���������� ������� �������� ������
    public float chanceToRottenApple = 0.1f;

    // ������� �������� ����������� �����
    public float secondsBetweenAppleDrops = 1f;

    void Start()
    {
        InvokeRepeating("DropApple", 1, secondsBetweenAppleDrops);
    }
    void DropApple()
    {
        if (Random.value <= chanceToGoldenApple)
        {

            GameObject goldenApple = Instantiate<GameObject>(goldenApplePrefab);
            goldenApple.transform.position = transform.position;
        }
        else if (Random.value <= chanceToRottenApple)
        {
            GameObject rottenApple = Instantiate<GameObject>(rottenApplePrefab);
            rottenApple.transform.position = transform.position;
        }
        else
        {
            GameObject apple = Instantiate<GameObject>(applePrefab);
            apple.transform.position = transform.position;
        }
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Random.Range(-27, 27);
        pos.y = Random.Range(6, 12);
        transform.position = pos;
    }
}
