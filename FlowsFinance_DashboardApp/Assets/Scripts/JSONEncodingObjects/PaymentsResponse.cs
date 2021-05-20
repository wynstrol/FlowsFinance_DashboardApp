using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaymentsResponse
{
    public string Event;
    public string amount;
    public string target;
    public string initiator;
    public string identifier;
    public string log_time;
    public string token_address;
    public string reason;
    public PaymentsResponse(){}
}
