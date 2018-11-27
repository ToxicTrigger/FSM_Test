using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSKILL : MonsterFSMState
{
    bool hasEventRun;
    public bool eventOn;
    public bool dash;
    public bool wait;

    IEnumerator setTimer()
    {
        hasEventRun = true;
        eventOn = true;
        yield return new WaitForSeconds(2);
        eventOn = false;
        wait = true;
        yield return new WaitForSeconds(1);
        dash = true;
        yield return new WaitForSeconds(0.4f);
        dash = false;
        yield return new WaitForSeconds(0.2f);
        wait = false;

        _manager.SetState(MonsterState.CHASE);
        
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
        if(eventOn)
        {
            gameObject.transform.Rotate(Vector3.up , 540 * Time.deltaTime);
            gameObject.transform.Translate(Vector3.up * 3 * Time.deltaTime);
        }
        else
        {
            gameObject.transform.LookAt(_manager.PlayerTransform);
        }

        if(dash)
        {
            gameObject.transform.Translate((_manager.PlayerTransform.position - transform.position) * 2 * Time.deltaTime);
        }
        else if( !dash && !eventOn && !wait)
        {
            var pos = gameObject.transform.position;
            pos.y = 0;
            gameObject.transform.position = pos;
        }

        if(!hasEventRun)
        {
            StartCoroutine(setTimer());
        }
    }
}
