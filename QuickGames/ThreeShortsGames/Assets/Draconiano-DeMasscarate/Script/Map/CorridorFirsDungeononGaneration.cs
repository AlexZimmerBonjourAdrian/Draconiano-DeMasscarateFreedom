using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    
    [SerializeField]
    [Range(0.1f, 1f)]
    private float roomPercent = 0.8f;

    private SimpleRandomWalkSO roomGenerationParameter;

    protected override void RunProceduralGeneration()
    {
        CorridorFirstGeneration();
    }

    private void CorridorFirstGeneration()
    {
        HashSet<Vector2Int> floorPosition = new HashSet<Vector2Int>();
        HashSet<Vector2Int> potentialRoomPositions = new HashSet<Vector2Int>();
        
        CreateCorridors(floorPosition, potentialRoomPositions);

        HashSet<Vector2Int> randomPosition = CreateRooms(potentialRoomPositions);

        floorPosition.UnionWith(randomPosition);

        tilemapVisualizer.PointFoorTiles(floorPosition);
        WallGenerator.CreateWalls(floorPosition, tilemapVisualizer);
    }

    private HashSet<Vector2Int> CreateRooms(HashSet<Vector2Int> potentialRoomPosition)
    {
        HashSet<Vector2Int> roomPositions = new HashSet<Vector2Int>();
        int roomToCreateCount = Mathf.RoundToInt(potentialRoomPosition.Count * roomPercent);

        List<Vector2Int> roomToCreate = potentialRoomPosition.OrderBy(x => Guid.NewGuid()).Take(roomToCreateCount).ToList();

        foreach (var roomPosition in roomToCreate)
        {
            var roomFloor = RunRandomWalk(randomWalkParameters, roomPosition);
            roomPositions.UnionWith(roomFloor);

        }
        return roomPositions;

    }
    private void CreateCorridors(HashSet<Vector2Int> floorPosition, HashSet<Vector2Int> potentialRoomPositions)
    {
        var currentPosition = startPosition;
        potentialRoomPositions.Add(currentPosition);
        for(int i = 0; i < corridorCount; i++)
        {
            var corridor = ProceduralGenerationAlgorithms.RandomWalkCorrido(currentPosition, corridorLenght);
            currentPosition = corridor[corridor.Count - 1];
            potentialRoomPositions.Add(currentPosition);
            floorPosition.UnionWith(corridor);

        }
    }
}
