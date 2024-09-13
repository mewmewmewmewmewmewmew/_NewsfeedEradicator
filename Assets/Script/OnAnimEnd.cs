using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnAnimEnd : MonoBehaviour
{
    public Animation phoneFlip;
    // Start is called before the first frame update
    public Animator anim;
    public UnityEvent animEnded;
    public bool eventTrigger;

    void Start()
    {
        
    }
    
    
    void Update()
    {

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("PhoneRevert") && !eventTrigger && anim.GetCurrentAnimatorStateInfo(0).length < anim.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            eventTrigger = true;
            animEnded.Invoke();
        }
        else
            eventTrigger = false;
    }

    
}
