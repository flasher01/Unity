using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public float hp = 100;
    private Animator anim;
    private NavMeshAgent agent;
    private EnemyMove move;
    private CapsuleCollider capsuleCollider;
    private ParticleSystem partSystem;
    public AudioClip dealthClip;
    private EnemyAttack enemyAttack;

    void Awake() {
        anim = this.GetComponent<Animator>();
        agent = this.GetComponent<NavMeshAgent>();
        move = this.GetComponent<EnemyMove>();
        capsuleCollider = this.GetComponent<CapsuleCollider>();
        partSystem = this.GetComponentInChildren<ParticleSystem>();
        enemyAttack = this.GetComponentInChildren<EnemyAttack>();
    }

    void Update() {
        if (this.hp <= 0) {
            transform.Translate(Vector3.down * Time.deltaTime * 0.5f);
            if (transform.position.y <= -10)
                Destroy(this.gameObject);
        }
    }


    public void TakeDamage(float damage,Vector3 hitPoint) {
        if (this.hp <= 0) return;
        GetComponent<AudioSource>().Play();
        partSystem.transform.position = hitPoint;
        partSystem.Play();
        this.hp -= damage;
        if (this.hp <= 0) {
            Dead();
        }
    }

    void Dead() {
        anim.SetBool("Dead", true);
        agent.enabled = false;
        move.enabled = false;
        capsuleCollider.enabled = false;
        AudioSource.PlayClipAtPoint(dealthClip, transform.position,0.5f);
        enemyAttack.enabled = false;
    }

}
