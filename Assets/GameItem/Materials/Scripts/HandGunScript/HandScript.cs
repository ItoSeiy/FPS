using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    Animator m_animator;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        m_animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //カーソルを表示させる
        {
            Cursor.visible = true;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            m_animator.Play("HandAnimation", 0, 0);
        }
        
    }
}
