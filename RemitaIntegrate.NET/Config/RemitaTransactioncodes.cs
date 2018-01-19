using System;
using System.Collections.Generic;
using System.Text;

namespace RemitaIntegrate.NET.Config
{
    public enum RemitaTransactioncodes
    {
        Transaction_Completed = 00,
        Transaction_Approved = 01,
        Transaction_Failed = 02,
        User_Aborted_Transaction = 012,
        Invalid_User_Authentication = 020,
        Transaction_Pending = 021,
        Invalid_Request = 022,
        Service_Type_Or_Merchant_Does_Not_Exist = 023,
        Payment_Reference_Generated = 025,
        Invalid_Bank_Code = 029,
        Insufficient_Balance = 030,
        No_Funding_Account = 031,
        Invalid_Date_Format = 032,
        Initial_Request_OK = 040,
        Unknown_Error = 999
    }
}
