using ProofOfConceptOrders.Model.ValueObject;
using System;

namespace ProofOfConceptOrders.Model
{
    public abstract class AbstractProperty
    {
        public Guid PropertyTypeId { get; protected set; }
        public string Name { get; protected set; }
        public virtual object ObjectValue { get; }
        public string ReadValue => ObjectValue?.ToString() ?? string.Empty;
        public DataType DataType { get; protected set; }

        public TType GetValue<TType>()
        {
            return (TType)ObjectValue;
        }

        public override string ToString()
        {
            return $"{Name}: {ReadValue}";
        }
    }

    public abstract class AbstractProperty<TType> : AbstractProperty
    {
        public TType Value { get; protected set; }
        public override object ObjectValue => Value;
    }

    public class StringProperty : AbstractProperty<string>
    {
        public static StringProperty Create(Guid propertyTypeId, string name, string value)
        {
            return new StringProperty { PropertyTypeId = propertyTypeId, Name = name, Value = value, DataType = DataType.String };
        }
    }

    public class DateProperty : AbstractProperty<DateTime>
    {
        public static DateProperty Create(Guid propertyTypeId, string name, DateTime value)
        {
            return new DateProperty { PropertyTypeId = propertyTypeId, Name = name, Value = value, DataType = DataType.Date };
        }
    }

    public class TimeProperty : AbstractProperty<TimeSpan>
    {
        public static TimeProperty Create(Guid propertyTypeId, string name, TimeSpan value)
        {
            return new TimeProperty { PropertyTypeId = propertyTypeId, Name = name, Value = value, DataType = DataType.Time };
        }
    }

    public class BooleanProperty : AbstractProperty<bool>
    {
        public static BooleanProperty Create(Guid propertyTypeId, string name, bool value)
        {
            return new BooleanProperty { PropertyTypeId = propertyTypeId, Name = name, Value = value, DataType = DataType.Boolean };
        }
    }

    public class DecimalProperty : AbstractProperty<decimal>
    {
        public static DecimalProperty Create(Guid propertyTypeId, string name, decimal value)
        {
            return new DecimalProperty { PropertyTypeId = propertyTypeId, Name = name, Value = value, DataType = DataType.Decimal };
        }
    }

    public static class AbstractPropertExtensions
    {
        public static Property MapToProperty(this AbstractProperty stocklineProperty)
        {
            var property = Property.Default;
            switch (stocklineProperty.DataType)
            {
                case DataType.String:
                    property = Property.Create(stocklineProperty.Name, stocklineProperty.GetValue<string>());
                    break;

                case DataType.Date:
                    property = Property.Create(stocklineProperty.Name, stocklineProperty.GetValue<DateTime>());
                    break;

                case DataType.Time:
                    property = Property.Create(stocklineProperty.Name, stocklineProperty.GetValue<TimeSpan>());
                    break;

                case DataType.Boolean:
                    property = Property.Create(stocklineProperty.Name, stocklineProperty.GetValue<bool>());
                    break;

                case DataType.Decimal:
                    property = Property.Create(stocklineProperty.Name, stocklineProperty.GetValue<decimal>());
                    break;

                default:
                    break;
            }
            return property;
        }
    }
}