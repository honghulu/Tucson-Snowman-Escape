using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatorBool : MonoBehaviour
{
    public Animator animator;
    public string parameterName;

    public void SetValue(bool newValue) {
        animator.SetBool(parameterName, newValue);
    }
}
