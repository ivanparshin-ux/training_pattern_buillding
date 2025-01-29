using System;
using System.Collections.Generic;

// Интерфейс Builder
public interface IHouseBuilder
{
    void Reset();
    void SetType(string type);
    void AddPool();
    void AddGarage();
    void AddGarden();
    void AddPathway();
}

// Класс HouseBuilder
public class HouseBuilder : IHouseBuilder
{
    private House house;

    public void Reset()
    {
        this.house = new House();
    }

    public void SetType(string type)
    {
        house.SetType(type);
    }

    public void AddPool()
    {
        house.AddFeature("Бассейн");
    }

    public void AddGarage()
    {
        house.AddFeature("Гараж");
    }

    public void AddGarden()
    {
        house.AddFeature("Полисадник");
    }

    public void AddPathway()
    {
        house.AddFeature("Тропинка");
    }

    public House GetResult()
    {
        return house;
    }
}

// Класс House
public class House
{
    private string type;
    private List<string> features = new List<string>();

    public void SetType(string type)
    {
        this.type = type;
    }

    public void AddFeature(string feature)
    {
        features.Add(feature);
    }

    public string GetDescription()
    {
        return $"Дом из {type} с дополнительными постройками: {string.Join(", ", features)}";
    }
}

// Класс Catalog
public class Catalog
{
    private List<House> houses = new List<House>();

    public void AddHouse(House house)
    {
        houses.Add(house);
    }

    public void ShowCatalog()
    {
        Console.WriteLine("Каталог домов:");
        foreach (var house in houses)
        {
            Console.WriteLine(house.GetDescription());
        }
    }
}

// Класс Client
public class Client
{
    public static void Main(string[] args)
    {
        Catalog catalog = new Catalog();
        HouseBuilder builder = new HouseBuilder();

        // Создание дома из камня с бассейном и гаражом
        builder.Reset();
        builder.SetType("камня");
        builder.AddPool();
        builder.AddGarage();
        catalog.AddHouse(builder.GetResult());

        // Создание дома из кирпича с полисадником и тропинкой
        builder.Reset();
        builder.SetType("кирпича");
        builder.AddGarden();
        builder.AddPathway();
        catalog.AddHouse(builder.GetResult());

        // Вывод каталога
        catalog.ShowCatalog();
    }
}