var conversor = new Conversor();

for (int i = 1; i <= 250; i++)
{
    var roman = conversor.GetRomanNumber(i);
    Console.WriteLine($"{i} = {roman}");
}

public class Conversor
{
    private readonly Dictionary<int, string> map = new Dictionary<int, string>()
    {
        { 1000, "M" },
        { 900, "CM" },
        { 500, "D" },
        { 400, "CD" },
        { 100, "C" },
        { 90, "XC" },
        { 50, "L" },
        { 40, "XL" },
        { 10, "X" },
        { 9, "IX" },
        { 5, "V" },
        { 4, "IV" },
        { 1, "I" }
    };

    public string GetRomanNumber(int number)
    {
        if (map.ContainsKey(number))
            return map[number];

        string roman = string.Empty;

        foreach (var item in map)
        {
            while (number >= item.Key)
            {
                roman += item.Value;
                number -= item.Key;
            }
        }

        return roman;
    }
}