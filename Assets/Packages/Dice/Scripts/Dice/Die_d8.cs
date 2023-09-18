
using UnityEngine;

public class Die_d8 : Die, IControlable
{
    override protected Vector3 HitVector(int side)
    {
        switch (side)
        {
            case 1: return new Vector3(0F, 0.7F, 0.7F);
            case 2: return new Vector3(0F, -0.7F, -0.7F);
            case 3: return new Vector3(0.7F, 0F, -0.7F);
            case 4: return new Vector3(-0.7F, 0F, 0.7F);
            case 5: return new Vector3(0F, -0.7F, 0.7F);
            case 6: return new Vector3(0F, 0.7F, -0.7F);
            case 7: return new Vector3(-0.7F, 0F, -0.7F);
            case 8: return new Vector3(0.7F, 0F, 0.7F);
        }
        return Vector3.zero;
    }
}
