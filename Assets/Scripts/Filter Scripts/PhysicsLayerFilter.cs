using System.Collections.Generic;
using UnityEngine;

namespace Filter_Scripts
{
    
    [CreateAssetMenu(menuName = "Flock/Filter/Physics Layer")]
    public class PhysicsLayerFilter : ContextFilter
    {
        public LayerMask mask;
        public override List<Transform> Filter(FlockAgent agent, List<Transform> original)
        {
            List<Transform> filtered = new List<Transform>();
            foreach (var transform in original)
            {
                if (mask == (mask | 1 << transform.gameObject.layer))
                {
                    filtered.Add(transform);
                } 
            }

            return filtered;
        }
    }
}
