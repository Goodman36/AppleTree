using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    Text showLife;

    private void Start()
    {

        showLife = this.GetComponentInChildren<Text>();

    }
    void Update()
    {
        if (ApplePicker.basketLife == 3)
        {
            GetComponent<Image>().color = Color.green;
        }
        else if (ApplePicker.basketLife == 2)
        {
            GetComponent<Image>().color = Color.yellow;
        }
        else if (ApplePicker.basketLife == 1)
        {
            GetComponent<Image>().color = Color.red;
        }
        showLife.text = "X " + ApplePicker.basketLife;
    }
}
