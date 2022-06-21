using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyProp : ReactionProp
{
    [SerializeField]
    private Transform m_origin;
    [SerializeField]
    private Transform m_target;

    [SerializeField]
    private PropInteraction m_interaction;

    [SerializeField]
    private float m_speed = 1f;


    public override void Activate()
    {
        StartCoroutine(MoveToShelf());
    }

    public override void Deactivate()
    {
        StartCoroutine(MoveToGround());
    }

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
