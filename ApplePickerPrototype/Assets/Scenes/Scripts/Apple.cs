using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            // Получить ссылку на компонент ApplePicker главной камеры Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            // Вызвать общедоступный метод AppleDestroyed() из apScript
            apScript.AppleDestroyed();
        }

    }
}
