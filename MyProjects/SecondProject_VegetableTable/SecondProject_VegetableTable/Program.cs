using System.Data.SqlClient;

Console.OutputEncoding = System.Text.Encoding.UTF8;

uint choiсe = 0;


void PrintList()
{
    Console.WriteLine("1) Отображение всей информации из таблицы с овощами и фруктами:");

    Console.WriteLine("2) Отображение всех названий овощей и фруктов:");

    Console.WriteLine("3) Отображение всех цветов:");

    Console.WriteLine("4) Показать максимальную калорийность:");

    Console.WriteLine("5) Показать минимальную калорийность:");

    Console.WriteLine("6) Показать среднюю калорийность.");

    Console.WriteLine("7) Показать количество овощей:");

    Console.WriteLine("8) Показать количество фруктов:");

    Console.WriteLine("9) Показать количество овощей и фруктов заданного цвета:");

    Console.WriteLine("10) Показать количество овощей и фруктов каждого цвета:");

    Console.WriteLine("11) Показать овощи и фрукты с калорийностью ниже указанной:");

    Console.WriteLine("12) Показать овощи и фрукты с калорийностью выше указанной:");

    Console.WriteLine("13) Показать овощи и фрукты с калорийностью в указанном диапазоне:");

    Console.WriteLine("14) Показать все овощи и фрукты, у которых цвет желтый или красный:");

}

// choose info
while (true)
{
    Console.Clear();
    PrintList();
    Console.Write("\n---------------------------\nEnter choise: ");

    choiсe = Convert.ToUInt32(Console.ReadLine());
    switch (choiсe)
    {
        case 1:
            DatabaseQuery("SELECT * FROM FruitsAndVegetables");
            break;
        case 2:
            DatabaseQuery("SELECT DISTINCT NameOfObject FROM FruitsAndVegetables");
            break;
        case 3:
            DatabaseQuery("SELECT DISTINCT Color FROM FruitsAndVegetables");
            break;
        case 4:
            DatabaseQuery("SELECT MAX(CalorieСontent) AS MaxCalorieСontent FROM FruitsAndVegetables");
            break;
        case 5:
            DatabaseQuery("SELECT MIN(CalorieСontent) AS MinCalorieСontent FROM FruitsAndVegetables");
            break;
        case 6:
            DatabaseQuery("SELECT AVG(CalorieСontent) AS AvrCalorieСontent FROM FruitsAndVegetables");
            break;
        case 7:
            DatabaseQuery("SELECT COUNT(*) AS AmountOfVegetables FROM FruitsAndVegetables WHERE TypeOfObject = 'vegetable'");
            break;
        case 8:
            DatabaseQuery("SELECT COUNT(*) AS AmountOfFruits FROM FruitsAndVegetables WHERE TypeOfObject = 'fruit'");
            break;
        case 9:
            DatabaseQuery("SELECT Color, COUNT(*) AS Количество FROM FruitsAndVegetables WHERE Color = 'yellow' GROUP BY Color");
            break;
        case 10:
            DatabaseQuery("SELECT Color, COUNT(*) AS Количество FROM FruitsAndVegetables GROUP BY Color");
            break;
        case 11:
            DatabaseQuery("SELECT * FROM FruitsAndVegetables WHERE CalorieСontent < 50");
            break;
        case 12:
            DatabaseQuery("SELECT * FROM FruitsAndVegetables WHERE CalorieСontent > 100");
            break;
        case 13:
            DatabaseQuery("SELECT * FROM FruitsAndVegetables WHERE CalorieСontent BETWEEN 50 AND 100");
            break;
        case 14:
            DatabaseQuery("SELECT * FROM FruitsAndVegetables WHERE Color IN ('yellow', 'red')");
            break;
    }
}

void DatabaseQuery(string str)
{
    SqlConnection connect = new SqlConnection(@"Initial Catalog=MyFruitsAndVegetables;Data Source=DESKTOP-UIJQEL8\SQLEXPRESS;Integrated Security=SSPI");
    SqlCommand command = new SqlCommand();
    try
    {
        connect.Open();
        command.Connection = connect;

        Console.Clear();

        Console.WriteLine("|Connection is opened|");
        Thread.Sleep(1000);

        Console.Clear();


        command.CommandText = str;
        SqlDataReader reader = command.ExecuteReader();

        int count = reader.FieldCount;

        while (reader.Read())
        {
            string? res = "", temp = "";
            for (int i = 0; i < count; i++)
            {
                temp = reader[i].ToString();
                res += temp + "  ";
            }
            Console.WriteLine(res);
            res = "";
        }
        reader.Close();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        command.Dispose();
        connect.Close();
    }
    Console.ReadKey();
}
