using System;  //стандартна бібліотека з набором функцій тіпа Mаth і так далі
using System.Collections.Generic; //бібліотека щоб юзати списки List
using MyFunctions; //наша бібліотека з функціями (в с# це методи)

namespace Variant11
{
    class Program
    {
        static void Main(string[] args)
        {   
            int sizeArrayStrings = Func.GetNumber("Введiть кiлькiсть рядкiв"); //вводимо кількість строк в масиві строк

            string [] arrayStrings = new string [sizeArrayStrings];  //створюємо масив строк
            Func.GetArrayStrings(ref arrayStrings);  //ініціалізуємо масив строк

            List<int> arrayA = new List<int>(); //створюємо список (масив А з задачі 3), оскільки ми хз скільки буде кусків по 'c'

            Func.FormatString(ref arrayStrings, ref arrayA);  //виводимо масив строк у новому форматі

            Func.PrintArrayStrings("Оновлений масив рядкiв", ref arrayStrings);  //виводимо масив строк
            
            int[,] matrixM = new int[arrayA.Count, arrayA.Count]; //створюємо матрицю М
            Func.GetMatrix(arrayA, ref matrixM); //заповнюємо матрицю М так, як сказано в задачі

            Func.PrintMatrix("M", matrixM); //Виводимо матрицю М
            
            int col = Func.GetNumber("Введiть номер стовпчика") - 1; //введення номеру стовпчика 

            int row;  //створюємо змінну - номер рядка який видалимо
            Func.NumberOfRowWithMax(Func.RowFromMatrix(matrixM, col), out row);  //знаходимо рядок, який потрібно видалити

            Func.PrintMatrix("M", matrixM, row);   //виводимо матрицю М з видаленим рядком

            Console.ReadKey(); //щоб консольне вікно не закривалось зразу
        }
    }
}
