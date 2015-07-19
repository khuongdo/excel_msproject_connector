using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Text.RegularExpressions;
using ObjectsLibrary;
using System.Diagnostics;

namespace Test
{
    [TestFixture]
    class TestRegex
    {
        [Test]
        public void Test()
        {
            Unit unit = new Unit("100m3");
            Debug.Print(unit.Name);
            Debug.Print(unit.Factor.ToString());
        }

    }
}
