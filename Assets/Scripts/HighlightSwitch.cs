using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightSwitch : MonoBehaviour
{
    public Material switch_highlightMat;
    public bool switchPressed = false;

    private Transform key;
    private Material switch_baseMat;
    private float unpressedTimer = 0.5f;
    private float waitTime = 0.8f;
    private float pressedTimer = 0f;
    private float highlightTime = 3.5f;
    bool useHighlightMat = false;


    void Start()
    {
        key = gameObject.transform.GetChild(1);
        switch_baseMat = key.gameObject.GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (switchPressed)
        {
            pressedTimer += Time.deltaTime;
            key.gameObject.GetComponent<Renderer>().material = switch_highlightMat;
            if (pressedTimer > highlightTime)
            {
                key.gameObject.GetComponent<Renderer>().material = switch_baseMat; // switch back to base mat
                useHighlightMat = false; // reset bool
                unpressedTimer = 0.5f; // reset timer for blinking
                pressedTimer = 0.0f; // reset timer for next press
                switchPressed = false; // reset bool addressed by PressSwitch script
            }
        }
        else
        {
            unpressedTimer += Time.deltaTime; // increment timer
            if (unpressedTimer > waitTime) // check timer
            {
                if (useHighlightMat)
                {
                    key.gameObject.GetComponent<Renderer>().material = switch_highlightMat;
                }
                else
                {
                    key.gameObject.GetComponent<Renderer>().material = switch_baseMat;
                }

                unpressedTimer -= waitTime; // when wait time has passed, reset timer
                useHighlightMat = !useHighlightMat; // use to switch material
            }
        }
       
    }
}
