using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDEAD : MonsterFSMState {

    public override void BeginState()
    {
        base.BeginState();
        Destroy(gameObject , 2.0f);
    }

    public override void EndState()
    {
        base.EndState();

    }

    private void Update()
    {

    }
}
