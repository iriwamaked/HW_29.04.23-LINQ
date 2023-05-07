using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HW_29._04._23
{
    class Firm
    {
        public string _firmName { get; set; }
        public DateTime _dateCreate { get; set;}
        public string _profile { get; set; }
        public string _directorName { get; set; }
        public int _workersNum { get; set; }
        public string _adress { get; set; }

        public override string ToString()
        {
            return $"\n\tФирма: {_firmName}, " +
                $"\n\t\t\tДата создания: {_dateCreate}, " +
                $"\n\t\t\tПрофиль: {_profile}," +
                $"\n\t\t\tДиректор: {_directorName}, " +
                $"\n\t\t\tКоличество сотрудников: {_workersNum}, " +
                $"\n\t\t\tАдрес: {_adress}.";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Firm> firms = new List<Firm>
            {
                new Firm {_firmName="FoodMaker", _dateCreate=new DateTime(2000, 01, 01), _profile="Marketing", _directorName="Daniel Jhonson", _workersNum=50, _adress="USA, Chicago, Unknown street"},
                new Firm {_firmName="MoneyMaker", _dateCreate=new DateTime(2005, 05, 15), _profile="Marketing", _directorName="Anna Ruben", _workersNum=5, _adress="USA, Chicago, Unknown street"},
                new Firm {_firmName="Developer Edition", _dateCreate=new DateTime(2020, 10, 8), _profile="IT", _directorName="Jack White", _workersNum=150, _adress="Great Britain, London, Unknown street"},
                new Firm {_firmName="Development", _dateCreate=new DateTime(2022, 12, 31), _profile="Building", _directorName="Sandra White", _workersNum=299, _adress="Italia, Milan, Unknown street"},
                new Firm {_firmName="Stomatology", _dateCreate=new DateTime(2015, 06, 17), _profile="Medicine", _directorName="Andre Tan", _workersNum=50, _adress="Great Britain, London, Unknown street"},
                new Firm {_firmName="WhiteColor", _dateCreate=new DateTime(2010, 01, 01), _profile="Marketing", _directorName="Sirius Black", _workersNum=120, _adress="USA, Texas, Unknown street"},
                new Firm {_firmName="FoodGlovo", _dateCreate=new DateTime(2023, 01, 04), _profile="Marketing", _directorName="Harry Potter", _workersNum=400, _adress="Great Britain, London, Little Whinging"}
            };

            Console.WriteLine("\n\tВыберите операцию: " + 
                "\n\t\t1 - Получить информацию о всех фирмах;" + 
                "\n\t\t2 - Получить фирмы, у которых в названии есть слово «Food»" +
                "\n\t\t3 - Получить фирмы, которые работают в сфере маркетинга" +
                "\n\t\t4 - Получить фирмы, которые работают в сфере маркетинга или IT" +
                "\n\t\t5 - Получить фирмы с количеством сотрудников более 100" +
                "\n\t\t6 - Получить фирмы с количеством сотрудников в диапазоне от 100 до 3000" +
                "\n\t\t7 - Получить фирмы, которые находятся в Лондоне" +
                "\n\t\t8 - Получить фирмы, у которых фамилия директора White" +
                "\n\t\t9 - Получить фирмы, у которых дата основания более двух лет назад" +
                "\n\t\t10 - Получить фирмы, с дня основания которых прошло 123 дня" +
                "\n\t\t11 - Получить фирмы, у которых фамилия директора Black и имеют в названии слово «White».");
            int choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    var firmInfo = from firm in firms
                                   select firm;
                    foreach (var firm in firmInfo)
                    {
                        Console.WriteLine(firm);
                    }
                    break;
                case 2:
                    var firmFood = from firm in firms
                                   where firm._firmName.Contains("Food")
                                   select firm;
                    foreach (var firm in firmFood)
                    {
                        Console.WriteLine(firm);
                    }
                    break;
                case 3:
                    var firmProfile=from firm in firms
                                    where firm._profile.Contains("Marketing")
                                    select firm;
                    foreach (var firm in firmProfile)
                    {
                        Console.WriteLine(firm);
                    }
                    break;
                case 4:
                    var firmProfile2=from firm in firms
                                     where firm._profile.Contains("Marketing") || firm._profile.Contains("IT")
                                     select firm;
                    foreach (var firm in firmProfile2)
                    {
                        Console.WriteLine(firm);
                    }
                    break;
                case 5:
                    var firmWorkNum=from firm in firms
                                    where firm._workersNum>100
                                    select firm;
                    foreach(var firm in firmWorkNum)
                    {
                        Console.WriteLine(firm);
                    }
                    break;
                case 6:
                    var firmWorkNum2=from firm in firms
                                     where firm._workersNum>100 && firm._workersNum<300
                                     select firm;
                    foreach (var firm in firmWorkNum2)
                    {
                        Console.WriteLine(firm);
                    }
                    break;
                case 7:
                    var firmLocation = from firm in firms
                                       where firm._adress.Contains("London")
                                       select firm;
                    foreach (var firm in firmLocation)
                    {
                        Console.WriteLine(firm);
                    }
                    break; 
                case 8:
                    var dirNameWhite = firms.Where(x => x._directorName.Contains("White")).Select(x => x);
                    foreach (var dir in dirNameWhite) 
                    {
                        Console.WriteLine(dir);
                    }
                    break; 
                case 9:
                    var firmDate = firms.Where(firm => firm._dateCreate.CompareTo(DateTime.Now.AddYears(-2)) < 0).Select(firm => firm);
                    foreach (var firm in firmDate)
                    {
                        Console.WriteLine(firm);
                    }
                    break;
                case 10:
                    var firmDate2 = firms.Where(firm => (DateTime.Now - firm._dateCreate).Days == 123).Select(firm => firm);
                    foreach (var firm in firmDate2)
                    {
                        Console.WriteLine(firm);
                    }
                    break;
                case 11:
                    var firmBlackWhite=from firm in firms
                                       where firm._directorName.Contains("Black")
                                       where firm._firmName.Contains("White")
                                       select firm;
                    foreach (var firm in firmBlackWhite)
                    {
                        Console.WriteLine(firm);
                    }
                    break;

            }
        }  
    } 
}

