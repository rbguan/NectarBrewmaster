using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupModel : MonoBehaviour
{
    Animator m_animator;
    void Awake()
    {
        m_animator.Play("spawn");
    }


}
