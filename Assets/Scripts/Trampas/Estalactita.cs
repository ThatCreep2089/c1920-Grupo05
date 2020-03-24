using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estalactita : MonoBehaviour {

	#region Variables
	Transform estalactia;
	Rigidbody2D estalact;
	Animator animC;
	bool targetIsIn = false;

	#endregion

	#region Unity Methods
    void Awake()
    {
		estalactia = transform.parent;
		estalact = GetComponentInParent<Rigidbody2D>();
		animC = GetComponentInParent<Animator>();
	}

    void Update()
    {
		if (targetIsIn)
			estalact.isKinematic = false;
    }
	#endregion

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.GetComponentInChildren<PlayerMovement>() != null)
			targetIsIn = animC.enabled = true; //Esto no sabia que se podria hacer.
	}

	#region Personal Methods
	#endregion

}
