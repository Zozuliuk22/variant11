using System;  //стандартна бібліотека з набором функцій тіпа Mаth і так далі
using System.Collections.Generic; //бібліотека щоб юзати списки List

namespace MyFunctions
{
    public class Func
    {
        public static int GetNumber(string text) //введення числа користувачем
        {
            Console.Write(text + " : ");
            int number = Convert.ToInt32(Console.ReadLine());  //введення числа
            Console.WriteLine();

            return number; //повертаємо значення введеного числа
        }

        public static void GetArrayStrings(ref string [] arrayStrings) //введення масива рядків користувачем
        {
            int size = arrayStrings.Length;  //розмір масиву, що вводиться
            for (int i = 0; i < size; i++)  //i - індекс масиву
            {
                Console.Write("рядок " + (i + 1) + " : ");  //рядок + його номер
                arrayStrings[i] = Console.ReadLine();  //ініціалізуємо комірку масива строк
            }
            Console.WriteLine();
        }

        public static void PrintArrayStrings(string text, ref string[] arrayStrings) //виведення масива рядків
        {
            Console.WriteLine(text + " :");
            int size = arrayStrings.Length;  //розмір масиву, що виводиться
            for (int i = 0; i < size; i++)   //і - індекс масиву
                Console.WriteLine("рядок " + (i + 1) + " : " + arrayStrings[i]);  //виведення
            Console.WriteLine();
        }

        public static void FormatString(ref string[] arrayStrings, ref List <int> arrayA) //обрахування кількості с та запис отриманих значень в масив А
        {
            int size = arrayStrings.Length; //розмір масиву строк
            for (int i = 0; i < size; i++)  //і - індекс масиву строк
            {
                string temp = arrayStrings[i];  //неформатована строка з масиву
                string temp_rezult = "";        //форматована строка з масиву
                int count_c = 0;                //кількість символів с підряд

                for (int j = 0; j < arrayStrings[i].Length; j++)  //j - індекс елемента поточної строки (строка - це масив символів)
                {
                    if (temp[j] != 'c')   //якщо поточний елемент не с
                    {
                        if (count_c == 0)    //якщо ми не знаходили перед ним елемент с
                            temp_rezult += temp[j]; //додаємо еленмент не рівний с в результуючу строку масиву

                        else                 //якщо ми знаходили перед ним елемент с
                        {
                            temp_rezult += ("c{" + count_c + "}");  //додаємо елемент с та його кількість підряд
                            arrayA.Add(count_c);   //заносимо знайдену кількість в масив А
                            count_c = 0;           //обнуляємо значення знайдених підряд с
                            temp_rezult += temp[j];  //заносимо поточний елемент який не рівний с
                        }
                    }
                    else
                        count_c += 1;  //знаходимо кількість елементів с підряд
                }

                if (count_c != 0)  //якщо у нас елемент с в кінці строки, то пораховану кількість елементів с, котрі стоять в кінці неформатованого рядка, повинні додати в кінець форматованого рядка
                {
                    temp_rezult += ("c{" + count_c + "}");  //додаємо елемент с та його кількість підряд
                    arrayA.Add(count_c);                    //заносимо знайдену кількість в масив А
                    count_c = 0;                            //обнуляємо значення знайдених підряд с
                }

                arrayStrings[i] = temp_rezult;  //змінюємо неформатований рядок масиву на форматований
            }
        }

        public static void GetMatrix(List<int> arrayA, ref int [,] matrixM) //заповнення матриці М
        {
            Random rand = new Random();  //рандом

            for (int i = 0; i < arrayA.Count; i++)  //i - індекс рядка
            {
                for (int j = 0; j < arrayA.Count; j++) //j - індекс стовпчика
                {
                    if (i == j)   //по діагоналі значення з масиву А
                        matrixM[i, j] = arrayA[i];  
                    if (j > i)    //над діагоналлю
                        matrixM[i, j] = rand.Next(arrayA[0]);
                    if (i > j)    //під діагоналлю
                        matrixM[i, j] = rand.Next(arrayA[arrayA.Count - 1]);
                }
            }
        }

        public static void PrintMatrix(string label, int [,] matrixM, int row = -1) //виведення матриці
        {
            Console.WriteLine("Матриця " + label + " : ");
            int size = (int)Math.Sqrt(matrixM.Length); //розмір матриці
            for (int i = 0; i < size; i++)  //i - індекс рядка
            {
                if (i != row) //видалення вказаного рядка або якщо row = -1 виведення всієї матриці
                {
                    for (int j = 0; j < size; j++)  //j - індекс стовпчика
                        Console.Write(String.Format("{0 , 3}", matrixM[i, j]) + " ");  //виведення елемента

                    Console.WriteLine("\n");
                }
            }
        }

        public static void NumberOfRowWithMax(int [] temp, out int row) //отримання номера рядка з максимальним елементом
        {
            int max = temp[0];  //максимальний елемент вибраного стовпчика матриці М
            int size = temp.Length;  //розмір стовпчика матриці М
            row = 0; //ініціалізація номера рядка, що буде видалено

            for (int i = 1; i < size; i++)  //i - індекс стовпчика
            {
                if (temp[i] >= max)  //знаходження максимального елемента в стовпчику
                {
                    max = temp[i];
                    row = i;  //знаходження індекса рядка максимального елемента
                }
            }
        }

        public static int[] RowFromMatrix(int [,] matrixM, int col) //отримання стовпчика з матриці
        {
            int size = (int)Math.Sqrt(matrixM.Length);  //розмір матриці М
            int[] temp = new int[size];     //створення проміжного масиву в який запишемо вираний стовпчик
            for (int i = 0; i < size; i++)  //i - індекс проміжного масиву
                temp[i] = matrixM[i, col]; //заповнення проміжного масиву значеннями з вибраного стовпчика


            return temp; //повернення вибраного стовпчика
        }
    }
}
