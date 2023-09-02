
using UnityEngine;

public class Die_d20 : Die
{
    override protected Vector3 HitVector(int side)
    {
        switch (side)
        {
            case 1: return new Vector3(1F, 0F, 0.2F);
            case 2: return new Vector3(-0.7F, -0.7F, 0F);
            case 3: return new Vector3(0.5F, 0.5F, -0.7F);
            case 4: return new Vector3(-0.5F, 0.5F, 0.7F);
            case 5: return new Vector3(0.2F, -0.5F, 0.7F);
            case 6: return new Vector3(-0.4F, 0.7F, -0.2F);
            case 7: return new Vector3(0.7F, -0.7F, -0.2F);
            case 8: return new Vector3(-0.5F, 0F, -0.7F);
            case 9: return new Vector3(0.2F, 0.7F, 0.2F);
            case 10: return new Vector3(-0.2F, -0.5F, -0.7F);
            case 11: return new Vector3(0.2F, 0.5F, 0.7F);
            case 12: return new Vector3(-0.2F, -0.7F, -0.2F);
            case 13: return new Vector3(0.7F, 0F, 0.7F);
            case 14: return new Vector3(-0.7F, 0.7F, 0.2F);
            case 15: return new Vector3(0.2F, -0.7F, 0.2F);
            case 16: return new Vector3(-0.2F, 0.5F, -0.7F);
            case 17: return new Vector3(0.5F, -0.2F, -0.7F);
            case 18: return new Vector3(-0.5F, -0.2F, 0.7F);
            case 19: return new Vector3(0.7F, 0.7F, -0.2F);
            case 20: return new Vector3(-0.7F, 0F, -0.2F);
        }
        return Vector3.zero;
    }
}
