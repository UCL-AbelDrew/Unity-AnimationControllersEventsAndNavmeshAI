using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CharacterStates : MonoBehaviour
{
    [SerializeField]
    private float m_attackRange = 0.75f;
    [SerializeField]
    private Animator m_characterAnimator;
    [SerializeField]
    private NavMeshAgent m_CharacterNavMeshAgent;

    [SerializeField]
    private CharacterStatesEnum m_characterState = CharacterStatesEnum.IDLE;
    public CharacterStatesEnum characterState
    {
        // Return the state of the private enum on a get request
        get { return m_characterState; }

        set
        {
            StopAllCoroutines();
            // set the private enum variable to the value passed into the enum
            m_characterState = value;

            // Pass the private enum into a switch
            switch (m_characterState)
            {
                // Start the coroutine method for the appropriate state
                case CharacterStatesEnum.IDLE:
                    StartCoroutine(IdleCoRoutine());
                    break;

                case CharacterStatesEnum.MOVING:

                    StartCoroutine(MovingCoRoutine());
                    break;

                case CharacterStatesEnum.ATTACK:

                    StartCoroutine(AttackCoRoutine());
                    break;
            }

        }
    }

    private GameObject m_target;
    private Vector3 m_destination;

    private void Start()
    {
        characterState = CharacterStatesEnum.IDLE;
    }

    public IEnumerator IdleCoRoutine()
    {

        while (m_characterState == CharacterStatesEnum.IDLE)
        {
            // Sit in idle and search for a target.
            m_characterAnimator.SetBool("Moving", false);
            m_characterAnimator.SetBool("Atacking", false);
                        
            if (!m_target)
            {
               m_target = GameObject.FindGameObjectWithTag("Target");
             
            }

            // If we have a target
            if (m_target)
            {
                characterState = CharacterStatesEnum.MOVING;

                yield break;
            }

            
            yield return null;
        }

    }

    public IEnumerator MovingCoRoutine()
    {

        while (m_characterState == CharacterStatesEnum.MOVING)
        {
            // set moving animation and destination info
            m_characterAnimator.SetBool("Moving", true);
            m_characterAnimator.SetBool("Atacking", false);

            if (m_target)
            {
                m_CharacterNavMeshAgent.destination = m_target.transform.position;
                                             
            }
            
            if (!m_target)
            {
                characterState = CharacterStatesEnum.IDLE;

                yield break;
            }

            // If in range begin an attack
            if (Vector3.Distance(this.gameObject.transform.position, m_CharacterNavMeshAgent.destination) < m_attackRange)
            {

                characterState = CharacterStatesEnum.ATTACK;

                yield break;
            }

          
            yield return null;
        }

    }

    public IEnumerator AttackCoRoutine()
    {

        while (m_characterState == CharacterStatesEnum.ATTACK)
        {
            m_characterAnimator.SetBool("Moving", false);
            m_characterAnimator.SetBool("Atacking", true);

            // Stop continued movement when in range.
             m_CharacterNavMeshAgent.destination = transform.position;
            // if there's no target, drop back to idle
            if (!m_target && m_finishedAttack)
            {

                characterState = CharacterStatesEnum.IDLE;
                m_finishedAttack = false;
                yield return null;
            }
           
            // Ensure it doesn't crash by yielding for a frame
            yield return null;
        }

    }

    public bool m_finishedAttack;
    public void finishedAttack()
    {
        m_finishedAttack = true;
    }

}
