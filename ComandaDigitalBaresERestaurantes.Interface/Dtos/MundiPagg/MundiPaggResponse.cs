using System;
using System.Collections.Generic;
using System.Text;

namespace ComandaDigitalBaresERestaurantes.Interface.Dtos.MundiPagg
{
    public class MundiPaggResponse
    {
        public string id { get; set; }
        public string code { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
        public bool closed { get; set; }
        public List<MundiPaggItemResponse> items { get; set; }
        public MundiPaggCustomerResponse customer { get; set; }
        public List<MundiPaggChargeReponse> charges { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class MundiPaggItemResponse
    {
        public string id { get; set; }
        public string description { get; set; }
        public int amount { get; set; }
        public int quantity { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<MundiPaggChargeReponse> charges { get; set; }
    }

    public class MundiPaggCustomerResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public bool delinquent { get; set; }

        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class MundiPaggChargeReponse
    {
        public string id { get; set; }
        public string code { get; set; }
        public string cogateway_idde { get; set; }
        public int amount { get; set; }
        public string status { get; set; }
        public string currency { get; set; }
        public string payment_method { get; set; }
        public DateTime paid_at { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public MundiPaggLastTransaction last_transaction { get; set; }
    }

    public class MundiPaggLastTransaction
    {
        public string id { get; set; }
        public string transaction_type { get; set; }
        public string gateway_id { get; set; }
        public int amount { get; set; }
        public string status { get; set; }
        public bool success { get; set; }
        public string statement_descriptor { get; set; }
        public string acquirer_name { get; set; }
        public string acquirer_affiliation_code { get; set; }
        public string acquirer_tid { get; set; }
        public string acquirer_nsu { get; set; }
        public string acquirer_auth_code { get; set; }
        public string acquirer_message { get; set; }
        public string acquirer_return_code { get; set; }
        public string operation_type { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public MundiPaggCardResponse card { get; set; }
        public MundiPaggGatewayResponse gateway_response { get; set; }
    }

    public class MundiPaggCardResponse
    {
        public string id { get; set; }
        public string first_six_digits { get; set; }
        public string last_four_digits { get; set; }
        public string brand { get; set; }
        public string holder_name { get; set; }
        public int exp_month { get; set; }
        public int exp_year { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class MundiPaggGatewayResponse
    {
        public string code { get; set; }
    }
}


