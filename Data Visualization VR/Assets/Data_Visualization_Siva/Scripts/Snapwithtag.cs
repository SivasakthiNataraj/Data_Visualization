using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Snapwithtag : XRSocketInteractor
{
    public string tag = string.Empty;

    public override bool CanHover(XRBaseInteractable interactable)
    {
        return base.CanHover(interactable) && Matchusingtag(interactable);
    }       

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return base.CanSelect(interactable) && Matchusingtag(interactable);
    }

    public bool Matchusingtag(XRBaseInteractable interactable)
    {
        return interactable.CompareTag(tag);
    }
        
}
