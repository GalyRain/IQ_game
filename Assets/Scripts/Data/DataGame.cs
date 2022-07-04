namespace Data
{
    public static class DataGame
    {
        public static float[] CheckDistance(int level)
        {
            switch (level)
            {
                case 1:
                default:
                    float[] valuesOne = { 2.9f, 6.4f, 3.3f};
                    return valuesOne;
                case 2:
                    float[] valuesTwo = { 3.7f, 4.1f, 7.1f, 7.5f, 4.7f, 8.0f};
                    return valuesTwo;
                case 3:
                    float[] valuesThree = { 5.0f, 5.1f, 5.0f, 5.1f };
                    return valuesThree;
                case 4:
                    float[] valuesFour = { 6.9f, 4.8f, 5.4f, 4.0f };
                    return valuesFour;
            }
        }
    }
}