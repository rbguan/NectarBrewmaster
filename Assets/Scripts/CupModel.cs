using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class CupModel : MonoBehaviour
    {
        Animator m_animator;
        void Awake()
        {
            m_animator.Play("spawn");
        }


    }
}
