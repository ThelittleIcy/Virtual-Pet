using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AAction : StateMachineBehaviour
{
    // Says, if this Action is Finished and it should move to the next Action.
    public bool HasFinished { get => m_hasFinished; set => m_hasFinished = value; }
    [SerializeField]
    private bool m_hasFinished = false;
    // The Handler, who manages the Animation for this AI.
    public AnimationHandler Handler { get => m_handler; set => m_handler = value; }
    [SerializeField]
    private AnimationHandler m_handler;
    // Says, to which Behaviour this Action belongs.
    public BehaviourEnum Behaviour { get => m_behaviour; set => m_behaviour = value; }
    [SerializeField]
    private BehaviourEnum m_behaviour;

    /// <summary>
    /// Function, which is called at the Start of the Action. Sets up this Action.
    /// </summary>
    public virtual void Start()
    {
        m_handler = GameManager.Instance.Animations;
        HasFinished = false;

        // Used For the Analysis (Testing of Untrained and Trained AI)
        // End Action immediately to get as much Behaviours as possible 
        //      HasFinished = true;
    }

    /// <summary>
    /// Function, which is called every OnStateUpdate.
    /// </summary>
    public virtual void Update()
    {
    }
    /// <summary>
    /// Function, which handels the End of this Action.
    /// </summary>
    public virtual void Exit()
    {
        HasFinished = false;
    }

    /// <summary>
    /// For Testing Purpose: Ends this Action.
    /// </summary>
    [ContextMenu("IsFinished")]
    public void SetFinished()
    {
        HasFinished = true;
    }
}
