using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<double> numbers = new List<double>();
        Console.WriteLine("(พิมพ์ 'q' เพื่อหยุด):");

        // รับข้อมูล
        while (true)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "q") break;

            if (double.TryParse(input, out double num))
            {
                numbers.Add(num);
            }
            else
            {
                Console.WriteLine("ใส่เลขเเมะ");
            }
        }

        if (numbers.Count > 0)
        {
            // แสดงผล
            Console.WriteLine("\nผลลัพธ์");
            Console.WriteLine($"ค่าเฉลี่ย (Mean): {numbers.Average():F4}");
            Console.WriteLine($"ค่าสูงสุด (Max): {numbers.Max()}");
            Console.WriteLine($"ค่าต่ำสุด (Min): {numbers.Min()}");
            Console.WriteLine($"ค่ากลางข้อมูล (Median): {CalculateMedian(numbers)}");

            // เรียงลำดับ
            var ascending = numbers.OrderBy(n => n).ToList();
            var descending = numbers.OrderByDescending(n => n).ToList();

            Console.WriteLine("เรียงจากน้อยไปมาก: " + string.Join(", ", ascending));
            Console.WriteLine("เรียงจากมากไปน้อย: " + string.Join(", ", descending));
        }
        else
        {
            Console.WriteLine("ไม่มีข้อมูล");
        }
    }

    // ค่ากลาง
    static double CalculateMedian(List<double> list)
    {
        var sortedList = list.OrderBy(n => n).ToList();
        int count = sortedList.Count;
        if (count % 2 == 0)
        {
            // ถ้ามีจำนวนคู่ ให้เฉลี่ยค่าตรงกลาง 2 ตัว
            return (sortedList[(count / 2) - 1] + sortedList[count / 2]) / 2;
        }
        else
        {
            // ถ้ามีจำนวนคี่ ให้หยิบตัวตรงกลาง
            return sortedList[count / 2];
        }
    }
}