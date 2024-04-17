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
        HashSet<Vector2Int> floorPosition = RunRandomWalk(randomWalkParameters);
        tilemapVisualizer.Clear();
        tilemapVisualizer.PointFoorTiles(floorPosition);
        WallGenerator.CreateWalls(floorPosition, tilemapVisualizer);
        //foreach(var position in floorPosition)
        //{
        //    Debug.Log(position);
        //}
    }

    protected HashSet<Vector2Int> RunRandomWalk(SimpleRandomWalkSO parameters)
    {
        var currentPosition = startPosition;
        HashSet<Vector2Int> floorPosition = new HashSet<Vector2Int>();
        for (int i = 0;i < parameters.interactions; i++)
        {
            var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPosition, randomWalkParameters.walkLength);
            floorPosition.UnionWith(path);
            if(parameters.startRandomlyEachInteration)
            {
                currentPosition = floorPosition.ElementAt(Random.Range(0,floorPosition.Count));
            }
           
        }
        return floorPosition;

    }

}
