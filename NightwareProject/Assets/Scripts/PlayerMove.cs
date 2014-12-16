using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float speed = 1;
    private Animator anim;
    private int groundLayerIndex = -1;

	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
		//获取物体层级
		groundLayerIndex = LayerMask.GetMask("Ground");

	}
	
	// Update is called once per frame
	void Update () {
        //控制移动
//        float h = Input.GetAxis("Horizontal");
//        float v = Input.GetAxis("Vertical");
//
//        //transform.Translate(new Vector3(h, 0, v) * speed*Time.deltaTime);
//        rigidbody.MovePosition(transform.position + new Vector3(h, 0, v) * speed * Time.deltaTime);
//
//        //控制转向
//        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//        RaycastHit hitInfo;
//        if (Physics.Raycast(ray, out hitInfo, 200, groundLayerIndex)) {
//            Vector3 target = hitInfo.point;
//            target.y = transform.position.y;
//            transform.LookAt(target);
//        }
//
//        //控制动画
//        if (h != 0 || v != 0) {
//            anim.SetBool("Move", true);
//        } else {
//            anim.SetBool("Move", false);
//        }
	}
	/**注册方法*/
	void OnEnable(){
		EasyJoystick.On_JoystickMove += OnJoystickMove;
		EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;

	}
	/**消除方法*/
	void OnDisable(){
		EasyJoystick.On_JoystickMove -= OnJoystickMove;
		EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
	}
	/**移动*/
	void OnJoystickMove(MovingJoystick move){
		if (move.joystickName == "Myjoystick") {

			float joystickPositionX = move.joystickAxis.x;
			float joystickPositionY = move.joystickAxis.y;

			if(joystickPositionX!=0||joystickPositionY!=0){
				transform.LookAt( new  Vector3(transform.position.x + joystickPositionX, transform.position.y, transform.position.z + joystickPositionY)); 
				this.transform.Translate(Vector3.forward*Time.deltaTime*8);
				anim.SetBool("Move", true);
			}

		}
	}
	/**停止移动*/
	void OnJoystickMoveEnd(MovingJoystick move){
		if (move.joystickName == "Myjoystick") {
			anim.SetBool("Move", false);
			
		}
	}
}
