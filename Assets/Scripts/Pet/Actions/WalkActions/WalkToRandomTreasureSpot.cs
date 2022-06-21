using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToRandomTreasureSpot : WalkToLocationAction
{
    [SerializeField]
    private List<ScriptableHiddenTreasure> m_treasures;

    public override void Start()
    {
        base.Start();
        SelectAim();
    }
    public override void Update()
    {
        base.Update();
    }
    public override void Exit()
    {
        base.Exit();
    }

    public override void SelectAim()
    {
        Aim = m_treasures[0].Postition;
        GameManager.Instance.BlackBoard.Agent.stoppingDistance = 1f;
    }
}
