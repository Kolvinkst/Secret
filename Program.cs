using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Secret
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HasASecret keeper = new HasASecret();

            // При снятии комментария с команды Console.WriteLine происходит ошибка компиляции:
            // поле 'HasASecret' недоступно из-за его защиты.
            // Console.WriteLine(keeper.secret);

            // Но для получения значения поля secret всё ещё можно воспользоваться отражением
            FieldInfo[] fields = keeper.GetType().GetFields(
                BindingFlags.NonPublic | BindingFlags.Instance );

            // Этот цикл foreach выводит на консоль строку "xyzzy"
            foreach (FieldInfo field in fields)
            {
                Console.WriteLine(field.GetValue(keeper));
            } 
            Console.ReadLine();
        }
    }
}
