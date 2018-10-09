using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAttackRange : MonoBehaviour
{
    public bool InRangeToAttack;
    public List<Collider> CollisionList = new List<Collider>();
    public List<GameObject> ObjectAttackList = new List<GameObject>();
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    void OntriggerEnter(Collider collided)
    {

    }
    void OnTriggerStay(Collider collided)
    {

            if ((gameObject.transform.parent.tag == "Enemy" && collided.gameObject.tag == "Player") || (gameObject.transform.parent.tag == "Player" && collided.gameObject.tag == "Enemy"))
        {
            InRangeToAttack = true;
        }
        if (ColliderListCheck(collided) == true)
        {
           // Debug.Log("Parent Tag " + collided.transform.parent.name);
            if (gameObject.transform.parent.tag == "Enemy" && collided.gameObject.tag == "Player")
            {
                if(collided is CapsuleCollider)
                {
                        CollisionList.Add(collided);
                    ObjectAttackList.Add(collided.gameObject);
                }
            }
            if (gameObject.transform.parent.tag == "Player")
            {
                
                int sdf = 34;
                if (collided.GetComponent<CheckAttackRange>() != null)
                {
                    CollisionList.Add(collided);
                    ObjectAttackList.Add(collided.gameObject.transform.parent.gameObject);
                }
            }
        }
    }
    void OnTriggerExit(Collider collided)
    {
        if ((gameObject.transform.parent.tag == "Enemy" && collided.gameObject.tag == "Player") || (gameObject.transform.parent.tag == "Player" && collided.gameObject.tag == "Enemy"))
        {
            InRangeToAttack = false;
        }
        CollisionList.Remove(collided);
        ObjectAttackList.Remove(collided.gameObject.transform.parent.gameObject);
    }
    bool ColliderListCheck(Collider collided)
    {
        foreach (Collider collider in CollisionList)
        {
            if (collider.gameObject == collided.gameObject)
            {
                return false;
            }
        }
        return true;
    }
}
