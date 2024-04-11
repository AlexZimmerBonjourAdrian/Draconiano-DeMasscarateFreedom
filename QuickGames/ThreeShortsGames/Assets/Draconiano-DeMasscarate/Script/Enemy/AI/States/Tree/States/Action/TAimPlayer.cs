using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Core.AI;
using UnityEditor;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;

public class TAimPlayer : CEnemyAction
{
    BehaviorTree _BehaviorTree;
    SharedVariable _Variable;

    public override void OnStart()
	{
        if (_Player == null)
        {
            _Player = GameObject.FindGameObjectWithTag("Player");

            //throw new ArgumentNullException("El valor no puede ser null");
        }
        
        _BehaviorTree = GetComponent<BehaviorTree>();
        _Variable = _BehaviorTree.GetVariable("RootWeapon");
        _ArmWeapon = (GameObject)_Variable.GetValue();





    }
	
	public void AimPlayer()
	{
		Vector2 dirction = _Player.transform.position - transform.position;
		Vector2 currentDirection = Vector2.SmoothDamp(transform.forward, dirction, ref currentVelocity, 0.0005f);
		Quaternion rotation = Quaternion.LookRotation(currentDirection, Vector2.up);
		
	}

	public override TaskStatus OnUpdate()
    {
        if (_Player != null)
        {
            AimPlayer();
            return TaskStatus.Running;

        }
        else
        {
            return TaskStatus.Failure;
        }
     
	}
}