﻿using Newtonsoft.Json;
using Passbook.Generator.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Passbook.Generator
{
    public class RelevantBeacon
    {
        public string ProximityUUID { get; set; }
        public string RelevantText { get; set; }

        public void Write(JsonWriter writer)
        {
            Validate();

            writer.WriteStartObject();

            writer.WritePropertyName("proximityUUID");
            writer.WriteValue(ProximityUUID);

            if (!string.IsNullOrEmpty(RelevantText))
            {
                writer.WritePropertyName("relevantText");
                writer.WriteValue(RelevantText);
            }

            writer.WriteEndObject();
        }

        private void Validate()
        {
            if (!String.IsNullOrEmpty(ProximityUUID))
            {
                throw new RequiredFieldValueMissingException("ProximityUUID");
            }
        }
    }
}
