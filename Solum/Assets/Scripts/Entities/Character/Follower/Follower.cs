using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Wreckless
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Follower : Character
    {

        public enum AIState
        {
            FOLLOWING,
            IDLE,
            INTERACTING,
            CONTROLLED
        }

        //Different movement speeds to keep follower close to player
        public float[] movementSpeeds;
        //Distance before each movement speed is changed;
        public float[] movementSpeedDist;

        private NavMeshAgent Agent => GetComponent<NavMeshAgent>();
        private AIState currentState;

        private Transform Player => FindObjectOfType<PlayerController>().transform;

        private Transform target;

        private void Start()
        {
            ChangeSpeed(movementSpeeds[0]);
            Agent.stoppingDistance = 4;
            currentState = AIState.IDLE;
            SetTarget(Player);
        }

        private void Update()
        {

            var dist = Vector3.Distance(transform.position, Player.position);

            Agent.SetDestination(target.position);

            switch (currentState)
            {
                case AIState.FOLLOWING:
                    Agent.isStopped = false;
                    if(dist < movementSpeedDist[0])
                    {
                        currentState = AIState.IDLE;
                    }
                    else if(dist >= movementSpeedDist[0])
                    {
                        ChangeSpeed(movementSpeeds[0]);
                    }
                    else if (dist >= movementSpeedDist[1])
                    {
                        ChangeSpeed(movementSpeeds[1]);
                    }
                    break;
                case AIState.IDLE:
                    Agent.isStopped = true;
                    if(dist >= movementSpeedDist[0])
                    {
                        currentState = AIState.FOLLOWING;
                    }
                    break;
                default:
                    break;
            }

        }

        public void ChangeSpeed(float s)
        {
            Agent.speed = s;
        }

        public void SetTarget(Transform newTarget)
        {
            target = newTarget;
        }

    }
}