using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

[ActionCategory(ActionCategory.Math)]
public class FloatMoveTowardsStep : FsmStateAction
{
		[RequiredField]
		[Tooltip("Interpolate from this value.")]
		public FsmFloat fromFloat;

		[RequiredField]
		[Tooltip("Interpolate to this value.")]
		public FsmFloat toFloat;

		[RequiredField]
		[Tooltip("move step")]
		public FsmFloat step;
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the current value in a float variable.")]
		public FsmFloat storeResult;
		public override void Reset ()
		{
			fromFloat = null;
			toFloat = null;
			step = 1.0f;
			storeResult = null;
		}
	// Code that runs on entering the state.
	public override void OnEnter()
	{
			float v = Mathf.MoveTowards (fromFloat.Value, toFloat.Value, step.Value);
			storeResult.Value = v;
		Finish();
	}


}

}
