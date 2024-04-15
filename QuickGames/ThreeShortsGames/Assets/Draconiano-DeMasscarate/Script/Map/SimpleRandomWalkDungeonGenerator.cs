using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

using Random = UnityEngine.Random;

public class SimpleRandomWalkDungeonGenerator : MonoBehaviour
{

    [SerializeField]
    protected Vector2Int startPosition = Vector2Int.zero;

    [SerializeField]
    private int iterations = 10;
    [SerializeField]
    public int walkLength = 10;
    [SerializeField]
    public bool startRandomlyEachIteration = true;

    public void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPosition = RunRandomWalk();
        foreach(var position in floorPosition)
        {
            Debug.Log(position);
        }
    }

    private HashSet<Vector2Int> RunRandomWalk()
    {
        var currentPosition = startPosition;
        HashSet<Vector2Int> floorPosition = new HashSet<Vector2Int>();
        for (int i = 0;i < iterations; i++)
        {
            var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPosition, walkLength);
            floorPosition.UnionWith(path);
            if(startRandomlyEachIteration)
            {
                currentPosition = floorPosition.ElementAt(Random.Range(0,floorPosition.Count));
            }
           
        }
        return floorPosition;

    }
}
