/*
* Copyright © 2013 Make Fire Interactive.
*
* WWW: 		http://make-fire.com
* E-Mail:	fire@make-fire.com
*
*/  

#pragma strict

var wheel : Transform;

function OnGUI () {
	if (!animation.isPlaying)
	{
		if (GUI.Button(Rect(Screen.width/2-100,Screen.height/2-50,200,100),"Start flight"))
		{
			animation.Play();
			if (wheel)
				Destroy(wheel.gameObject);
		}
	}
}
