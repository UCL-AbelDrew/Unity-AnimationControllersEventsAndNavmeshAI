using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumScriptUseExample : MonoBehaviour
{

// Serialize so we can see it in the inspector
[SerializeField]
// Declare a private instance of the Enum with a chosen initial state
private EnumName m_enumExample = EnumName.state1;
        
// Declare the publicly accessible version of the Enum
public EnumName enumExample
{
    // Return the state of the private enum on a get request
    get { return m_enumExample; }

    set
    {
        StopAllCoroutines();
        // set the private enum variable to the value passed into the enum
        m_enumExample = value;

        // Pass the private enum into a switch
        switch (m_enumExample)
        {
            // Start the coroutine method for the appropriate state
            case EnumName.state1:
                StartCoroutine(State1Coroutine());
                break;

            case EnumName.state2:

                StartCoroutine(State2Coroutine());
                break;
        }

    }
}
    public IEnumerator State1Coroutine()
    {

        while (m_enumExample == EnumName.state1)
        {

            // Example code. 
            // If something happens that changes the state from state1 to state2 that can be 
            // checked for while inside the co-routine.

            // e.g you may be writing a co-routine that has its own exit conditions to another state
            // such as a character attack state that is animation driven. When the attack animation is called
            // from AI scripts reporting it is in range, we move into the attack state co-routine. 
            // The attack state co-routine would then run every frame, and can check to see if the attack animation
            // has finished playing. Once it has, we need to leave the attack state and return to another state.
            // this code below is an example of that. 

            // Checking an animation controller state (instead of for an input key) will return whether attack is 
            // still true. When it's finished we want the character to reset to another state.

            Debug.Log("State 1");

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // change the state in the public version with the set function that will clear states properly
                
                enumExample = EnumName.state2;

                yield break;
            }

            // Ensure it doesn't crash by yielding for a frame
            yield return null;
        }

    }

    public IEnumerator State2Coroutine()
    {

        while (m_enumExample == EnumName.state2){

            Debug.Log("State 2");

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // change the state in the public version with the set function that will clear states properly

                enumExample = EnumName.state1;

                yield break;
            }

            // Ensure it doesn't crash by yielding for a frame
            yield return null;
        }

    }

}
