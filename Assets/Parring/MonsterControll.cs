using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControll : MonoBehaviour
{
    Rigidbody2D rigid;
    internal int nextMove;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Think();
    }

    void FixedUpdate() 
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);    
        
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove , rigid.position.y);

        Debug.DrawRay(frontVec,Vector3.down,new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1,LayerMask.GetMask("Platform"));
        if (rayHit.collider == null)
        {
            nextMove *= -1;
        }
    }

    void Think()
    {
        nextMove = Random.Range(-1,2);
        if (nextMove <0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // 왼쪽 바라보기
        }
        else if (nextMove >0)
        {
            transform.localScale = new Vector3(1, 1, 1); // 오른쪽 바라보기
        }
        Invoke("Think", 5);

    }
}