using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.CoreLayer.Utilities.Results
{
    public interface IDataResult<TEntity> : IResult
    {
        TEntity Data { get; }
    }
}
