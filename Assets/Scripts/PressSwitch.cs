using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.GetComponent<HighlightSwitch>().switchPressed = true;
            GetComponent<Animator>().SetTrigger("SwitchPress");
            GameObject.Find("Rabbit").GetComponent<Animator>().SetTrigger("RabbitShake");
        }
    }
}
