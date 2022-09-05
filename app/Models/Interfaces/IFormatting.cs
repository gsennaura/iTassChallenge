using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guilherme.SenaGuilherme.Models.Interfaces
{
    public interface IFormatting
    {
        string HeaderInformation();
        string SpecificConverter(string[] sourceLines);
    }
}