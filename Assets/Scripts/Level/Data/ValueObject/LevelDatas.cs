using Scripts.Level.Data.ValueObject;
using System;

namespace Data.ValueObject
{
    [Serializable]
    public class LevelDatas
    {
        public LevelData levelData;

        public PlatformData PlatformData;

        public WeaponData WeaponData;

        public WalkersData WalkersData;

        public PaintBallData PaintBallData;
    }
}