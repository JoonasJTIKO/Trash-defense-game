using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace towerdefense
{
    public class SelectionSystem : MonoBehaviour
    {
		private static SelectionSystem current;
		public static SelectionSystem Current
		{
			get { return current; }
		}

		private Selectable selected;

		public Selectable Selected
		{
			get { return selected; }
			set
			{
				selected = value;

				if (selected != null)
				{
					Debug.Log("selected");
				}
				else
				{
					Debug.Log("Selection cleared");
				}
			}
		}

		private void Awake()
		{
			current = this; 
		}
    }
}
