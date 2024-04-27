using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplate : MonoBehaviour
{

    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    [SerializeField] 
    public GameObject layer;

    private void Start()
    {
        layer = GameObject.FindGameObjectWithTag("Grid");
    }

    public GameObject GetLayer()
    {  return layer; }
}
