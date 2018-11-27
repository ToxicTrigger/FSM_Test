﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public StatData Stat;

    [SerializeField]
    private float _hp = 100.0f;
    public float Hp { get { return _hp; } }

    [SerializeField]
    private float _moveSpeed = 3.0f;
    public float MoveSpeed { get { return _moveSpeed; } }

    [SerializeField]
    private float _turnSpeed = 540.0f;
    public float TurnSpeed { get { return _turnSpeed; } }

    [SerializeField]
    private float _attackRange = 2.0f;
    public float AttackRange { get { return _attackRange; } }

    [SerializeField]
    private float _attackPower = 50.0f;
    public float AttackPower { get { return _attackPower; } }

    public CharacterStat lastHitBy = null;

    private void Awake()
    {
        if(Stat != null)
        {
            _hp = Stat.maxHp;
            _moveSpeed = Stat.moveSpeed;
            _turnSpeed = Stat.turnSpeed;
            _attackRange = Stat.attackRange;
            _attackPower = Stat.Power;
        }
    }

    public void TakeDamage(CharacterStat from, float damage)
    {
        _hp = Mathf.Clamp(_hp - damage, 0, 100);
        if(_hp <= 0)
        {
            if (lastHitBy == null)
                lastHitBy = from;

            GetComponent<IFSMManager>().SetDeadState();
            from.GetComponent<IFSMManager>().NotifyTargetKilled();
            Debug.Log(name + " is Killed by " + lastHitBy.name);
        }
    }

    private static float CalcDamage(CharacterStat from, CharacterStat to)
    {
        return from._attackPower;
    }

    public static void ProcessDamage(CharacterStat from, CharacterStat to)
    {
        float finalDamage = CalcDamage(from, to);
        to.TakeDamage(from, finalDamage);
    }
}
