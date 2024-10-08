﻿#nullable enable

using Generated.MasterData;
using Generated.MasterData.Resolvers;
using MasterMemory;
using MasterMemory.Meta;
using MasterMemory.Validation;
using MessagePack;
using MessagePack.Resolvers;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Common.MasterData
{
    public static class MasterDataBuilder
    {
        public static void Build()
        {
            IFormatterResolver messagePackResolvers = CompositeResolver.Create(
                MasterMemoryResolver.Instance,
                GeneratedResolver.Instance,
                StandardResolver.Instance
            );
            MessagePackSerializerOptions options = MessagePackSerializerOptions.Standard.WithResolver(messagePackResolvers);
            MessagePackSerializer.DefaultOptions = options;

            DatabaseBuilder builder = new();
            MetaDatabase metaDataBase = MemoryDatabase.GetMetaDatabase();

            foreach (MetaTable table in metaDataBase.GetTableInfos())
            {
                List<object> data = CsvSerializer.Deserialize(table);
                builder.AppendDynamic(table.DataType, data);
            }

            byte[] binary = builder.Build();

            ValidateResult validateResult = new MemoryDatabase(binary).Validate();
            if (validateResult.IsValidationFailed)
            {
                throw new System.Exception(validateResult.FormatFailedResults());
            }

            string path = $"{Application.dataPath}/Project/Common/Program/MasterData/master_data.bytes";
            string dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            File.WriteAllBytes(path, binary);
            Debug.Log($"Write byte[] to: {path}");
            AssetDatabase.Refresh();
        }
    }
}