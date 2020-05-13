using System.Collections.Generic;
using UnityEngine;

namespace Filter_Scripts
{
    [CreateAssetMenu(menuName = "Flock/Filter/Tag")]
    public class TagFilter : ContextFilter
    {
        public string tag;
    
        public override List<Transform> Filter(FlockAgent agent, List<Transform> original)
        {

            List<Transform> filtered = new List<Transform>();
            foreach (var transform in original)
            {
                Debug.Log(transform.tag);
                if (transform.CompareTag(tag))
                {
                    Debug.Log("Entra con" );
                    filtered.Add(transform);
                }
            }

            return filtered;
        }
    }
}
