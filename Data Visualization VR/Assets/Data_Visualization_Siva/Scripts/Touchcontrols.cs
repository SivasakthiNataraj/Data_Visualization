using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchcontrols : MonoBehaviour
{

    public GameObject screenobj;

    public bool ObjectEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjectEnabled == true)
        {
            screenobj.transform.position = transform.TransformPoint(0, 0.1f, 0);
        }
        else
        {
            screenobj.transform.position = new Vector3(0, 0, 0);
        }
    }
}
