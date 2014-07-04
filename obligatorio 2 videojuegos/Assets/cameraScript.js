var target : Transform;
var distance = 5.0;
var height = 4.0;
 
var rotationDamping = 3.0;
 
 
function LateUpdate () {
    if (!target)
        return;
       
    wantedRotationAngleSide = target.eulerAngles.y;
    currentRotationAngleSide = transform.eulerAngles.y;
   
    wantedRotationAngleUp = target.eulerAngles.x;
    currentRotationAngleUp = transform.eulerAngles.x;
   
    currentRotationAngleSide = Mathf.LerpAngle(currentRotationAngleSide, wantedRotationAngleSide, rotationDamping * Time.deltaTime);
   
    currentRotationAngleUp = Mathf.LerpAngle(currentRotationAngleUp, wantedRotationAngleUp, rotationDamping * Time.deltaTime);
   
    currentRotation = Quaternion.Euler(currentRotationAngleUp, currentRotationAngleSide, 0);
   
    transform.position = target.position;
    transform.position -= currentRotation * Vector3.forward * distance;
   
    transform.LookAt(target);
   
    transform.position += transform.up * height;
}