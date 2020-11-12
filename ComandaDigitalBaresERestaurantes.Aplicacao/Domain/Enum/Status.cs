using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Aplicacao.Domain.Enum
{
    public enum Status
    {
        [Description("Open")]
        Open = 0,
        [Description("Closed")]
        Closed = 1,
        [Description("Payed")]
        Payed = 2,
        [Description("In Progress")]
        InProgress = 3,
        [Description("Prepared")]
        Prepared = 4

    }
}
