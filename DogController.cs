using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rigid2D;
    float jampforce = 500.0f;

    void Start()
    {
        Application.targetFrameRate = 60;
        this.player = GameObject.Find("kaaiyuki_1");
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //移動
        transform.Translate(0.15f, 0, 0);

        //ジャンプ
        if (this.rigid2D.velocity.y == 0)
        {
            //乱数
            int rnd = Random.Range(1, 70);

            if (rnd == 1)
                this.rigid2D.AddForce(transform.up * this.jampforce);
        }

        //画面外で破棄
        if (transform.position.x > 12.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Destroy(gameObject);
    }
}
