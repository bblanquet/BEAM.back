using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BEAM.back.Utils
{
    public class OutOfThresholdException:Exception
    {
        public OutOfThresholdException(string message) :base(message){ 
        }
    }
}
