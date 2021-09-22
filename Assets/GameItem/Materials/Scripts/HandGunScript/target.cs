using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    Animator m_anim = default;
    BoxCollider m_boxCollider;
    private void Start()
    {
        m_anim = GetComponent<Animator>();
        m_boxCollider = GetComponent<BoxCollider>();
    }
    public void Hit()
    {
        m_anim.Play("Hit3");
        Destroy(m_boxCollider);
    }
}