using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public Animator _button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        _button.Play("click");
        Debug.Log("Enter");
    }

    private void OnTriggerExit(Collider other)
    {
        _button.Play("click 0");
        Debug.Log("Exit");
    }
}
