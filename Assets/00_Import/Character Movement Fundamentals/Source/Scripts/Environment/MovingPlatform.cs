using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CMF
{
	//This script moves a rigidbody along a set of waypoints;
	//It also moves any controllers on top along with it;
	public class MovingPlatform : MonoBehaviour {

		//Movement speed;
		public float movementSpeed = 10f;
		public bool Lift;
		public bool OnlyUp;
		public AudioClip Movement;
		public AudioSource Source;

		//Check to reverse order of waypoints;
		public bool reverseDirection = false;

		//Wait time after reaching a waypoint;
		public float waitTime = 1f;

		//This boolean is used to stop movement while the platform is waiting;
		private bool isWaiting = false;

		//References to attached components;
		Rigidbody r;
		TriggerArea triggerArea;

		//List of transforms used as waypoints;
		public List<Transform> waypoints = new List<Transform>();
		int currentWaypointIndex = 0;
		Transform currentWaypoint;

		//Start;
		void Start () {
			
			Source = GetComponent<AudioSource>();
			//Get references to components;
			r = GetComponent<Rigidbody>();
			triggerArea = GetComponentInChildren<TriggerArea>();

			//Disable gravity, freeze rotation of rigidbody and set to kinematic;
			r.freezeRotation = true;
			r.useGravity = false;
			r.isKinematic = true;

			//Check if any waypoints have been assigned and if not, throw a warning;
			if(waypoints.Count <= 0){
				Debug.LogWarning("No waypoints have been assigned to 'MovingPlatform'!");
			} else {
				//Set first waypoint;
				currentWaypoint = waypoints[currentWaypointIndex];
			}

			//Start coroutines;
			StartCoroutine(WaitRoutine());
			StartCoroutine(LateFixedUpdate());
		}

		void Update()
		{
			if(GameObject.Find("CanvasPause").GetComponent<PauseMenu>().GameIsPaused == false)
			{
				Source.Play(0);
			}
			else
			{
				Source.Pause();
			}
		}

		//This coroutine ensures that platform movement always occurs after Fixed Update;
		IEnumerator LateFixedUpdate()
		{
			WaitForFixedUpdate _instruction = new WaitForFixedUpdate();
			while(true)
			{
				yield return _instruction;

				if(Lift == true)
				{
					Source.PlayOneShot(Movement, 0.25F);
					MovePlatform();
				}
			}
		}

		void MovePlatform () {

			//If no waypoints have been assigned, return;
			if(waypoints.Count <= 0)
				return;

			if(isWaiting)
				return;

			//Calculate a vector to the current waypoint;
			Vector3 _toCurrentWaypoint = currentWaypoint.position - transform.position;

			//Get normalized movement direction;
			Vector3 _movement = _toCurrentWaypoint.normalized;

			//Get movement for this frame;
			_movement *= movementSpeed * Time.deltaTime;

			//If the remaining distance to the next waypoint is smaller than this frame's movement, move directly to next waypoint;
			//Else, move toward next waypoint;
			if(_movement.magnitude >= _toCurrentWaypoint.magnitude || _movement.magnitude == 0f)
			{
				r.transform.position = currentWaypoint.position;
				UpdateWaypoint();
			}
			else
			{
				r.transform.position += _movement;
			}

			if(triggerArea == null)
				return;

			//Move all controllrs on top of the platform the same distance;

			for(int i = 0; i < triggerArea.rigidbodiesInTriggerArea.Count; i++) 
			{
				triggerArea.rigidbodiesInTriggerArea[i].MovePosition(triggerArea.rigidbodiesInTriggerArea[i].position + _movement);
			}
		}

		//This function is called after the current waypoint has been reached;
		//The next waypoint is chosen from the list of waypoints;
		private void UpdateWaypoint()
		{
			if(reverseDirection)
				currentWaypointIndex --;
			else
				currentWaypointIndex ++;

			//If end of list has been reached, reset index;
			if(currentWaypointIndex >= waypoints.Count && OnlyUp == false)
			{
				currentWaypointIndex = 0;
			}
			else
			{
				Source.Stop();
			}
				

			if(currentWaypointIndex < 0 && OnlyUp == false)
			{
				currentWaypointIndex = waypoints.Count - 1;
			}
			else
			{
				Source.Stop();
			}


			currentWaypoint = waypoints[currentWaypointIndex];

			//Stop platform movement;
			isWaiting = true;
		}

		//Coroutine that keeps track of the wait time and sets 'isWaiting' back to 'false', after 'waitTime' has passed;
		IEnumerator WaitRoutine()
		{
			WaitForSeconds _waitInstruction = new WaitForSeconds(waitTime);

			while(true)
			{
				if(isWaiting)
				{
					yield return _waitInstruction;
					isWaiting = false;
				}

				yield return null;
			}
		}	
	}
}