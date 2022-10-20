using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyBoss : MonoBehaviour {

	public float lifeBoss = 10;
	private bool isPlat;
	private bool isObstacle;
	private Transform fallCheck;
	private Transform wallCheck;
	public LayerMask turnLayerMask;
	private Rigidbody2D rb;

	private bool facingRight = true;
	
	public float speed = 5f;

	public bool isInvincible = false;
	private bool isHitted = false;
	public Animator animador;
	iaBoss sn;
	[SerializeField] Transform player;
	[SerializeField]private float distance;
	[SerializeField]public bool cooling;
	[SerializeField]private float nextattack;
	[SerializeField]public float ataqueElegido = -1;
	[SerializeField]private float attackDistance = 0;

	[SerializeField]public bool ataqueBloqueo = false;
	public float[] ataques;
	public float ataqueNum;	
	[SerializeField] Transform weapon;
	public shootBoss bulletb;
	public float damage = 2f;
	private bool shot=false;


	public GameObject portalfinalw;
	public GameObject portalfinal;
	
	public GameObject bossName;
	public GameObject bossHealth;
	bool activateBoss=false;
	public Slider lifeBossUI;
	 private void Start()
    {
        animador = GetComponent<Animator>();
        sn = gameObject.GetComponent<iaBoss>();  
		ataques = new float[4]; 
		GameObject go = GameObject.Find("bossWeapon");
        bulletb=go.gameObject.GetComponent<shootBoss>(); 
    }
	void Awake () {
		fallCheck = transform.Find("FallCheck");
		wallCheck = transform.Find("WallCheck");
		rb = GetComponent<Rigidbody2D>();
		
	}
	

	void Update()
    {
		lifeBossUI.value=lifeBoss;
		distance = Vector2.Distance(transform.position, player.transform.position);
		if(activateBoss==false && distance<=7){
			activateBoss=true;
			bossName.SetActive(true);
			bossHealth.SetActive(true);
		}
		
		
		if(!isHitted && lifeBoss>0){
			if(ataqueBloqueo == false)
			{		
				chooseAttack();
			}
			action();
		
		}
		
    }

	void chooseAttack(){

		ataqueElegido = Random.Range(1, 100);
		//ataqueElegido = 40;
		if(distance >=4){
			ataques[0]=10;
			ataques[1]=20;
			ataques[2]=60;
			ataques[3]=100;

			
		}else{
			ataques[0]=25;
			ataques[1]=50;
			ataques[2]=75;
			ataques[3]=100;
		}
		if(ataqueBloqueo==false){

			if(ataqueElegido <= ataques[0]){//ataque melee kick
				attackDistance = 0.1f;
				sn.attackdistance= attackDistance;
				ataqueBloqueo=true;
				ataqueNum = 1;
			
			}else if(ataqueElegido <= ataques[1]){// ataque melee rush
				attackDistance = 0.1f;
				sn.attackdistance= attackDistance;
				ataqueBloqueo=true;
				ataqueNum = 2;
			
			}else if (ataqueElegido <= ataques[2]){ //ataque range detenido
				attackDistance = 5f;
				sn.attackdistance= attackDistance;
				ataqueBloqueo=true;
				ataqueNum = 3;
			}else if(ataqueElegido <= ataques[3]){ //ataque range movimiento
				attackDistance = 1f;
				sn.attackdistance= attackDistance;
				ataqueBloqueo=true;
				ataqueNum = 4;
			}

		}
			

	}
	void action() {
		
		if(distance <= 2 && cooling == false && ataqueNum == 1){
			StartCoroutine(attackAnimaKick());
			

		}else if(distance <= 2 && cooling == false && ataqueNum == 2){
			
			StartCoroutine(attackAnimaTackle());
			
		
			
		}else if(distance <= 5 && cooling == false && ataqueNum == 3){
			
			StartCoroutine(attackAnimaRangeIdle());
			
		
			
		}else if(distance <= 2.5 && cooling == false && ataqueNum == 4){
			
			StartCoroutine(attackAnimaRangeRun());
			
		
			
		}

		
	}
	
	
	public IEnumerator attackAnimaRangeIdle(){
		
		animador.SetBool("Ataque1RangeIdle",true);
		yield return new WaitForSeconds(0.75f);
		
		if(shot==false && cooling == false){
				damage = 4f;
				bulletb.shoot();
				shot=true;
				
				
		}	
		
		yield return new WaitForSeconds(0.5f);
		
		animador.SetBool("Ataque1RangeIdle",false);
		
		if(cooling == false){
			shot=false;
			cooling=true;
		
			StartCoroutine(cooldown(2.5f));
		}
			
			

	}

	public IEnumerator attackAnimaRangeRun(){
		
		animador.SetBool("Ataque2RangeRun",true);
		yield return new WaitForSeconds(0.47f);
		
		if(shot==false && cooling == false){
				damage = 3f;
				bulletb.shoot();
				shot=true;
		}	
		
		yield return new WaitForSeconds(0.6f);
		
		animador.SetBool("Ataque2RangeRun",false);
		
		if(cooling == false){
			shot=false;
			cooling=true;
		
			StartCoroutine(cooldown(3f));
		}
			
			

	}

	public IEnumerator attackAnimaKick(){
		animador.SetBool("Ataque3Melee",true);	
		yield return new WaitForSeconds(1f);
		animador.SetBool("Ataque3Melee",false);
		if(cooling == false){
			cooling=true;
		
			StartCoroutine(cooldown(1.5f));
		}
			
			

	}


	public IEnumerator attackAnimaTackle(){
		animador.SetBool("Ataque4Tackle",true);	
		yield return new WaitForSeconds(2f);
		animador.SetBool("Ataque4Tackle",false);
		if(cooling == false){
			cooling=true;
		
			StartCoroutine(cooldown(2f));
		}
			
			

	}
	public IEnumerator cooldown(float time)
	{
		sn.attackdistance= 100f;
		yield return new WaitForSeconds(time);
		cooling = false;
		ataqueBloqueo = false;
		shot=false;
		damage = 2f;
		
	}
	// Update is called once per frame
	void FixedUpdate () {

		if (lifeBoss <= 0) {
			StartCoroutine(DestroyEnemy());
		}
		

	}

	
	void Flip (){
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void ApplyDamage(float damage) {
		if (!isInvincible) 
		{
			float direction = damage / Mathf.Abs(damage);
			damage = Mathf.Abs(damage);
			cooling = true;
			ataqueBloqueo = true;
			sn.attackdistance= 100;
			ataqueElegido=-1;
			animador.SetBool("Hit",true);
			lifeBoss -= damage;
			rb.velocity = Vector2.zero;
			rb.AddForce(new Vector2(direction * 500f, 1000f));
			StartCoroutine(HitTime());
			 
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		
		if (collision.gameObject.tag == "Player" &&  lifeBoss > 0  && collision.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Attacking"))
		{
			ApplyDamage(2f);
		}
		
		
		
	}
	

	IEnumerator HitTime()
	{
		isHitted = true;
		isInvincible = true;
		attackDistance = sn.attackdistance;
		if(lifeBoss > 0){
			yield return new WaitForSeconds(2f);
			rb.velocity = Vector2.zero;
			isHitted = false;
			isInvincible = false;
			animador.SetBool("Hit",false);
			cooling = false;
			ataqueBloqueo = false;
			shot=false;
			damage = 2f;
		
		}else{
			yield return new WaitForSeconds(1f);
			animador.SetBool("Hit",false);
			StartCoroutine(DestroyEnemy());
		}
			
	}

	IEnumerator DestroyEnemy()
	{
		animador.SetTrigger("Dead");
		sn.enabled=false;
		
		CapsuleCollider2D capsule = GetComponent<CapsuleCollider2D>();
		capsule.size = new Vector2(0.5f, 0.55f);
		capsule.offset = new Vector2(-0.1f, -0.23f);
		capsule.direction = CapsuleDirection2D.Horizontal;
		yield return new WaitForSeconds(0.25f);
		rb.velocity = new Vector2(0, rb.velocity.y);
		yield return new WaitForSeconds(3f);
	 	sn.enabled=false;
		Rigidbody2D rigid=GetComponent<Rigidbody2D>();
		rigid.constraints = RigidbodyConstraints2D.FreezeAll;
		portalfinalw.SetActive(true);
		Animator portalfinalanim=portalfinal.gameObject.GetComponent<Animator>();
		portalfinalanim.enabled=true;
		bossName.SetActive(false);
		bossHealth.SetActive(false); 
		
	}
}