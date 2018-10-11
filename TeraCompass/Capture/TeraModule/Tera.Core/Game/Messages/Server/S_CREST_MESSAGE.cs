﻿using TeraCompass.Tera.Core.Game.Services;

namespace TeraCompass.Tera.Core.Game.Messages.Server
{
    public class S_CREST_MESSAGE : ParsedMessage
    {
        internal S_CREST_MESSAGE(TeraMessageReader reader) : base(reader)
        {
            
            //PrintRaw();
            var unknow = reader.ReadUInt32();

            //Type? 6 = reset? 
            var typeId = reader.ReadUInt32();
           // Trace.WriteLine("Crest type id:" + typeId);
            Type = (CrestType)typeId;
            SkillId = reader.ReadInt32() & 0x3FFFFFF;
          //  Trace.WriteLine("Crest :" + Type + ";Skill Id "+SkillId);

        }

        public CrestType Type { get; set; }

        public int SkillId { get; set; }
    }

    public enum CrestType
    {
        Reset = 6
    }
}
