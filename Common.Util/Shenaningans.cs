using System.Text;

namespace Common.Util;

public static class Shenaningans
{
    public static string NameGenerator()
    {
        StringBuilder builder = new StringBuilder();
        int[] dices = new int[4];
        var random = new Random(Guid.NewGuid().GetHashCode());
        for (int i = 0; i < dices.Length; i++)
        {
            dices[i] = random.Next(0, 216);
        }
        var index = string.Join("", dices);

        return builder.ToString();
    }
}
