using System.Collections.Generic;
using UnityEngine;

namespace Behavior_Scripts
{
    
    [CreateAssetMenu(menuName = "Flock/Behavior/Alignment")]
    public class AlignmentBehavior : FilteredFlockBehavior
    {
        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            if (context.Count == 0)
            {
                return agent.transform.up;
            }
        
            Vector2 alignmentMove = Vector2.zero;

            List<Transform> filteredContext = filter == null ? context : filter.Filter(agent, context); 
            
            foreach (var transform in filteredContext)
            {
                alignmentMove += (Vector2) transform.up;
            }
        
            return alignmentMove;
        }
    }
}
