using System.Collections.Generic;
using UnityEngine;

namespace Behavior_Scripts
{
    [CreateAssetMenu(menuName = "Flock/Behavior/Attraction")]
    public class AttractionBehavior : FilteredFlockBehavior
    {
        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            if (context.Count == 0)
            {
                return Vector2.zero;
            }

            Vector2 attractionMove = Vector2.zero;

            List<Transform> filteredContext = filter == null ? context : filter.Filter(agent, context);
            float minSqrDistance = float.MaxValue;

            foreach (var transform in filteredContext)
            {
                Vector2 currentMove = transform.position - agent.transform.position;
                float currentSqrDistance = currentMove.sqrMagnitude - flock.SquareAvoidanceRadius;
                if (currentSqrDistance < minSqrDistance)
                {
                    minSqrDistance = currentSqrDistance;
                    attractionMove = currentMove;
                }
            }

            return attractionMove;
        }
    }
}