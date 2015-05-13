using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class FollowPath : MonoBehaviour 
{
	public enum FollowType
	{
		MoveTowards,
		Lerp
	}

	public FollowType Type=FollowType.MoveTowards;
	public PathDefinition Path;
	public float velocidadPlat=1;
	public float MaxDistanceToGoal= .1f;

	private IEnumerator<Transform> _currentPunto;

	public void Start()
	{
		if (Path == null) 
		{
			Debug.LogError("Path cannot be null", gameObject);
			return;
		}

		_currentPunto = Path.GetPathEnumerator ();
		_currentPunto.MoveNext ();

		if (_currentPunto.Current == null)
			return;

		transform.position = _currentPunto.Current.position;
	}

	public void Update()
	{
		if (_currentPunto == null || _currentPunto.Current == null)
			return;

		if (Type == FollowType.MoveTowards)
			transform.position = Vector3.MoveTowards (transform.position, _currentPunto.Current.position, Time.deltaTime * velocidadPlat);

		else if (Type == FollowType.Lerp)
			transform.position = Vector3.Lerp (transform.position, _currentPunto.Current.position, Time.deltaTime * velocidadPlat);

		var distanceSquared = (transform.position - _currentPunto.Current.position).sqrMagnitude;


		if (distanceSquared < MaxDistanceToGoal * MaxDistanceToGoal)
			_currentPunto.MoveNext();
		
	}
}
