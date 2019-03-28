using System;
namespace uctas.Infrastructure
{
    public class GameActionResult
    {
        public ActionResultCode ActionResultCode { get; set; }
        public string ActionMessage { get; set; }
    }

    public enum ActionResultCode
    {
        OK,
        FAIL,
        FINISHED
    }
}
