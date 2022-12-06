using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToRandomTreasureSpot : WalkToLocationAction
{
    // List of all Hidden Treasures, to which the AI can run to.
    [SerializeField]
    private List<ScriptableHiddenTreasure> m_treasures;
    /// <summary>
    /// see WalkToLocationAction Start. Selects Aim.
    /// </summary>
    public override void Start()
    {
        base.Start();
        SelectAim();
    }
    /// <summary>
    /// see WalkToLocationAction Update.
    /// </summary>
    public override void Update()
    {
        base.Update();
    }
    /// <summary>
    /// see WalkToLocationAction Exit.
    /// </summary>
    public override void Exit()
    {
        base.Exit();
    }
    /// <summary>
    /// Selects a random Treasure from treasures and Sets Destination to this Treasure.
    /// </summary>
    public override void SelectAim()
    {
        int rnd = Random.Range(0, m_treasures.Count);
        Aim = m_treasures[rnd].Postition;
        GameManager.Instance.BlackBoard.Agent.stoppingDistance = 1f;
    }
}
