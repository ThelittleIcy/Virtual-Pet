using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AAction : StateMachineBehaviour
{
    // Animation Handling

    // Wenn die Animation/Action Endet wird das hier auf True gesetzt - Maybe mit Timer?
    public bool HasFinished { get => m_hasFinished; set => m_hasFinished = value; }
    [SerializeField]
    private bool m_hasFinished = false;

    public AnimationHandler Handler { get => m_handler; set => m_handler = value; }
    [SerializeField]
    private AnimationHandler m_handler;

    public BehavoirEnum Behaviour { get => m_behaviour; set => m_behaviour = value; }
    [SerializeField]
    private BehavoirEnum m_behaviour;

    //public PetBlackboard BlackBoard { get => m_blackBoard; set => m_blackBoard = value; }

    //private PetBlackboard m_blackBoard;

    public virtual void Start()
    {
        m_handler = GameManager.Instance.Animations;
        HasFinished = false;
        //AnimationAnimator = GameManager.Instance.Animations;
    }
    public virtual void Update()
    {

    }
    public virtual void Exit()
    {
        HasFinished = false;
    }
}
