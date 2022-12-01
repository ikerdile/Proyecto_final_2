﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DamageHandler_Enemy : vp_DamageHandler
{
    private Animator _animator;

    private NavMeshAgent _navMeshAgent;

    public GameObject Player;

    public float AttackDistance = 10.0f;

    protected override void Awake()
    {
        base.Awake();

        _navMeshAgent = GetComponent<NavMeshAgent>();

        _animator = GetComponent<Animator>();

    }

    public void Update()
    {
        if (_navMeshAgent.enabled)
        {
            float dist = Vector3.Distance(Player.transform.position, this.transform.position);

            if (dist < AttackDistance)
            {
                _navMeshAgent.SetDestination(Player.transform.position);
                _animator.SetBool("Attack", false);
                _animator.SetBool("IsFollow", true);
            }
            else
            {
                _animator.SetBool("Attack", false);
                _animator.SetBool("IsFollow", false);
                _navMeshAgent.SetDestination(transform.position);
            }

            // TODO: Get rid of this magic number (perhaps add property)
            if (dist < 3.0f)
            {
                _animator.SetBool("Attack", true);
                _animator.SetBool("IsFollow", false);
            }
        }
        
    }


    /// <summary>
    /// Character takes damage
    /// </summary>
    /// <param name="damageInfo"></param>
    public override void Damage(vp_DamageInfo damageInfo)
    {
        if (CurrentHealth > 0 )
        {

            AnimatorStateInfo si = _animator.GetCurrentAnimatorStateInfo(0);
            if (!si.IsName("Attack"))
            {

                base.Damage(damageInfo);

                _animator.Play("Hit", 0, 0.25f);

                _navMeshAgent.enabled = false;
            }
        }
    }

    /// <summary>
    /// Should be called from an animation event
    /// </summary>
    public void OnHitEnd()
    {
        Debug.Log("OnHitEnd called for mad butcher");

        _navMeshAgent.enabled = true;
    }

    /// <summary>
    /// Character dies
    /// </summary>
    public override void Die()
    {
        if (!enabled || !vp_Utility.IsActive(gameObject))
            return;

        if (m_Audio != null)
        {
            m_Audio.pitch = Time.timeScale;
            m_Audio.PlayOneShot(DeathSound);
        }

        _navMeshAgent.enabled = false;

        _animator.SetBool("IsFollow", false);
        _animator.SetBool("Attack", false);

        _animator.SetTrigger("Dying");

        Destroy(GetComponent<vp_SurfaceIdentifier>());

    }

    /// <summary>
    /// Notice: Add the EndAttack event to the attack animation of your character
    /// </summary>
    public void EndAttack()
    {
        float dist = Vector3.Distance(Player.transform.position, this.transform.position);

        // TODO: Get rid of this magic number here: (perhaps add property)
        if(dist < 3.0f)
        {
            Player.SendMessage("Damage", 4.0f, SendMessageOptions.DontRequireReceiver);
        }
    }
}
