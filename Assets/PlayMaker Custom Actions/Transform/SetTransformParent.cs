﻿// (c) Copyright HutongGames, LLC 2010-2015. All rights reserved.
//--- __ECO__ __ACTION__ ---//

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.GameObject)]
	[Tooltip("Sets the Parent of a Game Object. It uses the Transform.SetParent method")]
	public class SetTransformParent : FsmStateAction
	{
		[RequiredField]
		[Tooltip("The Game Object to parent.")]
		public FsmOwnerDefault gameObject;
		
		[Tooltip("The new parent for the Game Object.")]
		public FsmGameObject parent;
		
		[Tooltip("If true, the parent-relative position, scale and rotation is modified such that the object keeps the same world space position, rotation and scale as before.")]
		public FsmBool worldPositionStays;

		
		public override void Reset()
		{
			gameObject = null;
			parent = null;
			worldPositionStays = true;
		}
		
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			var _parent = parent.Value;
			Transform _parentTransform =null;

			if (_parent!=null)
			{
				_parentTransform = _parent.transform;
			}

			if (go != null)
			{
				go.transform.SetParent(_parentTransform,worldPositionStays.Value);
			}
			
			Finish();
		}
	}
}