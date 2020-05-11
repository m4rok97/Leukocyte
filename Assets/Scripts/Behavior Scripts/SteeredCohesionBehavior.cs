using System.Collections.Generic;
using UnityEngine;

namespace Behavior_Scripts
{
    
    [CreateAssetMenu(menuName = "Flock/Behavior/Steered Cohesion")]
    public class SteeredCohesionBehavior : FilteredFlockBehavior
    {
        private Vector2 _currentVelocity;
        public float _agentSmoothTime = 0.5f;
        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            if (context.Count == 0)
            {
                return Vector2.zero;
            }
        
            Vector2 cohesionMove = Vector2.zero;
            
            List<Transform> filteredContext = filter == null ? context : filter.Filter(agent, context);
            
            foreach (var transform in filteredContext)
            {
                cohesionMove += (Vector2) transform.position;
            }
        
            cohesionMove /= context.Count;
            var transform1 = agent.transform;
            cohesionMove -= (Vector2)transform1.position;
            cohesionMove = Vector2.SmoothDamp(transform1.up, cohesionMove, ref _currentVelocity, _agentSmoothTime);
            return cohesionMove;
        }
    }
}