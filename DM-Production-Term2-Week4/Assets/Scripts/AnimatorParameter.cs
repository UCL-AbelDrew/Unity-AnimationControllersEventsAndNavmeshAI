using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorParameter : MonoBehaviour
{
    public Animator m_animator;
    public string m_paramName;

    public void SetParamName(string paramName)
    {
        m_paramName = paramName;
    }
    public void SetParameter(bool value = false)
    {
        if (m_animator)
        {
            m_animator.SetBool(m_paramName, value);
        }
        else {Debug.LogWarning("No Animator Found");}
    }

    public void SetParameter(float value)
    {
        if (m_animator)
        {
            m_animator.SetFloat(m_paramName, value);
        }
        else { Debug.LogWarning("No Animator Found"); }
    }

    public void SetParameter(int value)
    {
        if (m_animator)
        {
            m_animator.SetInteger(m_paramName, value);
        }
        else { Debug.LogWarning("No Animator Found"); }
    }



    public void SetTrigger(string triggerName)
    {
        if (m_animator)
        {
            m_animator.SetTrigger(triggerName);
        }
        else { Debug.LogWarning("No Animator Found"); }
    }

    public void ResetTrigger(string triggerName)
    {
        if (m_animator)
        {
            m_animator.ResetTrigger(triggerName);
        }
        else { Debug.LogWarning("No Animator Found"); }
    }

}
