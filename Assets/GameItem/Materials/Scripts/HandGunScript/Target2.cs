using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target2 : MonoBehaviour
{
    Animator m_anim = default;
    BoxCollider m_boxCollider;
    private void Start()
    {
        m_anim = GetComponent<Animator>();
        m_boxCollider = GetComponent<BoxCollider>();
    }
    public void Hit2()
    {
        m_anim.Play("Hit2");
        Destroy(m_boxCollider);
    }
}