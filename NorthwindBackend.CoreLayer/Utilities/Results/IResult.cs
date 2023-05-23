using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.CoreLayer.Utilities.Results
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
