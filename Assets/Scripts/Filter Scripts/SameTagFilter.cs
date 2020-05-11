using System.Collections.Generic;
using UnityEngine;

namespace Filter_Scripts
{
    [CreateAssetMenu(menuName = "Flock/Filter/Same Tag")]
    public class SameTagFilter : ContextFilter
    {
        public override List<Transform> Filter(FlockAgent agent, List<Transform> original)
        {
            List<Transform> filtered = new List<Transform>();
            foreach (var transform in original)
            {
                if (transform.CompareTag(agent.tag))
                {
                    filtered.Add(transform);
                }
            }

            return filtered;
        }
    }
}
