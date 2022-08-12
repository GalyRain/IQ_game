using UI;

namespace Data
{
    [System.Serializable]
    public class LevelData
    {
        public bool level1;
        public bool level2;
        public bool level3;
        public bool level4;
        public bool level5;
        public bool level6;
        public bool level7;
        public bool level8;
        public bool level9;
        public bool level10;
        public bool level11;
        public bool level12;
        public bool level13;
        public bool level14;
        public bool level15;
        public bool level16;
        public bool level17;
        public bool level18;
        public bool level19;
        public bool level20;
        public bool level21;

        public LevelData(UILevelController level)
        {
            level1 = level.level1;
            level2 = level.level2;
            level3 = level.level3;
            level4 = level.level4;
            level5 = level.level5;
            level6 = level.level6;
            level7 = level.level7;
            level8 = level.level8;
            level9 = level.level9;
            level10 = level.level10;
            level11 = level.level11;
            level12 = level.level12;
            level13 = level.level13;
            level14 = level.level14;
            level15 = level.level15;
            level16 = level.level16;
            level17 = level.level17;
            level18 = level.level18;
            level19 = level.level19;
            level20 = level.level20;
            level21 = level.level21;
        }
    }
}