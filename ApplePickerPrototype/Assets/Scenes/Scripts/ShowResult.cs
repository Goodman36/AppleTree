using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{
    Text record;
    void Start()
    {
        record = this.GetComponent<Text>();
    }

    void Update()
    {
        record.text = "Your result:" + Basket.scoreResult;

    }
}
