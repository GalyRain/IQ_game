namespace Data
{
    public static class DataGame
    {

        public static float[] CheckDistance(string level)
        {
            switch (level)
            {
                case "1":
                default:
                    float[] values = { 7.1f, 6.6f, 6.9f, 6.3f, 3.5f, 3.0f, 7.3f, 6.8f, 6.3f, 5.8f, 3.7f, 3.2f };
                    return values;
            }
        }
    }
}