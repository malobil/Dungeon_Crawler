﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scriptraycast : MonoBehaviour {
{
		void FixedUpdate()
		{
			RaycastHit hit;

			if (Physics.Raycast(transform.position, -Vector3.up, out hit, 100.0f))
				print("Found an object - distance: " + hit.distance);
		}
}
