using HotChocolate.Language;

namespace GraphQLServer
{
    public sealed class ModelIdScalar : ScalarType<ModelId, IntValueNode>
    {
        public ModelIdScalar() : base(nameof(ModelIdScalar))
        {
        }

        protected override ModelId ParseLiteral(IntValueNode literal)
        {
            return new ModelId(literal.ToUInt64());
        }

        public override bool TrySerialize(object? runtimeValue, out object? resultValue)
        {
            if (runtimeValue is ModelId modelId)
            {
                resultValue = (ulong)modelId;
                return true;
            }
            else
            {
                resultValue = null;
                return false;
            }
        }

        public override bool TryDeserialize(object? resultValue, out object? runtimeValue)
        {
            if (resultValue is ulong ulongValue)
            {
                runtimeValue = new ModelId(ulongValue);
                return true;
            }
            return base.TryDeserialize(resultValue, out runtimeValue);
        }


        protected override IntValueNode ParseValue(ModelId value)
        {
            return new IntValueNode((ulong)value);
        }

        public override IValueNode ParseResult(object? resultValue)
        {
            return resultValue switch
            {
                null => new NullValueNode(null),
                ulong ulongValue => new IntValueNode(ulongValue),
                ModelId modelId => ParseValue(modelId),
                _ => throw new InvalidOperationException($"unexpected type: {resultValue.GetType().Name}")
            };
        }
    }
}
