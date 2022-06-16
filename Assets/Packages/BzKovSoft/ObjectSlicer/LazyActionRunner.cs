using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace BzKovSoft.ObjectSlicer
{
	/// <summary>
	/// Base class for sliceable object
	/// </summary>
	[DisallowMultipleComponent]
	public class LazyActionRunner : MonoBehaviour
	{
		List<Action> _postponeActions;

		private void OnEnable()
		{
			_postponeActions = new List<Action>();
		}

        private void Start()
        {
			Rigidbody rb = GetComponent<Rigidbody>();
			rb.useGravity = true;
			rb.AddRelativeForce(Random.insideUnitSphere + transform.position * 2, ForceMode.Impulse);
			
			Destroy(gameObject, 0.5f);
		}

        public void RunLazyActions()
        {
			if (_postponeActions == null || _postponeActions.Count == 0)
				return;
			
			StartCoroutine(ProcessSlicePostponeActions(_postponeActions));
        }

		private IEnumerator ProcessSlicePostponeActions(List<Action> actions)
		{
			for (int i = 0; i < actions.Count; i++)
			{
				yield return null;
				var action = actions[i];
				action();
			}
			
			Destroy(this);
		}

        public void AddLazyAction(Action action)
        {
			if (_postponeActions == null)
			{
				action();
			}
			else
			{
	            _postponeActions.Add(action);
			}
        }
	}
}