using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public  static class ProceduralGenerationAlgorithms 
{
 
    public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPointer,int WalkLenght)
    {
         HashSet<Vector2Int> path = new HashSet<Vector2Int>();

        path.Add(startPointer);
        var previousPosition = startPointer;

       for (int i =0; i< WalkLenght;i++)
        {
            var newPosition = previousPosition + Direction2D.GetRandomCardinalDirection();
            path.Add(newPosition);
            previousPosition = newPosition;
        }
       return path;
    }
    public static List<Vector2Int> RandomWalkCorrido(Vector2Int startPosition, int corridorLength)
    {
        List<Vector2Int> corridor = new List<Vector2Int>();
        var direction = Direction2D.GetRandomCardinalDirection();
        var currentPosition = startPosition;
        corridor.Add(currentPosition);

        for(int i = 0; i < corridorLength; i++)
        {
            currentPosition += direction;
            corridor.Add(currentPosition);
        }
        return corridor;
    }
}

public static class Direction2D
{
    public static List<Vector2Int> cardinalDirectionsList = new List<Vector2Int>
   {
    new Vector2Int(0,1), //UP
    new Vector2Int(1,0), //RIGHT
    new Vector2Int(0,-1),//DOWN
    new Vector2Int(-1,0) //LEFT
   };

    public static Vector2Int GetRandomCardinalDirection()
    { 
        return cardinalDirectionsList[Random.Range(0,cardinalDirectionsList.Count)];
    }
}
