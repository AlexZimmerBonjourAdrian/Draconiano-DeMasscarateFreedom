using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

using Random = UnityEngine.Random;

public class SimpleRandomWalkDungeonGenerator : AbstractDungeonGenerator
{

    //[SerializeField]
    //protected Vector2Int startPosition = Vector2Int.zero;

    //[SerializeField]
    //private int iterations = 10;

    //[SerializeField]
    //public int walkLength = 10;

    //[SerializeField]
    //public bool startRandomlyEachIteration = true;

    [SerializeField]
    private SimpleRandomWalkSO randomWalkParameters;


    //[SerializeField]
    //private TilemapVisualizer tilemapVisualizer;


    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPosition = RunRandomWalk();
        tilemapVisualizer.Clear();
        tilemapVisualizer.PointFoorTiles(floorPosition);
        //foreach(var position in floorPosition)
        //{
        //    Debug.Log(position);
        //}
    }

    protected override HashSet<Vector2Int> RunRandomWalk()
    {
        var currentPosition = startPosition;
        HashSet<Vector2Int> floorPosition = new HashSet<Vector2Int>();
        for (int i = 0;i < randomWalkParameters.interactions; i++)
        {
            var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPosition, randomWalkParameters.walkLength);
            floorPosition.UnionWith(path);
            if(randomWalkParameters.startRandomlyEachInteration)
            {
                currentPosition = floorPosition.ElementAt(Random.Range(0,floorPosition.Count));
            }
           
        }
        return floorPosition;

    }

}
