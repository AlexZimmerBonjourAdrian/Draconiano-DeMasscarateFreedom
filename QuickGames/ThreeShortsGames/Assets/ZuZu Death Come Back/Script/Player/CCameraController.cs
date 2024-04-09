using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCameraController : MonoBehaviour
{
    private GameObject _Player;
    private float _Speed = 0.4f;
    private Vector2 _Move = Vector2.zero;
    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        if (_Player == null)
        {
            _Player = GameObject.FindGameObjectWithTag("Player");

            //throw new ArgumentNullException("El valor no puede ser null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        transform.position = _Player.transform.position;

    }
}
