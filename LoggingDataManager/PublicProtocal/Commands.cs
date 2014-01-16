using System;
using System.Collections.Generic;
using System.Text;

namespace PublicProtocal
{
    [Serializable]
    public enum Commands
    {
        Surpress=1,
        DataRequired=2
    }
    [Serializable]
    public enum Responses
    {
        Ready=1,
        Data=2,
    }
}
