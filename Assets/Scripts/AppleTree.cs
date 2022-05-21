using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    //силка на обЇкт
    public GameObject applePrefab;
    //швидк≥сть
    public float speed = 1f;
    //меж≥ перем≥щенн€ обЇкта
    public float leftAndRightEnge = 10f;
    //≥мов≥рн≥сть зм≥ни напр€мку руху обЇкта
    public float chanceToChangeDirections = 0.1f;
    //„астока зкиданн€ €блук ≥з дерева
    public float secondsBetweenAppleDrops = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2);
    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x<-leftAndRightEnge)
        {
            speed=Mathf.Abs(speed); //рух в право
        }
        else if(pos.x > leftAndRightEnge)
        {
            speed = -Mathf.Abs(speed); //рух в л≥во
        }
    }
    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
