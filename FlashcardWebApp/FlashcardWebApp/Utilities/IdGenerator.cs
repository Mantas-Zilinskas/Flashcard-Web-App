﻿namespace FlashcardWebApp.Utilities
{
    public static class IdGenerator
    {
        public static string GenerateId<T>(T seed1, T seed2, int maxRandom = 10000000)
            where T : class, IComparable<T>
        {
            Random random = new Random();

            if (seed1 is null || seed2 is null)
            {
                throw new ArgumentNullException(nameof(seed1), "The seed arguments cannot be null.");
            }

            int comparisonResult = seed1.CompareTo(seed2);

            ComparisonIndicator comparisonIndicator; // Use the enum type
            if (comparisonResult < 0)
            {
                comparisonIndicator = ComparisonIndicator.LT;
            }
            else if (comparisonResult > 0)
            {
                comparisonIndicator = ComparisonIndicator.GT;
            }
            else
            {
                comparisonIndicator = ComparisonIndicator.EQ;
            }

            string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string randomValue = random.Next(1, maxRandom).ToString();
            string id = $"{dateTime} {seed1}_{seed2}_{comparisonIndicator}_{randomValue}";

            return id;
        }
    }
}
