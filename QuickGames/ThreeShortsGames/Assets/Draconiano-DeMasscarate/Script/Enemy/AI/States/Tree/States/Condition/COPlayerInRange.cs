using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class COPlayerInRange : CEnemyCondition
{
	[SerializeField]
    private bool IsCan;
    public override TaskStatus OnUpdate()
	{
		return IsCan == true ?  TaskStatus.Success : TaskStatus.Failure;
	}
}