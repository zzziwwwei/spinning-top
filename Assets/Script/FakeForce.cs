using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeForce : MonoBehaviour
{
    // Start is called before the first frame update
    public bool spinning = false;
    public bool moveing = false;
    public bool controling = false;
    public bool hitting = false;
    public bool shaftmoveing = false;
    public bool deathing = false;
    public bool playerDeath = false;
    public float x;
    public float y;
    public float a;
    public float b;
    public float rotateSpeed;
    public float battleRange;
    public float inputA;
    public float inputB;
    public float inputRotateSpeed;
    public float hitSpeed;

    public bool loss;
    public float rotateSpeed_byhit = 1f;
    public GameObject centerOfPoint;
    public Vector3 Position;
    public GameObject hitTarget;
    private void Start()
    {
        spinning = true;
        moveing = true;
        controling = true;
        shaftmoveing = true;
        StartCoroutine(Spin());
        StartCoroutine(Move());
        StartCoroutine(Control());
        StartCoroutine(ShaftMove());
    }
    public void Hit()
    {
        if (hitting == false)
        {
            StartCoroutine(Hitting());
            rotateSpeed_byhit += 0.1f;
        }
    }
    public void HitWall()
    {
        hitting = false;
    }
    IEnumerator Spin()
    {
        while (spinning)
        {
            this.transform.GetChild(0).Rotate(0, rotateSpeed*1.2f, 0);
            yield return null;
        }
    }
    IEnumerator Move()
    {
        float speed = Random.Range(1.5f, 2.5f);
        while (moveing)
        {
            
            x = a * Mathf.Cos(Time.time * speed) + this.transform.parent.position.x;
            y = b * Mathf.Sin(Time.time * speed) + this.transform.parent.position.z;
            if (deathing)
            {
                this.transform.position = new Vector3(x, Mathf.Lerp(0, -0.5f, Time.time * 0.1f * 1 / rotateSpeed), y);
            }
            else
            {
                this.transform.transform.position = new Vector3(x, 0, y); this.transform.transform.position = new Vector3(x, 0, y);
            }
            yield return null;
        }
        yield return null;
    }
    IEnumerator Control()
    {
        while (controling)
        {
            rotateSpeed = Mathf.Lerp(inputRotateSpeed, 0, Time.time * 0.01f * rotateSpeed_byhit);
            a = Mathf.Lerp(inputA, 0, Time.time * 0.009f*(rotateSpeed_byhit));
            b = Mathf.Lerp(inputB, 0, Time.time * 0.009f*(rotateSpeed_byhit));

            if (rotateSpeed < 10 && deathing == false)
            {
                Debug.Log(200);
                deathing = true;
                StartCoroutine(Death());
            }
            yield return null;
        }
    }
    IEnumerator Hitting()
    {
        hitting = true;
        float distantMax = 15 * (rotateSpeed / inputRotateSpeed);
        if (distantMax < 1)
        {
            distantMax = 1;
        }
        Vector3 dir = (hitTarget.transform.position - this.transform.position).normalized * distantMax;
        Vector3 lastPosition = this.transform.parent.position;
        while (hitting)
        {
            this.transform.parent.position = Vector3.Lerp(this.transform.parent.position, lastPosition - dir, 0.05f);
            if (Mathf.Sqrt(Mathf.Pow((Mathf.Abs((lastPosition - dir).x - this.transform.parent.position.x)), 2) +
             Mathf.Pow((Mathf.Abs((lastPosition - dir).z - this.transform.parent.position.z)), 2)) < 1f)
                break;
            yield return null;
        }
        hitting = false;
        yield return null;
    }
    IEnumerator ShaftMove()
    {
        Vector3 lastPos = this.transform.parent.position;
        float t = 0;
        float speed = 0;
        while (shaftmoveing)
        {
            lastPos = this.transform.parent.position;
            t = 0;
            while (!(transform.parent.position == centerOfPoint.transform.position) && !hitting)
            {
                speed = Mathf.Lerp(.1f, .5f, t);
                this.transform.parent.position = Vector3.Lerp(lastPos, centerOfPoint.transform.position, t * speed);
                t += Time.deltaTime;
                yield return null;
            }
            yield return null;
        }
        yield return null;
    }
    IEnumerator Death()
    {
        while (deathing)
        {
            this.transform.GetChild(0).GetChild(0).localRotation = Quaternion.Euler(Mathf.Lerp(0, 40, Time.time * 0.1f * 1 / rotateSpeed), 0f, 0f);

            if (rotateSpeed < 2)
            {
                loss = true;
                playerDeath = true;
                Destroy(this.transform.GetComponent<FakeForce>());
            }
            yield return null;
        }
    }

}
