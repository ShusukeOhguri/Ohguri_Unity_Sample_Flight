var plane: Transform;
var Trail : ParticleSystem;
var Emission : float;
function Update(){
var spd = plane.GetComponent.<Rigidbody>().velocity.magnitude;
Trail.emissionRate=spd*10;
}

//using UnityEngine;
//using System.Collections;
//
//public class MYCLASSNAME : MonoBehaviour {
//Transform plane;
//ParticleSystem Trail;
//float Emission;
//void  Update (){
//FIXME_VAR_TYPE spd= plane.GetComponent.<Rigidbody>().velocity.magnitude;
//Trail.emissionRate=spd*10;
//}
//}