using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class iaBoss : MonoBehaviour
{
   [Header("Pathfinding")]
    public Transform target;
    public float activateDistance = 50f;
    public float pathUpdateSeconds = 0.5f;

    [Header("Physics")]
    public float speed = 200f;
	public float nextWaypointDistance = 3f;
	public float attackdistance = 3f;
	
    public float speedx= 0f;
	
	[Header("Animacion")]
	private Animator animador;

    private Path path;
    private int currentWaypoint = 0;
	private float posx = 0;
    Seeker seeker;
    Rigidbody2D rb;

    public void Start() {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
		animador = GetComponent<Animator>();

        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);
    }
	
	public void Update() {
		posx = rb.position.x - target.position.x;
		if (posx > 0){
			transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } else if (posx <= 0) {
			transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
		}
		animador.SetFloat("correr", Mathf.Abs(rb.velocity.x));
        speedx=Mathf.Abs(rb.velocity.x);
	}

    private void FixedUpdate() {
        if (TargetInDistance() && AttackNotInDistance()) {
            PathFollow();
        }
    }

    private void UpdatePath() {
        if (TargetInDistance() && AttackNotInDistance() && seeker.IsDone()){
            seeker.StartPath(rb.position, target.transform.position, OnPathComplete);
        }
    }

    private void PathFollow(){
        if (path == null){
            return;
        }
		
		if (currentWaypoint >= path.vectorPath.Count){
            return;
        }
        
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.fixedDeltaTime;
        
		rb.velocity = new Vector2(direction.x * speed, 0);
		
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance){
            currentWaypoint++;
        }
    }

    private bool TargetInDistance() {
        return Vector2.Distance(transform.position, target.transform.position) < activateDistance;
    }
	
	private bool AttackNotInDistance() {
        return Vector2.Distance(transform.position, target.transform.position) > attackdistance;
    }

    private void OnPathComplete(Path p) {
        if (!p.error) {
            path = p;
            currentWaypoint = 0;
        }
    }
}