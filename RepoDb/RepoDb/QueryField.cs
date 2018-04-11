﻿using RepoDb.Attributes;
using RepoDb.Enumerations;
using RepoDb.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace RepoDb
{
    public class QueryField : IQueryField
    {
        public QueryField(string fieldName, object value)
            : this(fieldName, Operation.Equal, value)
        {
        }

        public QueryField(string fieldName, Operation operation, object value)
        {
            Field = new Field(fieldName);
            Operation = operation;
            Parameter = new Parameter(fieldName, value);
        }

        // Properties

        public IField Field { get; }

        public Operation Operation { get; }

        public IParameter Parameter { get; }

        // Methods

        public string GetOperationText()
        {
            var textAttribute = typeof(Operation)
                .GetMembers()
                .First(member => string.Equals(member.Name, Operation.ToString(), StringComparison.InvariantCultureIgnoreCase))
                .GetCustomAttribute<TextAttribute>();
            return textAttribute.Text;
        }

        public override string ToString()
        {
            return $"{Field.ToString()} = {Parameter.ToString()}";
        }

        // Static Methods

        internal static IQueryField Parse(string fieldName, object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"Parameter '{Constant.Value.ToLower()}' cannot be null.");
            }
            var properties = value.GetType().GetProperties();
            var operationProperty = properties
                .FirstOrDefault(
                    property => string.Equals(property.Name, Constant.Operation, StringComparison.InvariantCultureIgnoreCase));
            var valueProperty = properties
                .FirstOrDefault(
                    property => string.Equals(property.Name, Constant.Value, StringComparison.InvariantCultureIgnoreCase));
            if (operationProperty == null || operationProperty?.PropertyType != typeof(Operation))
            {
                throw new InvalidOperationException($"The '{Constant.Operation}' property must be a type of '{typeof(Operation).FullName}'.");
            }
            if (valueProperty == null)
            {
                throw new InvalidOperationException($"The '{Constant.Value.ToLower()}' is missing for '{fieldName}' field.");
            }
            var operation = (Operation)operationProperty.GetValue(value);
            value = valueProperty.GetValue(value);
            if (value == null)
            {
                throw new InvalidOperationException($"The field '{Constant.Value}' for property '{fieldName}' should not be null.");
            }
            var isForArrayOperation = operation == Operation.Between || operation == Operation.NotBetween ||
                operation == Operation.In || operation == Operation.NotIn;
            if (value.GetType().IsGenericType || (!value.GetType().IsArray && isForArrayOperation))
            {
                throw new InvalidOperationException($"Invalid value for property '{fieldName} ({operation.ToString()})'.");
            }
            return new QueryField(fieldName, operation, value);
        }
    }
}