using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehavior : ABehavior
{
    // Used For the Analysis (Testing of Untrained and Trained AI)
    // Increases the Count, how often this Behaviour was shown.
    //[SerializeField]
    //private ScriptableInt m_count;
    /// <summary>
    /// See ABehaviour Awake.
    /// </summary>
    public override void Awake()
    {
        base.Awake();
    }
    /// <summary>
    /// See ABehaviour OnStateEnter.
    /// </summary>
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        // Used For the Analysis (Testing of Untrained and Trained AI)
        // Increases the Count, how often this Behaviour was shown.
        //m_count.Value++;
    }
    /// <summary>
    /// See ABehaviour OnStateUpdate.
    /// </summary>
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
    }
    /// <summary>
    /// See ABehaviour OnStateExit.
    /// </summary>
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);
        
    }
}
