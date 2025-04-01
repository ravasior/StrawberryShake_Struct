using StrawberryShake.Serialization;

namespace TestProject
{
    public class UnsignedIntSerializer : ScalarSerializer<long, uint>
    {
        public UnsignedIntSerializer() : base("UnsignedInt") { }

        public override uint Parse(long serializedValue) => (uint)serializedValue;

        protected override long Format(uint runtimeValue) => runtimeValue;
    }

}
