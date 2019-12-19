using System;
using System.Collections.Generic;
using System.Linq;

namespace Formula.Core
{
    public class ActionStatusService
    {
        public ActionStatusService()
        {
            this.Reset();
        }

        public ActionStatusService Reset()
        {
            return this.Succeed()
                       .SetMessage(null)
                       .SetData(null)
                       .SetDetails(null);
        }


        public Boolean IsSuccessful { get; set; }

        public ActionStatusService Succeed()
        {
            this.IsSuccessful = true;
            return this;
        }

        public ActionStatusService Fail()
        {
            this.IsSuccessful = false;
            return this;
        }



        public String Message { get; set; }

        public ActionStatusService SetMessage(String message)
        {
            this.Message = message;
            return this;
        }



        public Object Data { get; set; }
        public ActionStatusService SetData(Object data)
        {
            this.Data = data;
            return this;
        }


        public Dictionary<String, String> Details { get; set; }
        public ActionStatusService SetDetails(Dictionary<String, String> details)
        {
            this.Details = details;
            return this;
        }

        public ActionStatusService RecordFailure(String message, String subject = null)
        {
            this.Fail().SetMessage(message);

            if (String.IsNullOrEmpty(subject) == false)
            {
                if (this.Details == null)
                {
                    this.Details = new Dictionary<string, string>();
                }

                if (this.Details.ContainsKey(subject))
                {
                    this.Details[subject] = message;
                }
                else
                {
                    this.Details.Add(subject, message);
                }
            }

            return this;
        }

    }
}
