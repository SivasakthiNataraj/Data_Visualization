using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphscaleUI : MonoBehaviour
{
    public bool Check = false;

    public GameObject _bar;
    public float updatedY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Check == true)
        {
            updatedY = (_bar.transform.localScale.y / 1) * 210f + 10f;
            this.gameObject.transform.localPosition = new Vector3(transform.localPosition.x,updatedY, transform.localPosition.z);
        }
    }
}
