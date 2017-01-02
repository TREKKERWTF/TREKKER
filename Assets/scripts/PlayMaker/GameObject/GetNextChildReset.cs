using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

[ActionCategory(ActionCategory.GameObject)]
public class GetNextChildReset : FsmStateAction
{

	// Code that runs on entering the state.
		[RequiredField]
		[Tooltip("The parent GameObject. Note, if GameObject changes, this action will reset and start again at the first child.")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the next child in a GameObject variable.")]
		public FsmGameObject storeNextChild;

		public FsmBool reset;

		[Tooltip("Event to send to get the next child.")]
		public FsmEvent loopEvent;

		[Tooltip("Event to send when there are no more children.")]
		public FsmEvent finishedEvent;

		public override void Reset()
		{
			gameObject = null;
			storeNextChild = null;
			loopEvent = null;
			finishedEvent = null;
			reset = null;
		}

		// cache the gameObject so we no if it changes
		private GameObject go;

		// increment a child index as we loop through children
		private int nextChildIndex;

		public override void OnEnter()
		{
			

			DoGetNextChild(Fsm.GetOwnerDefaultTarget(gameObject));

			Finish();
		}

		void DoGetNextChild(GameObject parent)
		{
			
			if (parent == null)
			{
				return;
			}

			// reset?
			if(reset.Value){
				nextChildIndex = 0;

			}
			if (go != parent)
			{
				go = parent;
				nextChildIndex = 0;
			}

			// no more children?
			// check first to avoid errors.

			if (nextChildIndex >= go.transform.childCount)
			{
				nextChildIndex = 0;
				Fsm.Event(finishedEvent);
				return;
			}

			// get next child

			storeNextChild.Value = parent.transform.GetChild(nextChildIndex).gameObject;


			// no more children?
			// check a second time to avoid process lock and possible infinite loop if the action is called again.
			// Practically, this enabled calling again this state and it will start again iterating from the first child.

			if (nextChildIndex >= go.transform.childCount)
			{
				nextChildIndex = 0;
				Fsm.Event(finishedEvent);
				return;
			}

			// iterate the next child
			nextChildIndex++;

			if (loopEvent != null)
			{
				Fsm.Event(loopEvent);
			}
		}


}

}
