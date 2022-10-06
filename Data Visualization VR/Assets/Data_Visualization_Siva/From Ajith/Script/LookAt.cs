using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Camera target;
    Vector3 campos;
    void Start()
    {
        target = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 pos = new Vector3(this.transform.rotation.x, target.transform.rotation.y, this.transform.rotation.z);
        transform.rotation = Quaternion.LookRotation(target.transform.forward);
      
    }
}
