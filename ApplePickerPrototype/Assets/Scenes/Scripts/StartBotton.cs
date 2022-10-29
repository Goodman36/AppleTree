using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBotton : MonoBehaviour
{
    AudioSource audioS;
    public AudioClip startBotton;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }
    public void OnMouseDown()
    {
        audioS.PlayOneShot(startBotton);

        SceneManager.LoadScene("GameScene");
    }

}
