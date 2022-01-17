using System.Collections;
using System.Collections.Generic;
using System;

// 랜덤으로 레시피를 만들고 싶다.
// 0번 인덱스는 bottom, 5번 인덱스는 top
// 1,2,3,4 번 인덱스의 오브젝트는 랜덤하게(null까지 포함하여)

namespace RecipeArray
{
    public class Array
    {
        public static void shuffle<T>(T[] data, T[] resave)
        {
            for (int i = 1; i < data.Length - 1; i++)
            {
                data[i] = resave[i];
                Random ran = new Random();
                int randomValue = ran.Next(1, data.Length - 1);
                T temp = data[i];
                data[i] = data[randomValue];
                data[randomValue] = temp;
            }
        }

        public static void sideshuffle<T>(T[] data, T[] resave)
        {
            for(int i = 0; i<data.Length; i++)
            {
                data[i] = resave[i];
                Random ran = new Random();
                int randomValue = ran.Next(0, data.Length);
                T temp = data[i];
                data[i] = data[randomValue];
                data[randomValue] = temp;
            }
        }
    }


}