using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        foreach (BaseBehavior behavior in GameManager.Instance.BlackBoard.AllBehaviors)
        {
             if(behavior.BehaviorIndex == BehavoirEnum.BARK)
            {
                behavior.OnTriggeredEvent.Invoke();
            }   
        }
    }
}
