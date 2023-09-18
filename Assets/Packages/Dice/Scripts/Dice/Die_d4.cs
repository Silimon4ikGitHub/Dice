
using UnityEngine;
using System.Collections;

public class Die_d4 : Die, IControlable 
{
	
    override protected Vector3 HitVector(int side)
    {
        switch (side)
        {
            case 1: return new Vector3(0.4F, 0.4F, -0.7F);
            case 2: return new Vector3(-0.4F, -0.4F, -0.7F);
            case 3: return new Vector3(0.7F, -0.4F, 0.2F);
            case 4: return new Vector3(-0.2F, 0.7F, 0.2F);
        }
        return Vector3.zero;
    }
}
