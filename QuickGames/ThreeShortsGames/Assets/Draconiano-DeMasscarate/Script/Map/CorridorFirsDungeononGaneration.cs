using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CorridorFirsDungeononGaneration : SimpleRandomWalkDungeonGenerator
{
    //[SerializeField]
    //protected TilemapVisualizer tilemapVisualizer = null;

    //[SerializeField]
    //protected Vector2Int startPostition = Vector2Int.zero;



    //public void GenerateDungeon()
    //{
    //    tilemapVisualizer.Clear();
    //    RunProceduralGeneration();
    //}

    [SerializeField]
    private int corridorLenght = 14, corridorCount = 5;

    [Range(0.1f, 1f)]
    private float roomPercent;

    [SerializeField]
    public SimpleRandomWalkSO roomGenerationParameter;

    protected override void RunProceduralGeneration()
    {
        CorridorFirstGeneration();
    }

    private void CorridorFirstGeneration()
    {
        HashSet<Vector2Int> floorPosition = new HashSet<Vector2Int>();
        CreateCorridors(floorPosition);
        tilemapVisualizer.PointFoorTiles(floorPosition);
        WallGenerator.CreateWalls(floorPosition, tilemapVisualizer);
    }

    private void CreateCorridors(HashSet<Vector2Int> floorPosition)
    {
        var currentPosition = startPosition;
        for(int i = 0; i < corridorCount; i++)
        {
            var corridor = ProceduralGenerationAlgorithms.RandomWalkCorrido(currentPosition, corridorLenght);
            currentPosition = corridor[corridor.Count - 1];
            floorPosition.UnionWith(corridor);

        }
    }
}
