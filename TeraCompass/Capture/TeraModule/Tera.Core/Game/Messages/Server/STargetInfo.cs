﻿using TeraCompass.Tera.Core.Game.Services;

namespace TeraCompass.Tera.Core.Game.Messages.Server
{
    public class STargetInfo : ParsedMessage

    {
        internal STargetInfo(TeraMessageReader reader) : base(reader)
        {
            reader.Skip(8);
            Target = reader.ReadEntityId();
        }

        public EntityId Target { get; private set; }
    }
}