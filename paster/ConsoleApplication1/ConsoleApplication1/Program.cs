using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = new List<string>(); // объявление динамического строкового массива
         //string[] str = new string[10];
           string stroka=""; // строка принимает значения из массив str
           string stroka2=""; // строка принимает значение из строки stroka но без цифр
           string stroka3="";
           char[] b = {'1','2','3','4','5','6','7','8','9','0','.'}; // массив b содержит все значения которые нужно удалить из текстового файла


            if (File.Exists("1.txt"))
        {
            FileStream fsR = new FileStream("1.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fsR);
                int i = 0;
                while ((stroka3 = sr.ReadLine()) != null) {                    
                    str.Add(stroka3);
                    }
        

                    sr.Close();
                fsR.Close();


            //нужно из массива вычитать все цифры и записть в файл 2.txt


            FileStream fsW = new FileStream("2.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fsW);
            Boolean bl=true;
                for (i = 0; i < str.Count; i++)//str.Length-1
                {
                    stroka2 ="";
                     stroka = str[i];  // в переменную stroka присваеваес первую строчку из текста 
                    Console.WriteLine(stroka);
                    Console.ReadLine();
                    char[] a = stroka.ToCharArray(); // переводим строковую переменную stroka в символьный массив

                    for (int j = 0; j < a.Length; j++) { // перебираем каждый элемент массива
                        bl = true;
                        foreach (char ch in b) 
                        {
                            if (a[j] == ch) // сравниваем по очереди каждый элемент массива a[j] с значениями из массива b
                                            // если символ равен значению переменной  ch, то происходит выход из цикла и логичиская переменная присвоится false
                            {               // если при переборе массива символы не равны цифрам то программа не зайдет в тело цикла и переменная  bl не изменет своег значения, значит это символ
                                bl = false;
                            break;
                            }   
                        }               
                        if (bl == true) stroka2 +=Char.ToString(a[j]);
                    }

                    sw.WriteLine(stroka2);
                       
                }

                sw.Close();
             fsW.Close();
           


            Console.WriteLine("Файл найден");
            Console.ReadLine();
        }
     

        }
    }
}
