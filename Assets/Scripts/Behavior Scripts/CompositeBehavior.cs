using System.Collections.Generic;
using UnityEngine;

namespace Behavior_Scripts
{
    [CreateAssetMenu(menuName = "Flock/Behavior/Composite")]
    public class CompositeBehavior : FilteredFlockBehavior
    {
        public FlockBehavior[] behaviors;
        public float[] weights;
        
        public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
        {
            if (weights.Length != behaviors.Length)
            {
                Debug.LogError("Data missmatch in " + name, this);
                return Vector2.zero;
            }
            
            Vector2 move = Vector2.zero;
            
            List<Transform> filteredContext = filter == null ? context : filter.Filter(agent, context);
            
            for (int i = 0; i < behaviors.Length; i++)
            {
                Vector2 partialMove = behaviors[i].CalculateMove(agent, filteredContext, flock);

                if (partialMove != Vector2.zero)
                {
                    float squareWeight = weights[i] * weights[i];
                    if (partialMove.sqrMagnitude > squareWeight)
                    {
                        partialMove.Normalize();
                        partialMove *= weights[i];
                    }

                    move += partialMove;
                }
            }

            return move;
        }
    }
}