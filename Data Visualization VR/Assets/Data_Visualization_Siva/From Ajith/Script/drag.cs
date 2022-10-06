using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Microsoft.MixedReality.Toolkit.UI;
//using Microsoft.MixedReality.Toolkit.Input;

public class drag : MonoBehaviour/*, IMixedRealityPointerHandler*/
{
    [SerializeField] private Transform m_Prefab;
    public static bool object_Darg;
    [SerializeField] private Vector3 m_Object;
    void Start()
    {
        m_Object = m_Prefab.transform.localPosition;
    }
    //public void OnPointerClicked(MixedRealityPointerEventData eventData)
    //{
    //    Debug.Log("OnPointerClicked");
    //}

    //public void OnPointerDown(MixedRealityPointerEventData eventData)
    //{
    //   object_Darg = true;
    //}

    //public void OnPointerDragged(MixedRealityPointerEventData eventData)
    //{
        
    //}

    //public void OnPointerUp(MixedRealityPointerEventData eventData)
    //{
    //    Debug.Log("OnPointerUp");
    //    object_Darg = false;
    //    if (object_Darg == false)
    //    {
    //        m_Prefab.transform.localPosition = m_Object;
    //    }
    //   // transform.localPosition = Vector3.MoveTowards(transform.localPosition, m_Object, 0.01f);
    //}

}
