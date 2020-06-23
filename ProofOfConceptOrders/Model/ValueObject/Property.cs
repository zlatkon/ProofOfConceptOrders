using System;
using System.Collections.Generic;

namespace ProofOfConceptOrders.Model.ValueObject
{
    public class Property : ValueObject
    {
        // Don't make them readonly for EF
        private string _stringValue;

        private decimal _decimalValue;
        private DateTime _dateValue;
        private TimeSpan _timeValue;
        private bool _boolValue;

        private Property()
        {
        }

        private Property(string name, string value)
        {
            DataType = DataType.String;
            Name = name;
            _stringValue = value;
        }

        private Property(string name, decimal value)
        {
            DataType = DataType.Decimal;
            Name = name;
            _decimalValue = value;
        }

        private Property(string name, DateTime value)
        {
            DataType = DataType.Date;
            Name = name;
            _dateValue = value;
        }

        private Property(string name, TimeSpan value)
        {
            DataType = DataType.Time;
            Name = name;
            _timeValue = value;
        }

        private Property(string name, bool value)
        {
            DataType = DataType.Boolean;
            Name = name;
            _boolValue = value;
        }

        public static Property Create(string name, string value)
            => new Property(name, value);

        public static Property Create(string name, decimal value)
            => new Property(name, value);

        public static Property Create(string name, DateTime value)
            => new Property(name, value);

        public static Property Create(string name, TimeSpan value)
            => new Property(name, value);

        public static Property Create(string name, bool value)
            => new Property(name, value);

        public static Property Default
            => new Property(string.Empty, string.Empty);

        public string Name { get; private set; }
        public DataType DataType { get; private set; }
        public string ReadValue => GetValueAsString();

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return DataType;
            yield return _stringValue;
            yield return _decimalValue;
            yield return _dateValue;
            yield return _timeValue;
            yield return _boolValue;
        }

        private string GetValueAsString()
        {
            string value;

            switch (DataType)
            {
                case DataType.String:
                    value = _stringValue ?? string.Empty;
                    break;

                case DataType.Date:
                    value = _dateValue.ToString();
                    break;

                case DataType.Time:
                    value = _timeValue.ToString();
                    break;

                case DataType.Boolean:
                    value = _boolValue.ToString();
                    break;

                case DataType.Decimal:
                    value = _decimalValue.ToString();
                    break;

                default:
                    value = string.Empty;
                    break;
            }

            return value;
        }

        public TType GetValue<TType>()
        {
            switch (DataType)
            {
                case DataType.String:
                    return (TType)(_stringValue as Object);

                case DataType.Date:
                    return (TType)(_dateValue as Object);

                case DataType.Time:
                    return (TType)(_timeValue as Object);

                case DataType.Boolean:
                    return (TType)(_boolValue as Object);

                case DataType.Decimal:
                    return (TType)(_decimalValue as Object);

                default:
                    throw new ArgumentNullException($"{DataType} is an unsupported DataType.");
            }
        }
    }
}