﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using Tzkt.Api.Models;

namespace Tzkt.Api
{
    class OperationErrorConverter : JsonConverter<IOperationError>
    {
        public override IOperationError Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var sideReader = reader;

            sideReader.Read();
            sideReader.Read();
            var type = sideReader.GetString();

            return type switch
            {
                "contract.balance_too_low" => JsonSerializer.Deserialize<BalanceTooLowError>(ref reader, options),
                "contract.manager.unregistered_delegate" => JsonSerializer.Deserialize<UnregisteredDelegateError>(ref reader, options),
                "contract.non_existing_contract" => JsonSerializer.Deserialize<NonExistingContractError>(ref reader, options),
                _ => JsonSerializer.Deserialize<BaseOperationError>(ref reader, options)
            };
        }

        public override void Write(Utf8JsonWriter writer, IOperationError value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }

    static class OperationErrorSerializer
    {
        public static JsonSerializerOptions Options { get; }

        static OperationErrorSerializer()
        {
            Options = new JsonSerializerOptions();
            Options.Converters.Add(new OperationErrorConverter());
        }

        public static List<IOperationError> Deserialize(string json)
            => JsonSerializer.Deserialize<List<IOperationError>>(json, Options);
    }
}
