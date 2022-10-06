using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ontriger : MonoBehaviour
{
    [SerializeField]
    public static bool isclicked = false;
    public static string selectedobj;
    public void OnTriggerEnter(Collider other)
    {
        isclicked = false;
        selectedobj = other.gameObject.name;
        Debug.Log(selectedobj);
        other.gameObject.GetComponent<BoxCollider>().enabled = false;
        
    }

   
}
