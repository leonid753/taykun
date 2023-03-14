using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    GameObject player;
    bool dead=false;
    [SerializeField] Animator anim;
    bool collide=false;
    [SerializeField] Text cointext;
    int coin=0;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMove>().gameObject; //Находим игрока
        cointext.text = "Coins: " + coin.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < 100) //100 - радиус обнаружения
            {
                transform.LookAt(player.transform);
                GetComponent<CharacterController>().Move(transform.forward * Time.deltaTime * 2);
                anim.SetBool("walk",true);
                
            }
            else if (Vector3.Distance(transform.position, player.transform.position) < 7)
            {
                transform.LookAt(player.transform);
                GetComponent<CharacterController>().Move(transform.forward * Time.deltaTime * 2);
                anim.SetBool("walk",false);
                anim.SetBool("attack",true);
            }
            else if (Vector3.Distance(transform.position, player.transform.position) >7)
            {
                transform.LookAt(player.transform);
                GetComponent<CharacterController>().Move(transform.forward * Time.deltaTime * 2);
                anim.SetBool("attack",false);
            }
            else if (Vector3.Distance(transform.position, player.transform.position) >100)
            {
                anim.SetBool("walk",false);
            } 
            if (collide) 
            {
                if (Input.GetMouseButtonDown(0))
                {
                    dead=true;
                    anim.SetBool("death",true);
                    coin+=1;
                    cointext.text = "Coins: " + coin.ToString();

                }
            } 
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag=="Sword")
        {
            collide = true;
        }
        else
        {
            collide = false;
        }
    }
}