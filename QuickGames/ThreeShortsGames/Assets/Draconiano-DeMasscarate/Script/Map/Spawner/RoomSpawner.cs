using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public int OpeningDirection;
    //1 ---> need buttom door
    //2 ---> need top door
    //3 ---> need left door
    //4 ---> need right door

    private RoomTemplate templates;
    private int rand;
    private bool spawned = false;
    [SerializeField] 
    //private GameObject Room;
    
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("room").GetComponent<RoomTemplate>();
        Invoke("Spawn", 0.1f);
        //Room = GetComponentInParent<GameObject>();
        
    }

    public void Spawn()
    {
        if(spawned == false)
        { 
         switch (OpeningDirection)
        {
            case 1:
                //Need to spawn a room whith a bottom doors
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                break;
            //Need to spawn a room whith a Top door
            case 2:
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                break;
            case 3:
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                //Need to spawn a room whith a Left doors
                break;
            case 4:
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                //Need to spawn a room whith a bottom
                break;
            default:
                break; 
        }

            spawned = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.CompareTag("SpawnPointer") && other.GetComponent<RoomSpawner>().spawned == true)
        {
            Destroy(gameObject);
          
        }
        if(other.CompareTag("Rooms") && other.GetComponent<RoomSpawner>().spawned == true)
        {
            // Destroy(this.gameObject.GetComponentInParent<GameObject>().gameObject);
            spawned = true;
        }
        
        

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Rooms"))
        {
            spawned = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Rooms"))
        {
            spawned = false;
        }
    }
}
