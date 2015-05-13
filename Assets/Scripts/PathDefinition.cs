using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PathDefinition : MonoBehaviour
{

	public Transform[] Puntos;

	public IEnumerator<Transform> GetPathEnumerator()
	{
		if (Puntos == null || Puntos.Length < 1) 
			yield break;

		var direction = 1;
		var index = 0;

		while (true) 
		{
			yield return Puntos[index];

			if(Puntos.Length==1)
				continue;

			if(index <=0)
				direction=1;
			else if(index >= Puntos.Length - 1)
				direction = -1;

			index= index+direction;
		}
	}

	public void OnDrawGizmos()
	{
		if (Puntos ==null || Puntos.Length < 2)
			return;
		for (var i=1; i < Puntos.Length; i++)
		{
			Gizmos.DrawLine (Puntos[i-1].position, Puntos[i].position);
		}
	}
}
