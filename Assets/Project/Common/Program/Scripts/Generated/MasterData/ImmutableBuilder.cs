// <auto-generated />
#pragma warning disable CS0105
using Common.MasterData;
using MasterMemory.Validation;
using MasterMemory;
using MessagePack;
using System.Collections.Generic;
using System;
using Generated.MasterData.Tables;

namespace Generated.MasterData
{
   public sealed class ImmutableBuilder : ImmutableBuilderBase
   {
        MemoryDatabase memory;

        public ImmutableBuilder(MemoryDatabase memory)
        {
            this.memory = memory;
        }

        public MemoryDatabase Build()
        {
            return memory;
        }

        public void ReplaceAll(System.Collections.Generic.IList<Card> data)
        {
            var newData = CloneAndSortBy(data, x => x.Id, System.StringComparer.Ordinal);
            var table = new CardTable(newData);
            memory = new MemoryDatabase(
                table
            
            );
        }

        public void RemoveCard(string[] keys)
        {
            var data = RemoveCore(memory.CardTable.GetRawDataUnsafe(), keys, x => x.Id, System.StringComparer.Ordinal);
            var newData = CloneAndSortBy(data, x => x.Id, System.StringComparer.Ordinal);
            var table = new CardTable(newData);
            memory = new MemoryDatabase(
                table
            
            );
        }

        public void Diff(Card[] addOrReplaceData)
        {
            var data = DiffCore(memory.CardTable.GetRawDataUnsafe(), addOrReplaceData, x => x.Id, System.StringComparer.Ordinal);
            var newData = CloneAndSortBy(data, x => x.Id, System.StringComparer.Ordinal);
            var table = new CardTable(newData);
            memory = new MemoryDatabase(
                table
            
            );
        }

    }
}