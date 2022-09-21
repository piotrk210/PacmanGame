using UnityEngine;
using UnityEngine.AI;

namespace _PROJECT.Scripts
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private NavMeshAgent _navMeshAgent;

        [SerializeField]
        private Transform _targetTransform;

        [SerializeField]
        private Transform _startingPosition;
        private bool _shouldFollow;
        private void Update()
        {
            if (_shouldFollow)
            {
                ChaseTarget();
            }
        }

        private void ChaseTarget()
        {
            _navMeshAgent.SetDestination(_targetTransform.position);
        }

        public void SetTarget(Transform targetTransform, Transform startingPosition, float speed)
        {
            _targetTransform = targetTransform;
            _shouldFollow = true;
            _navMeshAgent.speed = speed;
            _startingPosition = startingPosition;
        }

        public void BackToStartingPosition()
        {
            _navMeshAgent.Warp(_startingPosition.position);
        }
    }
}
