using System.Collections.Generic;
using UnityEngine;

namespace Behavior_Scripts
{

    [CreateAssetMenu(menuName = "Flock/Behavior/Avoidance")]
    public class AvoidanceBehavior : FilteredFlockBehavior
    {
        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            if (context.Count == 0)
            {
                return Vector2.zero;
            }
        
            Vector2 avoidanceMove = Vector2.zero;

            int nAvoid = 0;
            
            List<Transform> filteredContext = filter == null ? context : filter.Filter(agent, context);
            
            foreach (var transform in filteredContext)
            {
                if (Vector2.SqrMagnitude(transform.position - agent.transform.position) < flock.SquareAvoidanceRadius)
                {
                    nAvoid++;
                    avoidanceMove += (Vector2) (agent.transform.position - transform.position);
                }
            }

            if (nAvoid > 0)
            {
                avoidanceMove /= nAvoid;
            }

            return avoidanceMove;
        }
    }
}
