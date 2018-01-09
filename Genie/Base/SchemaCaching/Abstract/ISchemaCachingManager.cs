﻿using Genie.Core.Base.Configuration.Abstract;
using Genie.Core.Base.Files.Abstract;
using Genie.Core.Base.Reading.Abstract;

namespace Genie.Core.Base.SchemaCaching.Abstract
{
    public interface ISchemaCachingManager
    {
        /// <summary>
        /// This will create a schema file if it does n not exist
        /// and will make sure the schema file is correct
        /// </summary>
        /// <param name="schema">Schema to write</param>
        void SetupCache(IDatabaseSchema schema);
    }
}