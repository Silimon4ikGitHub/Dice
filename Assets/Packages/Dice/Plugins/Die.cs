
using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour {

	public int value = 0;
    public Die myDice;
    public ScoreText scoreText;

    protected Vector3 localHitNormalized;
    protected Vector3 TestVector;

    protected float validMargin = 0.45F;

    private void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<ScoreText>();
    }

    public bool rolling
    {
        get
        {
            return true;

            // For show count on stop - 
            //return !(GetComponent<Rigidbody>().velocity.sqrMagnitude < 0.1F && GetComponent<Rigidbody>().angularVelocity.sqrMagnitude < 0.1F);
        }
    }

    protected bool localHit
    {
        get
        {
            Ray ray = new Ray(transform.position + (new Vector3(0, 2, 0) * transform.localScale.magnitude), Vector3.up * -1);
            RaycastHit hit = new RaycastHit();

                if (GetComponent<Collider>().Raycast(ray, out hit, 3 * transform.localScale.magnitude))
                {
                    localHitNormalized = transform.InverseTransformPoint(hit.point.x, hit.point.y, hit.point.z).normalized;
                    return true;
                }

            return false;
        }
    }

    private int GetValue()
    {
        value = 0;
        float delta = 1;

        int side = 1;
        Vector3 testHitVector;

        do
        {
            testHitVector = HitVector(side);
            TestVector = testHitVector;
            if (testHitVector != Vector3.zero)
            {
                if (valid(localHitNormalized.x, testHitVector.x) &&
                    valid(localHitNormalized.y, testHitVector.y) &&
                    valid(localHitNormalized.z, testHitVector.z))
                {

                    float nDelta = Mathf.Abs(localHitNormalized.x - testHitVector.x) + Mathf.Abs(localHitNormalized.y - testHitVector.y) + Mathf.Abs(localHitNormalized.z - testHitVector.z);

                    if (nDelta < delta)
                        {
                            value = side;
                            delta = nDelta;
                        }
                }
            }

            side++;

        } while (testHitVector != Vector3.zero);
        return value;
    }

    void Update()
    {
        if (rolling && localHit)
            GetValue();
    }

    protected bool valid(float t, float v)
    {
        if (t > (v - validMargin) && t < (v + validMargin))
            return true;
        else
            return false;
    }

    protected virtual Vector3 HitVector(int side)
    {
        return Vector3.zero;
    }

    public int TakeValue()
    {
        GetValue();

        return value;
    }

    public bool IsRolling()
    {
        if (rolling)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
