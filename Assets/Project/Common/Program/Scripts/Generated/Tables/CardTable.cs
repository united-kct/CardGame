// <auto-generated />
#pragma warning disable CS0105
using Common.MasterData;
using MasterMemory.Validation;
using MasterMemory;
using MessagePack;
using System.Collections.Generic;
using System;

namespace Generated.MasterData.Tables
{
   public sealed partial class CardTable : TableBase<Card>, ITableUniqueValidate
   {
        public Func<Card, string> PrimaryKeySelector => primaryIndexSelector;
        readonly Func<Card, string> primaryIndexSelector;


        public CardTable(Card[] sortedData)
            : base(sortedData)
        {
            this.primaryIndexSelector = x => x.Id;
            OnAfterConstruct();
        }

        partial void OnAfterConstruct();


        public Card FindById(string key)
        {
            return FindUniqueCore(data, primaryIndexSelector, System.StringComparer.Ordinal, key, true);
        }
        
        public bool TryFindById(string key, out Card result)
        {
            return TryFindUniqueCore(data, primaryIndexSelector, System.StringComparer.Ordinal, key, out result);
        }

        public Card FindClosestById(string key, bool selectLower = true)
        {
            return FindUniqueClosestCore(data, primaryIndexSelector, System.StringComparer.Ordinal, key, selectLower);
        }

        public RangeView<Card> FindRangeById(string min, string max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, System.StringComparer.Ordinal, min, max, ascendant);
        }


        void ITableUniqueValidate.ValidateUnique(ValidateResult resultSet)
        {
#if !DISABLE_MASTERMEMORY_VALIDATOR

            ValidateUniqueCore(data, primaryIndexSelector, "Id", resultSet);       

#endif
        }

#if !DISABLE_MASTERMEMORY_METADATABASE

        public static MasterMemory.Meta.MetaTable CreateMetaTable()
        {
            return new MasterMemory.Meta.MetaTable(typeof(Card), typeof(CardTable), "card",
                new MasterMemory.Meta.MetaProperty[]
                {
                    new MasterMemory.Meta.MetaProperty(typeof(Card).GetProperty("Id")),
                    new MasterMemory.Meta.MetaProperty(typeof(Card).GetProperty("Power")),
                    new MasterMemory.Meta.MetaProperty(typeof(Card).GetProperty("Hand")),
                    new MasterMemory.Meta.MetaProperty(typeof(Card).GetProperty("Type")),
                    new MasterMemory.Meta.MetaProperty(typeof(Card).GetProperty("ImageId")),
                },
                new MasterMemory.Meta.MetaIndex[]{
                    new MasterMemory.Meta.MetaIndex(new System.Reflection.PropertyInfo[] {
                        typeof(Card).GetProperty("Id"),
                    }, true, true, System.StringComparer.Ordinal),
                });
        }

#endif
    }
}