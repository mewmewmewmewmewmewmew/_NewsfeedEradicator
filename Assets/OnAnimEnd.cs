using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnAnimEnd : MonoBehaviour
{
    Animation phoneFlip;
    // Start is called before the first frame update
    Animator anim;
    public UnityEvent animEnded;

    void Start()
    {
        
    }

    void Update()
    {

        if (anim.GetCurrentAnimatorStateInfo(0).length < anim.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            animEnded.Invoke();
        }
    }

    
}
