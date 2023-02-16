using System;

namespace Scripts.Level.Data.ValueObject
{
    [Serializable]
    public class WalkersData
    {
        public WalkersMovementData WalkersMovementData;

        public WalkersAnimationData WalkersAnimationData;

        public WalkersMeshData WalkersMeshData;

        public WalkersGenerateData WalkersGanarateData;
    }
}