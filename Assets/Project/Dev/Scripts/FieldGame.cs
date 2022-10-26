using UnityEngine;

public class FieldGame : MonoBehaviour
{
    public void Awake()
    {
        Cart[,] arrayCart = new Cart[4, 2]; ;
        Cart cartObj = new Cart();

        for (int i = 0; i < arrayCart.GetLength(0); i++)
        {
            for (int j = 0; j < arrayCart.GetLength(1); j++)
            {
                Cart cart = Instantiate(cartObj);
                cart.transform.position = new Vector2(i - 2.6f + i, j + 2.1f - (j * 3));
                arrayCart[i, j] = cart;
            }
        }
    }
}
