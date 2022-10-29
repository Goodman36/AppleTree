using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public static Text scoreGT;
    public static int scoreResult;
    public static GameObject collidedWith;
    ApplePicker apScript;

    public AudioClip appleClip;
    public AudioClip goldenAppleClip;

    AudioSource audioS;
    void Start()
    {
        // �������� ������ �� ������� ������ ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // �������� ��������� Text ����� �������� �������
        scoreGT = scoreGO.GetComponent<Text>();
        // ���������� ��������� ����� ����� ������ 0
        scoreGT.text = "0";

        apScript = Camera.main.GetComponent<ApplePicker>();

        audioS = GetComponent<AudioSource>();
    }
    void Update()
    {
        // �������� ������� ���������� ��������� ���� �� ������ �� Input
        Vector3 mousePos2D = Input.mousePosition;
        // ���������� Z ������ ����������, ��� ������ � ���������� ������������
        // ��������� ��������� ����
        mousePos2D.z = -Camera.main.transform.position.z;
        // ������������� ����� �� ��������� ��������� ������ � ����������
        // ���������� ����
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        // ����������� ������� ����� ��� X � ���������� X ��������� ����
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    void OnCollisionEnter(Collision coll)
    {
        // �������� ������, �������� � ��� �������
        collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            // ������������� ����� � scoreGT � ����� �����
            int score = int.Parse(scoreGT.text);
            // �������� ���� �� ��������� ������
            score += 100;
            // ������������� ����� ����� ������� � ������ � ������� �� �� �����
            scoreGT.text = score.ToString();
            // ��������� ������ ����������
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
            scoreResult = score;
            audioS.PlayOneShot(appleClip);
        }
        else if (collidedWith.tag == "GoldenApple")
        {
            Destroy(collidedWith);

            // ������������� ����� � scoreGT � ����� �����
            int score = int.Parse(scoreGT.text);
            // �������� ���� �� ��������� ������
            score += 500;
            // ������������� ����� ����� ������� � ������ � ������� �� �� �����
            scoreGT.text = score.ToString();
            // ��������� ������ ����������
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
            scoreResult = score;
            //ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.GoldenAppleBonus();
            audioS.PlayOneShot(goldenAppleClip);
        }
        else if (collidedWith.tag == "RottenApple")
        {
            Destroy(collidedWith);
            apScript.AppleDestroyed();
        }
    }
}
