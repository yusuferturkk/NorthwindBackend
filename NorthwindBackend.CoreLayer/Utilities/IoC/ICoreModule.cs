using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindBackend.CoreLayer.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection colletion);
    }
}
