using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyProp : ReactionProp
{
    // The Origin Position.
    [SerializeField]
    private Transform m_origin;
    //  The Target Position.
    [SerializeField]
    private Transform m_target;
    // The Interaction.
    [SerializeField]
    private PropInteraction m_interaction;
    // The MovementSpeed.
    [SerializeField]
    private float m_speed = 1f;

    /// <summary>
    /// Activates this Doll (Moves To Shelf)
    /// </summary>
    public override void Activate()
    {
        StartCoroutine(MoveToShelf());
    }
    /// <summary>
    /// Deactivates this Doll (Moves to the Ground)
    /// </summary>
    public override void Deactivate()
    {
        StartCoroutine(MoveToGround());
    }
    /// <summary>
    /// Moves the Gameobject to The Origin position.
    /// </summary>
    /// <returns></returns>
    private IEnumerator MoveToGround()
    {
        float time = 0f;
        while (this.transform.position != m_origin.position)
        {
            this.transform.position = Vector3.Lerp(m_target.position, m_origin.position,
                (time / Vector3.Distance(m_origin.position, m_target.position)) * m_speed);
            time += Time.deltaTime;
            yield return null;
        }
        if (this.transform.position == m_origin.position)
        {
            m_interaction.Interaction.Collider.enabled = false;
            IsUsed = false;
            yield break;
        }
    }
    /// <summary>
    /// Moves this Gameobject to the Target Position.
    /// </summary>
    /// <returns></returns>
    private IEnumerator MoveToShelf()
    {
        float time = 0f;
        while (this.transform.position != m_target.position)
        {
            this.transform.position = Vector3.Lerp(m_origin.position, m_target.position,
                (time / Vector3.Distance(m_origin.position, m_target.position)) * m_speed);
            time += Time.deltaTime;
            yield return null;
        }
        if (this.transform.position == m_target.position)
        {
            m_interaction.Interaction.Collider.enabled = true;
            IsUsed = true;
            yield break;
        }
    }
}
