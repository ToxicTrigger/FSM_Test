using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterATTACK : MonsterFSMState {
    bool hasEventRun;

    IEnumerator setTimer(float Time)
    {
        hasEventRun = true;
        yield return new WaitForSeconds(Time);
        
        if( Random.Range(0 , 100) <= 20)
        {
            _manager.SetState(MonsterState.SKILL);
        }
        hasEventRun = false;
    }

    public override void BeginState()
    {
        base.BeginState();
    }

    public override void EndState()
    {
        base.EndState();
    }

    private void Update()
    {
        if (Vector3.Distance(_manager.PlayerTransform.position, transform.position) >= _manager.Stat.AttackRange)
        {
            _manager.SetState(MonsterState.CHASE);
            return;
        }
        else
        {
            //1/5 의 확률로 스킬을 발동합니다.
            if(!hasEventRun)
            {
                StartCoroutine(setTimer(2.0f));
            }
        }
    }
}
