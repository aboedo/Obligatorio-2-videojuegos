#pragma strict

var rotateSpeed = 100000000.0;
 
function Update () {
   transform.Rotate(Input.GetAxis("RightStickHorizontal") * transform.up * Time.deltaTime * -rotateSpeed);
   transform.Rotate(Input.GetAxis("RightStickVertical") * transform.right * Time.deltaTime * -rotateSpeed);
}