used to reproduce a bug where StrawberryShake fails to generate valid code.

to reproduce:
Uncommend the last two lines in file 'TestProject\GetModelId.graphql'

the generated code looks like this:

        private global::System.Object? FormatModelId(global::GraphQLServer.ModelId value)
        {
            if (value is null)   << 'CS0037: Cannot convert null to 'ModelId' because it is a non-nullable value type'
            {
                throw new global::System.ArgumentNullException(nameof(value));
            }

            return _modelIdScalarFormatter.Format(value);
        }
