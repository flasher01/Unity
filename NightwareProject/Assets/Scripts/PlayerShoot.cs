using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

//    public float shootRate = 2;
    public float attack = 100;
//    private float timer = 0;
    private ParticleSystem partSystem;
    private LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
		partSystem = this.GetComponentInChildren<ParticleSystem>();
        lineRenderer = this.GetComponent<Renderer>() as LineRenderer;
	}
	
	// Update is called once per frame
	void Update () {
//        timer+=Time.deltaTime;
//        if (timer > 1 / shootRate) {
//            timer -= 1 / shootRate;
//            Shoot();
//        }
	}
    void Shoot() {
        GetComponent<Light>().enabled = true;
		partSystem.Play();
        this.lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, transform.position);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo)) {
            lineRenderer.SetPosition(1, hitInfo.point);
            if (hitInfo.collider.tag == Tags.enemy) {
                hitInfo.collider.GetComponent<EnemyHealth>().TakeDamage(attack,hitInfo.point);
            }

        } else {
            lineRenderer.SetPosition(1, transform.position + transform.forward * 100);
        }
        GetComponent<AudioSource>().Play();

        Invoke("Clear", 0.05f);
    }
	void OnEnable(){
		EasyButton.On_ButtonDown += ButtonDown;
	
	}
	void OnDisable(){
		EasyButton.On_ButtonDown -= ButtonDown;
	}
	void ButtonDown(string btnName){
		Shoot ();
	
	}
	void Clear() {
        GetComponent<Light>().enabled = false;
        lineRenderer.enabled = false;
    }
}
