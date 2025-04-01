namespace GraphQLServer
{
    public enum ModelType : uint
    {
        Type0 = 0,
        Type1 = 1,
        Type2 = 2,
    }

    public readonly struct ModelId : IEquatable<ModelId>
    {
        private readonly ulong id;

        public static ModelId? Create(ModelType type, uint? instance) =>
            instance == null ? null : Create(type, instance.Value);
        public static ModelId Create(ModelType type, uint instance) =>
            new(type, instance);


        public ModelId(ModelType type, uint instance) =>
            id = (ulong)type << 32 | instance & 0xFFFF_FFFF;

        public ModelId(ulong id) =>
            this.id = id;

        public bool Equals(ModelId other) =>
            id == other.id;

        public override bool Equals(object? obj) =>
            obj is ModelId objId && Equals(objId);

        public override int GetHashCode() =>
            id.GetHashCode();

        public override string ToString() =>
            $"{Type}_{Instance}";

        public static bool operator ==(ModelId identifier1, ModelId identifier2) =>
            identifier1.Equals(identifier2);

        public static bool operator !=(ModelId identifier1, ModelId identifier2) =>
            !identifier1.Equals(identifier2);

        public readonly ModelType Type =>
            (ModelType)((id & 0xFFFF_FFFF_0000_0000) >> 32);

        public readonly uint Instance =>
            (uint)(id & 0xFFFF_FFFF);

        public static implicit operator ulong(ModelId modelId) =>
            modelId.id;

        public static implicit operator ModelId(ulong id) =>
            new(id);
    }
}
