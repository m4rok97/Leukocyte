using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{
    private Collider2D _agentCollider;
    private Flock _flock;

    public Flock AgentFlock
    {
        get { return _flock; }
    }

    public void Initialize(Flock flock)
    {
        _flock = flock;
    }

    public Collider2D AgentCollider
    {
        get { return _agentCollider; }
    }

    void Start()
    {
        _agentCollider = GetComponent<Collider2D>();
    }

    public void Move(Vector2 velocity)
    {
        var transform1 = transform;
        transform1.up = velocity;
        transform1.position += (Vector3) velocity * Time.deltaTime;
    }
}