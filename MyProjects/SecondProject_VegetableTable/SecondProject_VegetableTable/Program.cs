using System.Data.SqlClient;

Console.OutputEncoding = System.Text.Encoding.UTF8;

uint choiсe = 0;

string SourceConnection = @"DESKTOP-UIJQEL8\SQLEXPRESS";


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
            DatabaseQuery(SourceConnection, "SELECT * FROM FruitsAndVegetables");
            break;
        case 2:
            DatabaseQuery(SourceConnection, "SELECT DISTINCT NameOfObject FROM FruitsAndVegetables");
            break;
        case 3:
            DatabaseQuery(SourceConnection, "SELECT DISTINCT Color FROM FruitsAndVegetables");
            break;
        case 4:
            DatabaseQuery(SourceConnection, "SELECT MAX(CalorieСontent) AS Максимальная_калорийность FROM FruitsAndVegetables");
            break;
        case 5:
            DatabaseQuery(SourceConnection, "SELECT MIN(CalorieСontent) AS Минимальная_калорийность FROM FruitsAndVegetables");
            break;
        case 6:
            DatabaseQuery(SourceConnection, "SELECT AVG(CalorieСontent) AS Средняя_калорийность FROM FruitsAndVegetables");
            break;
        case 7:
            DatabaseQuery(SourceConnection, "SELECT COUNT(*) AS Количество_овощей FROM FruitsAndVegetables WHERE TypeOfObject = 'овощ'");
            break;
        case 8:
            DatabaseQuery(SourceConnection, "SELECT COUNT(*) AS Количество_фруктов FROM FruitsAndVegetables WHERE TypeOfObject = 'фрукт'");
            break;
        case 9:
            DatabaseQuery(SourceConnection, "SELECT Color, COUNT(*) AS Количество FROM FruitsAndVegetables WHERE Color = 'желтый' GROUP BY Color");
            break;
        case 10:
            DatabaseQuery(SourceConnection, "SELECT Color, COUNT(*) AS Количество FROM FruitsAndVegetables GROUP BY Color");
            break;
        case 11:
            DatabaseQuery(SourceConnection, "SELECT * FROM FruitsAndVegetables WHERE CalorieСontent < 50");
            break;
        case 12:
            DatabaseQuery(SourceConnection, "SELECT * FROM FruitsAndVegetables WHERE CalorieСontent > 100");
            break;
        case 13:
            DatabaseQuery(SourceConnection, "SELECT * FROM FruitsAndVegetables WHERE CalorieСontent BETWEEN 50 AND 100");
            break;
        case 14:
            DatabaseQuery(SourceConnection, "SELECT * FROM FruitsAndVegetables WHERE Color IN ('желтый', 'красный')");
            break;
    }
}

void DatabaseQuery(string SourceConnection, string str)
{
    SqlConnection connect = new SqlConnection($"Initial Catalog=MyFruitsAndVegetables;Data Source={SourceConnection};Integrated Security=SSPI");
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

        Console.Clear();
        Console.WriteLine(ex.Message);
    }
    finally
    {
        command.Dispose();
        connect.Close();
    }
    Console.ReadKey();
}
