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
                    float[] valuesOne = { 7.2f, 6.7f, 25.0f, 0.0f, 7.3f, 6.8f, 3.7f, 3.2f, 25.0f, 0.0f, 3.7f, 3.2f };
                    return valuesOne;
                case 2:
                    float[] valuesTwo = { 4.3f, 3.8f, 5.9f, 5.4f, 9.5f, 8.5f, 8.0f, 7.0f, 5.6f, 5.1f, 8.1f, 7.6f };
                    return valuesTwo;
            }
        }
    }
}