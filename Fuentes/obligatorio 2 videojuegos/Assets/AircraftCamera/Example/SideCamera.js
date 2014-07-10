/*
* Copyright © 2013 Make Fire Interactive.
*
* WWW: 		http://make-fire.com
* E-Mail:	fire@make-fire.com
*
*/  

#pragma strict
var target : Transform;
var distance : float = 70;

function Start () {

}

function LateUpdate () {
	transform.position = target.position+Vector3.right*distance;
}