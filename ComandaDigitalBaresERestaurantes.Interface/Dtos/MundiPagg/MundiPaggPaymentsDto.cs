using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Interface.Dtos.MundiPagg
{
    public class MundiPaggPaymentDto
    {
        public List<MundiPaggPaymentsDto> payments { get; set; }
    }
    public class MundiPaggPaymentsDto
    {
        public string payment_method { get; set; }
        public MundiPaggCrediCardDto credit_card { get; set; }

    }

    public class MundiPaggCrediCardDto
    {
        public MundiPaggCardDto card { get; set; }
    }

    public class MundiPaggCardDto
    {
        public string number { get; set; }
        public string holder_name { get; set; }
        public int exp_month { get; set; }
        public int exp_year { get; set; }
        public string cvv { get; set; }
    }
}
