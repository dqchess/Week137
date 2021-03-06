﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipFlopMovement : MonoBehaviour
{

    

    public feetState state;

    public float massAsAnchor;
    public float massAsFeet;

    public List<Behaviour> behavioursAsAnchor = new List<Behaviour>();
    public List<Behaviour> behavioursAsFeet = new List<Behaviour>();
 

    private Rigidbody2D rb;
    private TargetJoint2D mouseJoint;
    private SpringJoint2D anchorJoint;

    private void Start()
    {
        anchorJoint = GetComponent<SpringJoint2D>();
        rb = GetComponent<Rigidbody2D>();
        mouseJoint = GetComponent<TargetJoint2D>();
    }

    public void makeAnchor()
    {
        state = feetState.anchor;
        rb.mass = massAsAnchor;
        anchorJoint.enabled = false;
        mouseJoint.enabled = false;
        foreach(Behaviour n in behavioursAsAnchor)
        {
            n.enabled = true;
        }
        foreach(Behaviour n in behavioursAsFeet)
        {
            n.enabled = false;
        }
    }

    public void makeFeet()
    {
        anchorJoint.enabled = true;
        state = feetState.feet;
        rb.mass = massAsFeet;
        mouseJoint.enabled = true;
        foreach (Behaviour n in behavioursAsAnchor)
        {
            n.enabled = false;
        }
        foreach (Behaviour n in behavioursAsFeet)
        {
            n.enabled = true;
        }
    }
}

public enum feetState
{
    anchor, feet
}