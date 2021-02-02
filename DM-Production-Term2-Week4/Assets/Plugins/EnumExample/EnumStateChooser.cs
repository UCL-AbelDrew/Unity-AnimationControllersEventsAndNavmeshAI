using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumStateChooser : MonoBehaviour
{
    public EnumScriptUseExample m_enumScript;
    // Start is called before the first frame update
    void Start()
    {
        // Starting the enum coroutine in start.
        m_enumScript.enumExample = EnumName.state1;
    }


    // Changing the state to state 1
    public void State1()
    {
        m_enumScript.enumExample = EnumName.state1;
    }


    // Changing the state to state 2
    public void State2()
    {
        m_enumScript.enumExample = EnumName.state2;
    }


}
