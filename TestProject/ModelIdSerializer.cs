using GraphQLServer;
using StrawberryShake.Serialization;

namespace TestProject
{
    public class ModelIdSerializer : ScalarSerializer<ulong, ModelId>
    {
        public ModelIdSerializer() : base("ModelIdScalar") { }

        public override ModelId Parse(ulong serializedValue) => serializedValue;

        protected override ulong Format(ModelId runtimeValue) => runtimeValue;
    }
}
