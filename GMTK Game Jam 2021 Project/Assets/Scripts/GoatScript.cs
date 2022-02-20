using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatScript : MonoBehaviour
{
    public PlayerScript ps;

    private Rigidbody2D thisBody;

    private string type;

    void Start()
    {
        thisBody = gameObject.GetComponent<Rigidbody2D>();
        ps = GameObject.Find("Player Goat").GetComponent<PlayerScript>();

        type = this.gameObject.name;
        StartCoroutine(randomBleat());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(ps.goatNumber == 1)
            {
                ps.goatAdded(this.gameObject, type);
                Destroy(this.gameObject);
            }
        }
    }

    IEnumerator randomBleat()
    {
        float randomNum = Random.Range(12f, 25f);
        int randomBleatNum = Random.Range(1, 3);

        yield return new WaitForSeconds(randomNum);

        string bleatType = "bleat" + randomBleatNum;
        AudioManagerScript.instance.PlaySound(bleatType);

        StartCoroutine(randomBleat());
    }
}
