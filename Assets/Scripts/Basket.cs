using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public Text scoreGT;
    void Start()
    {
        //ќтримуЇмо силку на ≥гровий обЇкт ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //ќтримати компонент Text з цього ≥грового обЇкту
        scoreGT = scoreGO.GetComponent<Text>();
        //ѕочаткове значенн€ дл€ бал≥в буде 0
        scoreGT.text = "0";
        
    }
    // Update is called once per frame
    void Update()
    {
        //ќтримали поточну позиц≥ю мишки на екран≥
        Vector3 mousePos2D = Input.mousePosition;
        //¬изначаЇмо на ск≥льки далеко в простор≥ 3D по ос≥ Z знаходитьс€ курсор
        mousePos2D.z=-Camera.main.transform.position.z;
        //ѕеретворюЇмо точку на двох вим≥рн≥й пролощин≥ у трьох вим≥рн≥ координа в гр≥
        Vector3 mousePos3D=Camera.main.ScreenToWorldPoint(mousePos2D);
        //ѕерем≥щаЇмо пошик вздовж ос≥ X в координатах X вказ≥вника микши
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    void OnCollisionEnter(Collision collision)
    {
        //ЎукаЇмо €блуко, €ке потрапило в кошик
        GameObject go = collision.gameObject;
        if (go.tag == "Apple")
        {
            Destroy(go);
            //ѕеретворюЇмо текст в ц≥ле число
            int score = int.Parse(scoreGT.text);
            //«б≥льшуЇмо очки за п≥ймане €блуко
            score += 100;
            //¬иводимо очки на екран
            scoreGT.text = score.ToString();
            if (score>HighScore.score)
            {
                HighScore.score = score;
            }
        }
        
    }
}
