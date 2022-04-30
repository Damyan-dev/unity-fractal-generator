using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RecursionStochastic : MonoBehaviour
{
        [SerializeField]
        // Sets the amount of times branches will recurse;
        // Values are set in the Unity editor;
        private int recursionBranches = 0;
        // Sets how jittery the branch rotations will be;
        // Values are set in the Unity editor;
        [SerializeField] 
        private float recursionTwist = 0;
        
        // Sets the size of the recursed branches;
        private float recursionScaling = 0;
        // Sets how many times the recursed branches will split;
        private int recursionSplit = 0;
        // Sets the angle of the recursed branches;
        private float recursionAngle = 0;

       private void Start ()
       {
	        recursionSplit = Random.Range(1, 4);
	        recursionScaling = Random.Range((float) 0.555,(float) 0.888);
	        recursionAngle = Random.Range(20, 65);
	        // Begins counting down the value of each recurse branch;
                recursionBranches--;
                // Starts a loop that lets you instantiate the child object multiple times
                // and creates an index of each newly created clone;
                for (var i = 0; i < recursionSplit; ++i)
                {
	            if (recursionBranches <= 0) continue;
	            // Creates clones of the parent object;
	            GameObject clone = Instantiate(gameObject); 
	            var cloneRecursion = clone.GetComponent<RecursionStochastic>();
	            // Sets the size of the cloned instances;
	            cloneRecursion.transform.localScale *= recursionScaling;
	            // Progressively moves each cloned instance upwards;
	            cloneRecursion.transform.position += transform.up * transform.localScale.y; 
	            // Sets the rotation of the based on the angle set in the editor;
	            cloneRecursion.transform.rotation *= Quaternion.Euler(recursionAngle * ((i * 2) - 1), 0, 0);
                }
    	}

       // Rotates each individual branch;
       private void FixedUpdate()
       {
	       transform.Rotate(0f, Random.Range(-recursionTwist, recursionTwist), 0f);
       }
}
