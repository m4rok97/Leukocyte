using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;
    public List<FlockAgent> agents;
    public FlockBehavior behavior;

    [Range(1, 500)] public int startingCount = 250;
    private const float AgentDensity = 0.08f;

    [Range(1f, 100f)] public float driveFactor = 10f;
    [Range(1f, 100f)] public float maxSpeed = 5f; 
    [Range(1f, 10f)] public float neighborRadius = 1.5f;
    [Range(0f, 2f)] public float avoidanceRadiusMultiplier = 0.5f;

    private float _squareMaxSpeed;
    private float _squareNeighborRadius;
    private float _squareAvoidanceRadius;

    public float SquareAvoidanceRadius
    {
        get { return _squareAvoidanceRadius; }
    }

    void Start()
    {
        _squareMaxSpeed = maxSpeed * maxSpeed;
        _squareNeighborRadius = neighborRadius * neighborRadius;
        _squareAvoidanceRadius = _squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for (int i = 0; i < startingCount; i++)
        {
            FlockAgent newAgent = Instantiate(
                agentPrefab,
                Random.insideUnitCircle * (startingCount * AgentDensity) + (Vector2)transform.position,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform
            );
            newAgent.name = "Agent" + i;
            newAgent.Initialize(this);
            agents.Add(newAgent);
        }
    }

    void Update()
    {
        foreach (var agent in agents)
        {
            List<Transform> context = GetNearbyObjects(agent);
            
            
            Vector2 move = behavior.CalculateMove(agent, context, this);
            move *= driveFactor;
            if (move.sqrMagnitude > _squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            agent.Move(move);
        }
    }

    // private void FixedUpdate()
    // {
    //     foreach (var agent in agents)
    //     {
    //         List<Transform> context = GetNearbyObjects(agent);
    //         
    //         
    //         Vector2 move = behavior.CalculateMove(agent, context, this);
    //         move *= driveFactor;
    //         if (move.sqrMagnitude > _squareMaxSpeed)
    //         {
    //             move = move.normalized * maxSpeed;
    //         }
    //         agent.Move(move);
    //     }
    // }

    private List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextCollider = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);
        foreach (var collider2D1 in contextCollider)
        {
            if (collider2D1 != agent.AgentCollider)
            {
                context.Add(collider2D1.transform);
            }
        }
        return context;
    }
}