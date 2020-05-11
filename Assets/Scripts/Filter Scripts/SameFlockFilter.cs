using System.Collections.Generic;
using UnityEngine;

namespace Filter_Scripts
{
    [CreateAssetMenu(menuName = "Flock/Filter/Same Flock")]
    public class SameFlockFilter : ContextFilter
    {
        public override List<Transform> Filter(FlockAgent agent, List<Transform> original)
        {
            List<Transform> filtered = new List<Transform>();
            foreach (var transform in original)
            {
                FlockAgent transformAgent = transform.GetComponent<FlockAgent>();
                if (transformAgent != null && transformAgent.AgentFlock == agent.AgentFlock)
                {
                    filtered.Add(transform);
                }
            }

            return filtered;
        }
    }
}